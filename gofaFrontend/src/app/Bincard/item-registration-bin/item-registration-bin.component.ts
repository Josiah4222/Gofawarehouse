import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ItemService } from '../../services/item-service.service';
import { Item } from '../../model/item.model';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-item-registration-bin',
  templateUrl: './item-registration-bin.component.html',
  styleUrls: ['./item-registration-bin.component.css'],
})
export class ItemRegistrationBinComponent implements OnInit {
  itemForm!: FormGroup;
  successMessage: string = '';
  errorMessage: string = '';

  constructor(
    private fb: FormBuilder,
    private itemService: ItemService
  ) {}

  ngOnInit(): void {
    this.itemForm = this.fb.group({
      name: ['', Validators.required],
      serialNumber: ['', Validators.required],
      description: [''],
      voucherNumber: [''],
      receivedFrom: [''],
      condition: ['', Validators.required],
      quantity: [1, [Validators.required, Validators.min(1)]],
      numOfBox: [1, [Validators.required, Validators.min(1)]],
      registeredBy: ['', Validators.required],
      itemType: ['', Validators.required],
      shelfName: [''] // Optional field
    });
  }

  onSubmit(): void {
    if (this.itemForm.invalid) {
      console.error('Form is invalid. Please check the fields.');
      return;
    }

    const formValue = this.itemForm.value;
    const newItem: Item = {
      name: formValue.name,
      serialNumber: formValue.serialNumber,
      description: formValue.description || null,
      voucherNumber: formValue.voucherNumber || null,
      receivedFrom: formValue.receivedFrom || null,
      condition: formValue.condition,
      quantity: formValue.quantity,
      numOfBox: formValue.numOfBox,
      registeredBy: formValue.registeredBy,
      itemType: formValue.itemType,
      shelfName: formValue.shelfName || null
    };

    this.itemService.registerItem(newItem).subscribe({
      next: (response: Item) => {
        this.successMessage = 'Item registered successfully!';
        this.errorMessage = '';
        this.itemForm.reset();
      },
      error: (error: HttpErrorResponse) => {
        console.error('API Error:', error);
        this.errorMessage = 'Failed to register item: ' + (error.error.errors ? JSON.stringify(error.error.errors) : error.message);
      },
    });
  }
}