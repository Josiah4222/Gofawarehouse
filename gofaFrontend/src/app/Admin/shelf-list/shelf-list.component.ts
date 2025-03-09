// shelf-list.component.ts
import { Component, OnInit } from '@angular/core';
import { ShelfService, Shelf, Warehouse } from '../../services/shelf.service';

@Component({
  selector: 'app-shelf-list',
  templateUrl: './shelf-list.component.html',
  styleUrls: ['./shelf-list.component.css']
})
export class ShelfListComponent implements OnInit {
  shelves: Shelf[] = [];
  filteredShelves: Shelf[] = [];
  warehouses: Warehouse[] = [];
  errorMessage: string = '';
  successMessage: string = '';
  editingShelfId: string | null = null;
  editedShelf: Shelf | null = null;

  // Pagination properties
  currentPage: number = 1;
  pageSize: number = 5;
  totalPages: number = 1;

  // Filter properties
  searchTerm: string = '';
  filterByName: boolean = false; // Checkbox for name filter
  filterByWarehouse: boolean = false; // Checkbox for warehouse filter

  constructor(private shelfService: ShelfService) { }

  ngOnInit(): void {
    this.loadShelves();
    this.loadWarehouses();
  }

  loadShelves(): void {
    this.shelfService.getShelves().subscribe({
      next: (shelves) => {
        this.shelves = shelves;
        this.applyFiltersAndPagination();
      },
      error: (error) => {
        this.errorMessage = 'Failed to load shelves';
        console.error(error);
      }
    });
  }

  loadWarehouses(): void {
    this.shelfService.getWarehouses().subscribe({
      next: (warehouses) => {
        this.warehouses = warehouses;
      },
      error: (error) => {
        this.errorMessage = 'Failed to load warehouses';
        console.error(error);
      }
    });
  }

  startEdit(shelf: Shelf): void {
    this.editingShelfId = shelf.shelfId!;
    this.editedShelf = { ...shelf, warehouse: { ...shelf.warehouse } };
  }

  cancelEdit(): void {
    this.editingShelfId = null;
    this.editedShelf = null;
    this.successMessage = '';
    this.errorMessage = '';
  }

  saveEdit(): void {
    if (this.editedShelf && this.editingShelfId) {
      const updatedShelf: Shelf = {
        shelfId: this.editedShelf.shelfId,
        name: this.editedShelf.name,
        column: this.editedShelf.column,
        row: this.editedShelf.row,
        warehouse: this.editedShelf.warehouse
      };

      this.shelfService.updateShelf(this.editingShelfId, updatedShelf).subscribe({
        next: () => {
          const index = this.shelves.findIndex(s => s.shelfId === this.editingShelfId);
          if (index !== -1) {
            this.shelves[index] = updatedShelf;
            this.applyFiltersAndPagination();
          }
          this.successMessage = 'Shelf updated successfully';
          this.errorMessage = '';
          this.cancelEdit();
        },
        error: (error) => {
          this.errorMessage = 'Failed to update shelf';
          this.successMessage = '';
          console.error(error);
        }
      });
    }
  }

  compareWarehouses(w1: Warehouse, w2: Warehouse): boolean {
    return w1 && w2 ? w1.warehouseId === w2.warehouseId : w1 === w2;
  }

  // Filtering and Pagination Logic
  applyFiltersAndPagination(): void {
    let filtered = this.shelves;

    // Apply search filter based on checkboxes
    if (this.searchTerm && (this.filterByName || this.filterByWarehouse)) {
      const term = this.searchTerm.toLowerCase();
      filtered = filtered.filter(shelf => {
        const matchesName = this.filterByName && shelf.name.toLowerCase().includes(term);
        const matchesWarehouse = this.filterByWarehouse && shelf.warehouse.name.toLowerCase().includes(term);
        return matchesName || matchesWarehouse;
      });
    }

    // Calculate pagination
    this.totalPages = Math.ceil(filtered.length / this.pageSize);
    const startIndex = (this.currentPage - 1) * this.pageSize;
    const endIndex = startIndex + this.pageSize;
    this.filteredShelves = filtered.slice(startIndex, endIndex);

    // Reset to first page if filtered results are empty or page is out of bounds
    if (this.filteredShelves.length === 0 && filtered.length > 0) {
      this.currentPage = 1;
      this.applyFiltersAndPagination();
    }
  }

  onFilterChange(): void {
    this.currentPage = 1; // Reset to first page on filter change
    this.applyFiltersAndPagination();
  }

  goToPage(page: number): void {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
      this.applyFiltersAndPagination();
    }
  }
}