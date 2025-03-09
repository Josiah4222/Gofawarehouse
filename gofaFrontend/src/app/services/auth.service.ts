import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap, finalize } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { Router } from '@angular/router';

// Define DTO interfaces for type safety
export interface RegisterDto {
  firstName: string;
  lastName: string;
  username: string;
  password: string;
  role: string; // Use an enum or restrict to allowed roles
}

export interface UpdateRolesDto {
  userId: string;
  roles: string[];
}

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = `${environment.apiBaseUrl}/api`;
  private isLoading = false;

  constructor(private http: HttpClient, private router: Router) {}

  /**
   * Logs in the user and stores the JWT token in localStorage.
   * @param username The user's username or email.
   * @param password The user's password.
   */
  login(username: string, password: string): Observable<any> {
    if (this.isLoading) return throwError(() => 'Request already in progress.');
    this.isLoading = true;

    return this.http.post(`${this.apiUrl}/login`, { username, password }).pipe(
      tap((response: any) => {
        if (response && response.token) {
          localStorage.setItem('token', response.token);

          const userDetails = this.decodeToken(response.token);
          if (userDetails && userDetails.role) {
            localStorage.setItem('role', userDetails.role); // Store the role
          } else {
            console.error('Role not found in token');
            localStorage.removeItem('token'); // Clear the token if no role is found
            throw new Error('Role not found in token. Please contact support.');
          }
        } else {
          console.error('Login response does not contain a token');
          throw new Error('Invalid login response. Please try again.');
        }
      }),
      catchError(this.handleError),
      finalize(() => (this.isLoading = false))
    );
  }

  /**
   * Registers a new user.
   * @param registerDto The registration data transfer object.
   */
  register(registerDto: RegisterDto): Observable<any> {
    if (this.isLoading) return throwError(() => 'Request already in progress.');
    this.isLoading = true;

    const allowedRoles = ['VHF', 'HF', 'Transit', 'Sparepart', 'Electronics', 'Manager'];
    if (!allowedRoles.includes(registerDto.role)) {
      this.isLoading = false;
      throw new Error('Invalid role selected');
    }

    return this.http.post(`${this.apiUrl}/Register/register`, registerDto).pipe(
      tap((response: any) => {
        console.log('Registration successful:', response);
      }),
      catchError(this.handleError),
      finalize(() => (this.isLoading = false))
    );
  }

  /**
   * Logs out the user by removing the token from localStorage.
   */
  logout(): void {
    console.log('Logging out...');
    const token = localStorage.getItem('token'); // Get the token before removing it
    if (token) {
      try {
        const userDetails = this.decodeToken(token);
        console.log('User details before logout:', userDetails);
      } catch (error) {
        console.error('Error decoding token during logout:', error);
      }
    }

    // Remove the token and role from localStorage
    localStorage.removeItem('token');
    localStorage.removeItem('role');

    // Navigate to the login page
    this.router.navigate(['/login']);
  }



  // In AuthService
  deleteUserByUsername(username: string): Observable<any> {
    const url = `${this.apiUrl}/admin/delete-by-username/${username}`;
    console.log('Deleting user at URL:', url); // Log the URL
  
    return this.http.delete(url); // No headers required
  }
  /**
   * Checks if the user is authenticated by verifying the presence of a valid token.
   * @returns True if the user is authenticated, false otherwise.
   */
  isAuthenticated(): boolean {
    const token = localStorage.getItem('token');
    return !!token && !this.isTokenExpired(token);
  }

  /**
   * Checks if the user has a specific role.
   * @param role The role to check for.
   * @returns True if the user has the specified role, false otherwise.
   */
  hasRole(role: string): boolean {
    const token = localStorage.getItem('token');
    if (!token) return false;

    try {
      const decodedToken = this.decodeToken(token);
      const userRoles = decodedToken.role || [];
      return Array.isArray(userRoles) ? userRoles.includes(role) : userRoles === role;
    } catch (error) {
      console.error('Error checking user role:', error);
      return false;
    }
  }

  /**
   * Decodes the JWT token manually.
   * @param token The JWT token to decode.
   * @returns The decoded token payload.
   */
  public decodeToken(token: string): any {
    if (!token) return null;

    try {
      const parts = token.split('.');
      if (parts.length !== 3) {
        throw new Error('Invalid token format.');
      }

      const payload = JSON.parse(atob(parts[1])); // Decode the payload

      // Extract role from the token
      const roleKey = 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role';
      const role = payload[roleKey] || null; // Use the correct key for the role

      if (role) {
        payload.role = Array.isArray(role) ? role : [role]; // Ensure role is always an array
      } else {
        payload.role = []; // No role found
      }

      return payload;
    } catch (error) {
      console.error('Error decoding token:', error);
      return null;
    }
  }

  /**
   * Checks if the token has expired.
   * @param token The JWT token to check.
   * @returns True if the token is expired, false otherwise.
   */
  private isTokenExpired(token: string): boolean {
    try {
      const decodedToken = this.decodeToken(token);
      const expirationTime = decodedToken?.exp; // Get the expiration time from the token
      if (!expirationTime) return true; // No expiration time means the token is invalid

      const currentTime = Math.floor(Date.now() / 1000); // Current time in seconds
      return expirationTime < currentTime; // Return true if the token is expired
    } catch (error) {
      console.error('Error checking token expiration:', error);
      return true; // Assume the token is expired if decoding fails
    }
  }

  /**
   * Gets the currently logged-in user's details from the token.
   * @returns The decoded token payload or null if no token exists.
   */
  getUserDetails(): any | null {
    const token = localStorage.getItem('token');
    if (!token) return null;

    try {
      return this.decodeToken(token); // Return the decoded token payload
    } catch (error) {
      console.error('Error getting user details:', error);
      return null;
    }
  }

  /**
   * Fetches all registered users.
   */
  getAllUsers(): Observable<any> {
    const token = localStorage.getItem('token');
    if (!token) {
      return throwError(() => 'No token found. Please log in.');
    }

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`,
    });

    return this.http.get(`${this.apiUrl}/admin/users`, { headers }).pipe(
      tap((response: any) => {
        console.log('Fetched users:', response);
      }),
      catchError(this.handleError)
    );
  }

  /**
   * Updates the roles of a user.
   * @param userId The ID of the user to update.
   * @param roles The new roles to assign to the user.
   */
  updateUserRoles(userId: string, roles: string[]): Observable<any> {
    const token = localStorage.getItem('token');
    if (!token) {
      throw new Error('No token found. Please log in.');
    }

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`,
    });

    const body: UpdateRolesDto = {
      userId: userId,
      roles: roles,
    };

    console.log('Sending request to:', `${this.apiUrl}/user/update-roles`);
    console.log('Request body:', body);

    return this.http.put(`${this.apiUrl}/user/update-roles`, body, { headers });
  }

  /**
   * Handle HTTP errors.
   * @param error The error response.
   */
  private handleError(error: HttpErrorResponse): Observable<never> {
    let errorMessage = 'An unknown error occurred!';
    if (error.error instanceof ErrorEvent) {
      // Client-side error
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // Server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.error(errorMessage);
    return throwError(() => errorMessage);
  }
}