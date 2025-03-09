import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-withdraw-item-quantity',
  templateUrl: './withdraw-item-quantity.component.html',
  styleUrls: ['./withdraw-item-quantity.component.css']
})
export class WithdrawItemQuantityComponent implements OnInit {
  item: any = {};
  withdrawalDetails = {
    withdrawnQuantity: 0, // Quantity to withdraw
    recipient: '', // Recipient information
    boxCount: 0, // Number of boxes
    withdrawalDate: '' // Date of withdrawal
  };

  isSubmitting = false; // Add a loading state

  constructor(
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    // Retrieve the item from the route state
    this.item = history.state.item || {};
    this.withdrawalDetails.withdrawalDate = new Date().toISOString().split('T')[0]; // Set default date to today
  }

  onSubmit() {
    if (
      this.withdrawalDetails.withdrawnQuantity <= 0 ||
      !this.withdrawalDetails.recipient ||
      this.withdrawalDetails.boxCount < 0 ||
      !this.withdrawalDetails.withdrawalDate
    ) {
      alert('እባክዎን የተ纛ሮነው አይነት ቅጠል ተጫዋል.');
      return;
    }

    const currentQuantity = this.item.quantity || 0;

    // Ensure the user cannot withdraw more than the available quantity
    if (this.withdrawalDetails.withdrawnQuantity > currentQuantity) {
      alert('የአስተካክለብት ብዛት የተገበረው ብዛት ምላሽ ነው።');
      return;
    }

    // Calculate the updated quantity after withdrawal
    const updatedQuantity = currentQuantity - this.withdrawalDetails.withdrawnQuantity;

    // Create a new transaction entry for the withdrawal
    const transactionEntry = {
      date: this.withdrawalDetails.withdrawalDate, // Use the specified withdrawal date
      action: 'withdraw', // Action type
      quantity: this.withdrawalDetails.withdrawnQuantity, // Quantity withdrawn
      details: `Recipient: ${this.withdrawalDetails.recipient}, Boxes: ${this.withdrawalDetails.boxCount}`
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
