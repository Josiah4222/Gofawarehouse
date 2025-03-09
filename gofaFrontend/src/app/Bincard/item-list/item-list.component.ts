import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.css']
})
export class ItemListComponent implements OnInit {
  registeredItems: any[] = [];
  filteredItems: any[] = [];
  isLoading = true;
  searchQuery = ''; // Search query variable

  // Fields available for filtering
  filterFields = [
    { key: 'modelNumber', label: 'በሞዴል ቁጥር' },
    { key: 'serialNumber', label: 'ሴሪያል ቁጥር' },
    { key: 'condition', label: 'በሁኔታ' },
    { key: 'itemName', label: 'በእቃው ስም' },
    { key: 'itemCategory', label: 'በእቃው ምድብ' },
    { key: 'itemType', label: 'በእቃው አይነት' }
  ];

  // Selected filter fields
  searchFields: { [key: string]: boolean } = {
    modelNumber: false,
    serialNumber: false,
    condition: false,
    itemName: false,
    itemCategory: false,
    itemType: false
  };

  constructor(private router: Router) {}

  ngOnInit() {
    this.fetchItems();
  }

  /**
   * Fetches all registered items from localStorage.
   */
  fetchItems(): void {
    this.isLoading = true;
    const storedItems = localStorage.getItem('registeredItems'); // Fetch from registeredItems
    if (storedItems) {
      this.registeredItems = JSON.parse(storedItems);
      this.registeredItems.forEach(item => {
        // Initialize missing quantity fields
        item.quantity = item.quantity || 0;
        item.addedQuantity = item.addedQuantity || 0;
        item.withdrawnQuantity = item.withdrawnQuantity || 0;
      });
      this.filteredItems = [...this.registeredItems]; // Initialize filtered items
    } else {
      this.registeredItems = [];
      this.filteredItems = [];
    }
    this.isLoading = false;
  }
  /**
   * Filters the item list based on the search query and selected checkboxes.
   */
  filterItems(): void {
    if (!this.searchQuery.trim()) {
      this.filteredItems = [...this.registeredItems]; // Reset if search is empty
      return;
    }

    const selectedFields = Object.keys(this.searchFields).filter(
      (field) => this.searchFields[field]
    );

    if (selectedFields.length === 0) {
      this.filteredItems = [...this.registeredItems]; // Reset if no checkboxes are selected
      return;
    }

    this.filteredItems = this.registeredItems.filter((item) =>
      selectedFields.some((field) =>
        item[field]?.toString().toLowerCase().includes(this.searchQuery.toLowerCase())
      )
    );
  }

  /**
   * Opens the item detail page for the selected item.
   */
  openItemDetail(item: any): void {
    this.router.navigate(['/item-detail', item.itemCode], { state: { item } });
  }

  /**
   * Opens the add quantity form for the selected item.
   */
  openAddQuantity(item: any): void {
    this.router.navigate(['/add-quantity', item.itemCode], { state: { item } });
  }

  /**
   * Opens the withdraw quantity form for the selected item.
   */
  openWithdrawQuantity(item: any): void {
    this.router.navigate(['/withdraw-quantity', item.itemCode], { state: { item } });
  }

  /**
   * Deletes the selected item.
   */
  deleteItem(item: any): void {
    if (confirm(`እርግጠኛ እንደገና ይህ "${item.itemName}" እቃ መሰረት እንደሚሰራ እውነት ነው?`)) {
      const storedItems = localStorage.getItem('registeredItems');
      if (storedItems) {
        const items = JSON.parse(storedItems);
        const updatedItems = items.filter((i: { itemCode: any }) => i.itemCode !== item.itemCode);
        localStorage.setItem('registeredItems', JSON.stringify(updatedItems));
        this.fetchItems(); // Refresh the list after deletion
      }
    }
  }

  /**
   * Clears the search query and resets the filter.
   */
  clearSearch(): void {
    this.searchQuery = ''; // Clear the search query
    this.searchFields = {
      modelNumber: false,
      serialNumber: false,
      condition: false,
      itemName: false,
      itemCategory: false,
      itemType: false
    }; // Reset selected checkboxes
    this.filterItems(); // Reset the filter
  }

  /**
   * Calculate the balance for an item.
   */
  calculateBalance(item: any): number {
    return item.quantity + item.addedQuantity - item.withdrawnQuantity;
  }
}
