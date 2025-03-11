import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ItemService } from '../../services/item-service.service';
import { Item, Transaction } from '../../model/item.model';

@Component({
  selector: 'app-add-item-quantity',
  templateUrl: './add-item-quantity.component.html',
  styleUrls: ['./add-item-quantity.component.css'],
})
export class AddItemQuantityComponent implements OnInit {
  item: Item | undefined;
  addForm: FormGroup;
  isSubmitting = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder,
    private itemService: ItemService
  ) {
    this.addForm = this.fb.group({
      comaAnedeTeqebale: ['', Validators.required],
      yegibiBzat: [0, [Validators.required, Validators.min(1)]],
      ymezegebew: ['', Validators.required],
      receiptDate: [new Date().toISOString().split('T')[0], Validators.required],
    });
  }

  ngOnInit(): void {
    const itemId = Number(this.route.snapshot.paramMap.get('id'));
    this.item = history.state.item;
    if (!this.item) {
      this.itemService.getItemById(itemId).subscribe({
        next: (item) => (this.item = item),
        error: (error) => console.error('Error fetching item:', error),
      });
    }
  }

  onSubmit(): void {
    if (this.addForm.invalid || !this.item) {
      this.addForm.markAllAsTouched();
      return;
    }
  
    this.isSubmitting = true;
    const { yegibiBzat, comaAnedeTeqebale, ymezegebew, receiptDate } = this.addForm.value;
  
    // Calculate the new quantity
    const updatedQuantity = (this.item.quantity || 0) + yegibiBzat;
  
    // Create the updated item object
    const updatedItem: Item = {
      itemId: this.item.itemId!,
      name: this.item.name || '',
      serialNumber: this.item.serialNumber || '',
      description: this.item.description || '',
      voucherNumber: this.item.voucherNumber || '',
      receivedFrom: this.item.receivedFrom || '',
      condition: this.item.condition || '',
      quantity: updatedQuantity,
      numOfBox: this.item.numOfBox || 0,
      registeredBy: this.item.registeredBy || '',
      itemType: this.item.itemType || '',
      shelfName: this.item.shelfName || '',
    };
  
    // Log the payload for debugging
    console.log('Payload being sent:', updatedItem);
  
    // Update the item
    this.itemService.updateItem(this.item.itemId!, updatedItem).subscribe({
      next: () => {
        this.isSubmitting = false;
        this.router.navigate(['/registered-items']);
      },
      error: (error) => {
        console.error('Error adding quantity:', error);
        this.isSubmitting = false;
        alert('Failed to update item. Please check the input and try again.');
      },
    });
  }

  cancel(): void {
    this.router.navigate(['/registered-items']);
  }
}