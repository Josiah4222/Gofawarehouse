import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { ShelfService } from '../../services/shelf.service';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent implements OnInit {
  totalUsers: number = 0;
  totalWarehouses: number = 0;
  totalShelves: number = 0;

  constructor(
    private authService: AuthService,
    private shelfService: ShelfService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.fetchTotalUsers();
    this.fetchTotalWarehouses();
    this.fetchTotalShelves();
  }

  fetchTotalUsers(): void {
    this.authService.getAllUsers().subscribe({
      next: (users) => {
        this.totalUsers = users.length;
      },
      error: (err) => {
        console.error('Failed to fetch users:', err);
      }
    });
  }

  fetchTotalWarehouses(): void {
    this.shelfService.getWarehouses().subscribe({
      next: (warehouses) => {
        this.totalWarehouses = warehouses.length;
      },
      error: (err) => {
        console.error('Failed to fetch warehouses:', err);
      }
    });
  }

  fetchTotalShelves(): void {
    this.shelfService.getShelves().subscribe({
      next: (shelves) => {
        this.totalShelves = shelves.length;
      },
      error: (err) => {
        console.error('Failed to fetch shelves:', err);
      }
    });
  }

  // Navigation Methods
  navigateToUsers(): void {
    this.router.navigate(['/users']);
  }

  navigateToWarehouses(): void {
    this.router.navigate(['/warehouses']);
  }

  navigateToShelves(): void {
    this.router.navigate(['/shelves']);
  }
}