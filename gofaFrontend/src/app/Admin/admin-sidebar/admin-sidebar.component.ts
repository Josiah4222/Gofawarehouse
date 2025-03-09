import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-admin-sidebar',
  templateUrl: './admin-sidebar.component.html',
  styleUrls: ['./admin-sidebar.component.css']
})
export class AdminSidebarComponent implements OnInit {
  showSidebar: boolean = false; // Controls sidebar visibility

  constructor(private router: Router, private authService: AuthService) {}

  ngOnInit(): void {
    // Listen to route changes and update sidebar visibility
    this.router.events
      .pipe(filter(event => event instanceof NavigationEnd))
      .subscribe(() => {
        const currentRoute = this.normalizeRoute(this.router.url);
        this.showSidebar = this.isAdminPage(currentRoute);
      });
  }

  /**
   * Determines if the current route is an admin-related page.
   * @param route - The current route path.
   * @returns True if the route is an admin page, otherwise false.
   */
  isAdminPage(route: string): boolean {
    const adminRoutes = [
      '/admin/users',           // User list
      '/admin/register',        // Register new user
      '/admin/update-roles/:id', // Dynamic route for updating roles
      '/admin/delete-user/:id',  // Dynamic route for deleting user
      '/admin/warehouses',
      '/admin/warehouses/edit/:id',
      '/admin/shelf',
      '/admin/shelves'
    ];

    return adminRoutes.some(adminRoute => this.matchRoute(route, adminRoute));
  }

  /**
   * Matches a route against a pattern, handling dynamic segments.
   * @param actualRoute - The actual route path.
   * @param patternRoute - The route pattern to match.
   * @returns True if the actual route matches the pattern, otherwise false.
   */
  matchRoute(actualRoute: string, patternRoute: string): boolean {
    const regexPattern = new RegExp('^' + patternRoute.replace(/:id/, '[^/]+') + '$');
    return regexPattern.test(actualRoute);
  }

  /**
   * Normalizes the route by removing query parameters and fragments.
   * @param route - The raw route path.
   * @returns The normalized route path.
   */
  normalizeRoute(route: string): string {
    return route.split('?')[0].split('#')[0];
  }

  /**
   * Handles user logout.
   */
  onLogout(): void {
    this.authService.logout();
    console.log('Admin logged out successfully.');
  }
}