import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Warehouse } from '../model/warehouse.model'; // Adjust the path as needed
import { environment } from '../../environments/environment'; // Import the environment file

@Injectable({
  providedIn: 'root'
})
export class WarehouseService {
  private apiUrl = `${environment.apiBaseUrl}/api/warehouses`; // Use environment.apiBaseUrl directly

  constructor(private http: HttpClient) {}

  // Create a new warehouse
  createWarehouse(warehouse: Warehouse): Observable<any> {
    return this.http.post<any>(this.apiUrl, warehouse).pipe(
      catchError(this.handleError)
    );
  }

  // Get all warehouses
  getWarehouses(): Observable<Warehouse[]> {
    return this.http.get<Warehouse[]>(this.apiUrl).pipe(
      catchError(this.handleError)
    );
  }

  // Get a single warehouse by ID
  getWarehouseById(id: string): Observable<Warehouse> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<Warehouse>(url).pipe(
      catchError(this.handleError)
    );
  }

  // Update a warehouse
  updateWarehouse(id: string, warehouse: Warehouse): Observable<any> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.put<any>(url, warehouse).pipe(
      catchError(this.handleError)
    );
  }

  // Delete a warehouse
  deleteWarehouse(id: string): Observable<any> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete<any>(url).pipe(
      catchError(this.handleError)
    );
  }

  // Error handling
  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // Client-side or network error
      console.error('An error occurred:', error.error.message);
    } else {
      // Server-side error
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error
      );
    }
    return throwError(() => new Error('Something bad happened; please try again later.'));
  }
}