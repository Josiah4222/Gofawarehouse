import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-add-item-quantity',
  templateUrl: './add-item-quantity.component.html',
  styleUrls: ['./add-item-quantity.component.css']
})
export class AddItemQuantityComponent implements OnInit {
  item: any = {};
  itemDetails = {
    comaAnedeTeqebale: '', // Additional detail for adding quantity
    yegibiBzat: 0, // Quantity to add
    ymezegebew: '', // Additional detail for adding quantity
    receiptDate: '' // Date of receipt
  };

  isSubmitting = false; // Add a loading state

  constructor(
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    // Retrieve the item from the route state
    this.item = history.state.item || {};

    // Set the default receipt date to today
    const today = new Date();
    this.itemDetails.receiptDate = today.toISOString().split('T')[0];
  }

  onSubmit() {
    if (!this.itemDetails.comaAnedeTeqebale || this.itemDetails.yegibiBzat <= 0 || !this.itemDetails.ymezegebew || !this.itemDetails.receiptDate) {
      alert('እባክዎን የተዛረበነው አይነት ቅጠል ተጫዋል.');
      return;
    }

    // Calculate the updated quantity by adding the existing quantity (if any)
    const currentQuantity = this.item.quantity || 0; // Default to 0 if no quantity exists
    const updatedQuantity = currentQuantity + this.itemDetails.yegibiBzat;

    // Create a new transaction entry
    const transactionEntry = {
      date: this.itemDetails.receiptDate, // Use the specified receipt date
      action: 'add', // Action type (e.g., add, remove, etc.)
      quantity: this.itemDetails.yegibiBzat, // Quantity added
      details: `comaAnedeTeqebale: ${this.itemDetails.comaAnedeTeqebale}, ymezegebew: ${this.itemDetails.ymezegebew}` // Details string
    };

    // Update the existing item with the new details and total quantity
    const updatedItem = {
      ...this.item,
      quantity: updatedQuantity, // Set the updated quantity
      transactionHistory: [
        ...(this.item.transactionHistory || []), // Preserve existing history
        transactionEntry // Add the new transaction
      ]
    };

    this.isSubmitting = true; // Set loading state

    // Update the item in localStorage
    this.updateItemInLocalStorage(updatedItem);

    this.isSubmitting = false; // Reset loading state
    this.router.navigate(['/items']); // Navigate back to the item list page
  }

  updateItemInLocalStorage(updatedItem: any) {
    const storedItems = localStorage.getItem('registeredItems');
    if (storedItems) {
      const items = JSON.parse(storedItems);
      const updatedItems = items.map((item: { itemCode: any; }) =>
        item.itemCode === updatedItem.itemCode ? updatedItem : item
      );
      localStorage.setItem('registeredItems', JSON.stringify(updatedItems));
    }
  }

  cancel() {
    this.router.navigate(['/items']);
  }
}
