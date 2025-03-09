import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-item-detail',
  templateUrl: './item-detail.component.html',
  styleUrls: ['./item-detail.component.css']
})
export class ItemDetailComponent implements OnInit {
  item: any = {}; // Object to store the item details
  isLoading = true; // Loading state

  currentPage = 1; // Current page of transactions
  pageSize = 5; // Number of transactions per page
  totalPages: number = 0; // Total number of pages

  constructor(private router: Router, private route: ActivatedRoute) {}

  ngOnInit() {
    const itemCode = this.route.snapshot.paramMap.get('itemCode'); // Get itemCode from the route
    if (itemCode) {
      this.fetchItem(itemCode); // Fetch item using itemCode
    } else {
      alert('Item code is missing. Please try again.');
      this.router.navigate(['/items']);
    }
  }

  /**
   * Fetches the item details from localStorage.
   * @param itemCode - The code of the item to fetch.
   */
  fetchItem(itemCode: string): void {
    this.isLoading = true; // Show the loading spinner
    const storedItems = localStorage.getItem('registeredItems');
    
    // Check if there are any items in localStorage
    if (!storedItems) {
      alert('No items found in storage.');
      this.router.navigate(['/items']); // Navigate to the item list page
      return;
    }
  
    const items = JSON.parse(storedItems);
    
    // Check if the array is empty or undefined
    if (!items || items.length === 0) {
      alert('No items found.');
      this.router.navigate(['/items']); // Navigate back if there are no items
      return;
    }
  
    // Find the specific item based on the itemCode
    this.item = items.find((item: { itemCode: string }) => item.itemCode === itemCode);
  
    // If the item is found, update the UI
    if (this.item) {
      console.log('Found Item:', this.item);
      this.totalPages = Math.ceil((this.item.transactionHistory?.length || 0) / this.pageSize); // Calculate the total pages for pagination
      this.isLoading = false; // Hide the loading spinner
    } else {
      // Handle the case when the item is not found
      alert(`Item with code "${itemCode}" not found.`);
      this.router.navigate(['/items']); // Navigate back to the item list page
    }
  }
  
  /**
   * Formats a date string into a readable format.
   * @param dateStr - The date string (e.g., ISO format).
   * @returns Formatted date string (e.g., "Oct 5, 2023").
   */
  formatDate(dateStr: string): string {
    if (!dateStr) return '';
    const date = new Date(dateStr);
    return date.toLocaleDateString('en-US', {
      year: 'numeric',
      month: 'short',
      day: 'numeric'
    });
  }

  /**
   * Extracts a specific value from the transaction details string.
   * @param details - The details string (e.g., "comaAnedeTeqebale: Supplier A, ymezegebew: User B").
   * @param key - The key to extract (e.g., "comaAnedeTeqebale", "ymezegebew", "recipient", "withdrawalDate").
   * @returns The extracted value or an empty string if not found.
   */
  getDetailValue(details: string, key: string): string {
    if (!details) return '';
    const regex = new RegExp(`${key}:\\s*([^,]+)`); // Match the key and its value
    const match = details.match(regex);
    return match ? match[1].trim() : ''; // Return the matched value or an empty string
  }

  /**
   * Gets the transactions for the current page.
   * @returns A subset of transactions for the current page.
   */
  getPaginatedTransactions(): any[] {
    if (!this.item.transactionHistory) return [];
    const startIndex = (this.currentPage - 1) * this.pageSize;
    const endIndex = startIndex + this.pageSize;
    return this.item.transactionHistory.slice(startIndex, endIndex);
  }

  /**
   * Navigates to the previous page.
   */
  prevPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
    }
  }

  /**
   * Navigates to the next page.
   */
  nextPage(): void {
    if (this.currentPage < this.totalPages) {
      this.currentPage++;
    }
  }

  /**
   * Navigates back to the item list page.
   */
  goBack(): void {
    this.router.navigate(['/items']);
  }
}