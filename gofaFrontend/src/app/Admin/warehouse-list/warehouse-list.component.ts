import { Component, OnInit } from '@angular/core';
import { WarehouseService } from '../../services/warehouse-service.service'; // Import the WarehouseService
import { Warehouse } from '../../model/warehouse.model'; // Import the Warehouse model

@Component({
  selector: 'app-warehouse-list',
  templateUrl: './warehouse-list.component.html',
  styleUrls: ['./warehouse-list.component.css']
})
export class WarehouseListComponent implements OnInit {

  warehouses: Warehouse[] = []; // Array to store registered warehouses
  isLoading = true; // Loading state
  error: string | null = null; // Error state
  router: any;

  constructor(private warehouseService: WarehouseService) {} // Inject the WarehouseService

  ngOnInit(): void {
    this.loadWarehouses(); // Load warehouses on initialization
  }

  /**
   * Loads warehouses from the backend API.
   */
  loadWarehouses(): void {
    this.warehouseService.getWarehouses().subscribe(
      (data: Warehouse[]) => {
        this.warehouses = data; // Store the fetched warehouses
        this.isLoading = false; // Stop loading state
        this.error = null; // Clear any previous errors
      },
      (error) => {
        console.error('Error fetching warehouses:', error);
        this.error = 'Failed to load warehouses. Please try again later.';
        this.isLoading = false; // Stop loading state
      }
    );
  }

  /**
   * Handles the edit action for a warehouse.
   * @param warehouseId The ID of the warehouse to edit.
   */
  onEdit(warehouseId: string): void {
    this.router.navigate(['/warehouses/edit', warehouseId]); // Navigate to the edit page
  }

  /**
   * Handles the delete action for a warehouse.
   * @param warehouseId The ID of the warehouse to delete.
   */
  onDelete(warehouseId: string): void {
    if (confirm('Are you sure you want to delete this warehouse?')) {
      this.warehouseService.deleteWarehouse(warehouseId).subscribe(
        () => {
          this.loadWarehouses(); // Reload the warehouse list after deletion
        },
        (error) => {
          console.error('Error deleting warehouse:', error);
          alert('Failed to delete warehouse. Please try again.');
        }
      );
    }
  }
}