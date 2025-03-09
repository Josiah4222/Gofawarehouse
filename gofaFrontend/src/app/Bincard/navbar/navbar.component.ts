import { Component, HostListener } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  navbarOpen = false; // Track navbar state
  windowWidth: number = window.innerWidth; // Current window width

  constructor() {}

  ngOnInit(): void {
    this.updateWindowWidth();
  }

  /**
   * Toggles the mobile navbar visibility.
   */
  toggleNavbar(): void {
    this.navbarOpen = !this.navbarOpen;
  }

  /**
   * Closes the mobile navbar when a link is clicked.
   */
  closeNavbar(): void {
    if (this.windowWidth <= 768) {
      this.navbarOpen = false;
    }
  }

  /**
   * Updates the window width on resize.
   */
  @HostListener('window:resize', ['$event'])
  onResize(event: any): void {
    this.windowWidth = event.target.innerWidth;
    this.updateWindowWidth();
  }

  /**
   * Ensures the navbar is closed if the screen size increases beyond 768px.
   */
  updateWindowWidth(): void {
    if (this.windowWidth > 768) {
      this.navbarOpen = false;
    }
  }

  /**
   * Handles logout functionality.
   */
  logout(): void {
    // Add your logout logic here (e.g., clear localStorage, redirect to login page)
    alert('Logout functionality triggered!');
    // Example: Clear registered items from localStorage
    localStorage.removeItem('registeredItems');
    // Optionally, navigate to a login page or home page
    // this.router.navigate(['/login']);
  }
}