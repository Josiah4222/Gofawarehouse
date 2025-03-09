import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-edit-warehouse',
  templateUrl: './edit-warehouse.component.html',
  styleUrls: ['./edit-warehouse.component.css']
})
export class EditWarehouseComponent implements OnInit {
  warehouse = { warehouseId: '', name: '', location: '' };
  isLoading = false;
  errorMessage: string | null = null;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private http: HttpClient
  ) {}

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.loadWarehouse(id);
    } else {
      this.errorMessage = 'Invalid warehouse ID.';
    }
  }

  loadWarehouse(id: string) {
    this.isLoading = true;
    this.http.get(`${environment.apiBaseUrl}/api/warehouses/${id}`).subscribe({
      next: (response: any) => {
        this.warehouse = response;
        this.isLoading = false;
      },
      error: (error) => {
        this.errorMessage = 'Failed to load warehouse details.';
        console.error('Error loading warehouse:', error);
        this.isLoading = false;
      }
    });
  }

  onSubmit() {
    if (this.isLoading) return;
    if (!this.warehouse.warehouseId || !this.warehouse.name || !this.warehouse.location) {
      this.errorMessage = 'All fields are required.';
      return;
    }

    this.isLoading = true;
    this.errorMessage = null;

    this.http.put(`${environment.apiBaseUrl}/api/warehouses/${this.warehouse.warehouseId}`, this.warehouse).subscribe({
      next: () => {
        alert('Warehouse updated successfully!');
        this.router.navigate(['/admin/warehouses']);
      },
      error: (error) => {
        this.errorMessage = 'Failed to update warehouse: ' + (error.error?.message || 'Unknown error');
        console.error('Error updating warehouse:', error);
        this.isLoading = false;
      },
      complete: () => {
        this.isLoading = false;
      }
    });
  }

  onCancel() {
    this.router.navigate(['/admin/warehouses']);
  }
}