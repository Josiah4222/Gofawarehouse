import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ItemService } from '../../services/item-service.service';
import { Item } from '../../model/item.model';

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.css']
})
export class ItemListComponent implements OnInit {
  registeredItems: Item[] = [];
  filteredItems: Item[] = [];
  isLoading = true;
  searchQuery = '';

  filterFields = [
    { key: 'name', label: 'በእቃው ስም' },
    { key: 'shelfName', label: 'በምድብ' },
    { key: 'itemType', label: 'በእቃው አይነት' },
    { key: 'description', label: 'በሞዴል ቁጥር' },
    { key: 'serialNumber', label: 'ሴሪያል ቁጥር' },
    { key: 'condition', label: 'በሁኔታ' }
  ];

  searchFields: { [key: string]: boolean } = {
    name: false,
    shelfName: false,
    itemType: false,
    description: false,
    serialNumber: false,
    condition: false
  };

  constructor(
    private router: Router,
    private itemService: ItemService
  ) {}

  ngOnInit() {
    this.fetchItems();
  }

  fetchItems(): void {
    this.isLoading = true;
    this.itemService.getItems().subscribe({
      next: (items) => {
        this.registeredItems = items;
        this.filteredItems = [...this.registeredItems];
        this.isLoading = false;
      },
      error: (error) => {
        console.error('Error fetching items:', error);
        this.isLoading = false;
      }
    });
  }

  filterItems(): void {
    if (!this.searchQuery.trim()) {
      this.filteredItems = [...this.registeredItems];
      return;
    }

    const selectedFields = Object.keys(this.searchFields).filter(
      (field) => this.searchFields[field]
    );

    if (selectedFields.length === 0) {
      this.filteredItems = [...this.registeredItems];
      return;
    }

    this.filteredItems = this.registeredItems.filter((item) =>
      selectedFields.some((field) =>
        item[field as keyof Item]?.toString().toLowerCase().includes(this.searchQuery.toLowerCase())
      )
    );
  }

  openItemDetail(item: Item): void {
    this.router.navigate(['/item-detail', item.itemId], { state: { item } });
  }

  openAddQuantity(item: Item): void {
    this.router.navigate(['/add-quantity', item.itemId], { state: { item } });
  }

  openWithdrawQuantity(item: Item): void {
    this.router.navigate(['/withdraw-quantity', item.itemId], { state: { item } });
  }

  deleteItem(item: Item): void {
    if (confirm(`እርግጠኛ እንደሆኑ ይህን "${item.name}" እቃ መሰረት ይፈልጋሉ?`)) {
      this.itemService.deleteItem(item.itemId!).subscribe({
        next: () => {
          this.registeredItems = this.registeredItems.filter(i => i.itemId !== item.itemId);
          this.filterItems();
        },
        error: (error) => console.error('Error deleting item:', error)
      });
    }
  }

  clearSearch(): void {
    this.searchQuery = '';
    this.searchFields = {
      name: false,
      shelfName: false,
      itemType: false,
      description: false,
      serialNumber: false,
      condition: false
    };
    this.filterItems();
  }

  calculateBalance(item: Item): number {
    return item.quantity; // For now, just use initial quantity
  }
}