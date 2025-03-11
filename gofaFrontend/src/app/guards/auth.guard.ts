import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service'; // Import your AuthService

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    const requiredRole = route.data['role'] as string; // Get the required role from the route data
    const userRoles = this.authService.getCurrentUserRoles(); // Get the current user's roles

    if (this.authService.isAuthenticated() && (!requiredRole || userRoles.includes(requiredRole))) {
      return true; // Allow access if the user is authenticated and has the required role
    } else {
      this.router.navigate(['/login']); // Redirect to login if the user is not authenticated or doesn't have the required role
      return false;
    }
  }
}