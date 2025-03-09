import { Component, OnInit } from '@angular/core';
import { TransitService } from '../../services/transit.service';
import { Item } from '../../models/item.model';

// import { MatDialog } from '@angular/material/dialog';
import { Sort } from '@angular/material/sort';

import { ConfirmationDialogComponent } from '../../confirmation-dialog/confirmation-dialog.component';
import { EditItemComponent } from '../edit-item/edit-item.component';
import { ViewDetailsComponent } from '../view-details/view-details.component';
import { MatDialog } from '@angular/material/dialog';



@Component({
  selector: 'app-received-items-list',
  templateUrl: './received-items-list.component.html',
  styleUrl: './received-items-list.component.css'
})
export class ReceivedItemsListComponent implements OnInit {

  receivedItems: Item[] = [];
  filteredItems: Item[] = [];
  searchQuery: string = '';
  paginatedItems: Item[] = []; // Items for the current page
  currentPage = 1; // Current page number
  itemsPerPage = 100; // Number of items per page
  totalPages = 0; // Total number of pages

  sortOptions = [
    { value: 'supplier', viewValue: 'Supplier' },
    { value: 'itemType', viewValue: 'Item Type' },
    { value: 'status', viewValue: 'Status' },
    { value: 'date', viewValue: 'Date Added' }
  ];
  selectedSort = 'status';

  constructor(
    private transitService: TransitService,
    public dialog: MatDialog
  ) {}



  ngOnInit() {
    this.loadItems();
  }

  loadItems() {
    this.transitService.getReceivedItems().subscribe({
      next: (items) => {
        this.receivedItems = items;
        this.filteredItems = [...items]; // Initialize filteredItems with the full list
        this.sortItems(this.selectedSort); // Sort initially
        this.updatePagination();
      },
      error: (err) => console.error('Error loading items:', err)
    });
  }



  // approveItem(item: Item) {
  //   if (item.status === 'Pending Inspection') {
  //     this.transitService.updateItemStatus(item.model1Id, 'Approved').subscribe({
  //       next: () => this.loadItems(),
  //       error: (err) => console.error('Approval failed:', err)
  //     });
  //   }
  // }

  approveItem(item: Item): void {
    const newStatus = {
      ...item,
      status: 'Approved' // Only update the status field
    };

    this.transitService.updateItemStatus(item.model1Id.toString(), newStatus).subscribe({
      next: () => {
        console.log('Item approved successfully!');
        this.loadItems(); // Refresh the list
      },
      error: (err) => console.error('Approval failed:', err)
    });
  }

  



  // viewDetails(item: Item): void {
  //   this.dialog.open(ViewDetailsComponent, {
  //     width: '600px',
  //     data: { item }
  //   });
  // }

  // editItem(item: Item): void {
  //   const dialogRef = this.dialog.open(EditItemComponent, {
  //     width: '600px',
  //     data: { item: {...item} }
  //   });

  //   dialogRef.afterClosed().subscribe(result => {
  //     if (result) {
  //       this.transitService.updateItemStatus(item.model1Id, result).subscribe({
  //         next: () => this.loadItems(),
  //         error: (err) => console.error('Update failed:', err)
  //       });
  //     }
  //   });
  // }

  deleteItem(item: Item): void {
    const confirmed = window.confirm(`Are you sure you want to delete ${item.itemType} (${item.serialNumber})?`);

    if (confirmed) {
      this.transitService.deleteItem(item.model1Id.toString()).subscribe({
        next: () => this.loadItems(),
        error: (err) => console.error('Delete failed:', err)
      });
    }
    // const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
    //   data: {
    //     title: 'Confirm Delete',
    //     message: `Are you sure you want to delete ${item.itemType} (${item.serialNumber})?`
    //   }
    // });

    // dialogRef.afterClosed().subscribe(confirmed => {
    //   if (confirmed) {
    //     this.transitService.deleteItem(item.model1Id).subscribe({
    //       next: () => this.loadItems(),
    //       error: (err) => console.error('Delete failed:', err)
    //     });
    //   }
    // });
  }

  onSearch() {
    if (!this.searchQuery) {
      this.filteredItems = [...this.receivedItems]; // Reset to full list if search is empty
    } else {
      const query = this.searchQuery.toLowerCase();
      this.filteredItems = this.receivedItems.filter(item =>
        item.supplier.toLowerCase().includes(query) ||
        item.itemType.toLowerCase().includes(query) ||
        item.serialNumber.toLowerCase().includes(query) ||
        (item.status ?? '').toLowerCase().includes(query)
      );
    }
    this.currentPage = 1; // Reset to the first page after search
    this.updatePagination(); // Update pagination
  }

  onSortChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    this.selectedSort = selectElement.value;
    this.sortItems(this.selectedSort);
    this.updatePagination(); // Update pagination after sorting
  }


  sortItems(sortBy: string) {
    switch (sortBy) {
      case 'supplier':
        this.filteredItems.sort((a, b) => a.supplier.localeCompare(b.supplier));
        break;
      case 'itemType':
        this.filteredItems.sort((a, b) => a.itemType.localeCompare(b.itemType));
        break;
      case 'status':
        this.filteredItems.sort((a, b) => (b.status || '').localeCompare(a.status || ''));
        break;
      case 'date':
        this.filteredItems.sort((a, b) => new Date(b.date).getTime() - new Date(a.date).getTime());
        break;
      default:
        break;
    }
    this.updatePagination(); // Update pagination after sorting
  }

  updatePagination() {
    this.totalPages = Math.ceil(this.filteredItems.length / this.itemsPerPage);
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    const endIndex = startIndex + this.itemsPerPage;
    this.paginatedItems = this.filteredItems.slice(startIndex, endIndex);
  }

  onPageChange(page: number) {
    this.currentPage = page;
    this.updatePagination();
  }

  getPageNumbers(): number[] {
    const pages = [];
    for (let i = 1; i <= this.totalPages; i++) {
      pages.push(i);
    }
    return pages;
  }

  onItemsPerPageChange() {
    this.currentPage = 1; // Reset to the first page
    this.updatePagination(); // Update pagination
  }
}
