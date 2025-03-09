import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router'; // Import NavigationEnd
import { filter } from 'rxjs/operators'; // Import filter operator
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  showSidebar: boolean = false;

  constructor(private router: Router, private authService: AuthService) {}

  ngOnInit(): void {
    // Listen to route changes and check if the current route is relevant for Bincard
    this.router.events
      .pipe(
        filter(event => event instanceof NavigationEnd) // Only listen to route changes
      )
      .subscribe(() => {
        const currentRoute = this.router.url;
        // Show the sidebar only for Bincard-related pages
        this.showSidebar = this.isBincardPage(currentRoute);
      });
  }

  /**
   * Determines if the current route is one of the Bincard pages
   */
  isBincardPage(route: string): boolean {
    const bincardRoutes = [
      '/register-item',        // Registration page
      '/items',                // Registered items page
      '/add-quantity',         // Add Item Quantity
      '/withdraw-quantity',    // Withdraw Item Quantity
      '/item-detail',           // Item Detail page
      
    ];

    // Check if the current route matches any of the Bincard pages
    return bincardRoutes.some(bincardRoute => route.startsWith(bincardRoute));
  }

  onLogout(): void {
    this.authService.logout(); // Call the logout method from AuthService
  }
}