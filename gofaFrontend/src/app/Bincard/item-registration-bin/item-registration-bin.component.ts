import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ItemService } from '../../services/item-service.service';
import { ShelfService } from '../../services/shelf.service';
import { WarehouseService } from '../../services/warehouse-service.service';
import { Item } from '../../model/item.model';
import { Shelf } from '../../model/shelf.model';
import { Warehouse } from '../../model/warehouse.model';
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
  warehouses: Warehouse[] = [];
  shelves: Shelf[] = [];
  selectedWarehouseId: string | null = null;

  constructor(
    private fb: FormBuilder,
    private itemService: ItemService,
    private shelfService: ShelfService,
    private warehouseService: WarehouseService
  ) {}

  ngOnInit(): void {
    this.itemForm = this.fb.group({
      name: ['', Validators.required],
      serialNumber: ['', Validators.required],
      description: [''],
      location: ['', Validators.required],
      voucherNumber: [''],
      receivedFrom: [''],
      condition: ['', Validators.required],
      quantity: [1, [Validators.required, Validators.min(1)]],
      numOfBox: [1, [Validators.required, Validators.min(1)]],
      registeredBy: ['', Validators.required],
      itemType: ['', Validators.required],
      shelfId: ['', Validators.required],
    });

    this.loadWarehouses();
    this.loadShelves();
  }

  loadWarehouses() {
    this.warehouseService.getWarehouses().subscribe({
      next: (warehouses) => {
        this.warehouses = warehouses;
        console.log('Warehouses loaded:', warehouses);
      },
      error: (err) => console.error('Error loading warehouses:', err),
    });
  }

  loadShelves() {
    this.shelfService.getShelves().subscribe({
      next: (shelves) => {
        this.shelves = shelves;
        console.log('Shelves loaded:', shelves);
      },
      error: (err) => console.error('Error loading shelves:', err),
    });
  }

  onWarehouseChange(warehouseId: string) {
    this.selectedWarehouseId = warehouseId || null;
  }

  get filteredShelves(): Shelf[] {
    if (!this.selectedWarehouseId) return this.shelves;
    return this.shelves.filter((shelf) => shelf.warehouse.warehouseId === this.selectedWarehouseId);
  }

  onSubmit(): void {
    console.log('Form Validity:', this.itemForm.valid);
    console.log('Form Errors:', this.itemForm.errors);

    // Log errors for each form control
    Object.keys(this.itemForm.controls).forEach((key) => {
      const control = this.itemForm.get(key);
      if (control?.invalid) {
        console.log(`Control: ${key}, Errors:`, control.errors);
      }
    });

    if (this.itemForm.invalid) {
      console.error('Form is invalid. Please check the fields.');
      return;
    }

    const formValue = this.itemForm.value;
    const newItem: Item = {
      name: formValue.name,
      serialNumber: formValue.serialNumber,
      description: formValue.description || null,
      location: formValue.location,
      voucherNumber: formValue.voucherNumber || null,
      receivedFrom: formValue.receivedFrom || null,
      condition: formValue.condition,
      quantity: formValue.quantity,
      numOfBox: formValue.numOfBox,
      registeredBy: formValue.registeredBy,
      itemType: formValue.itemType,
      shelfId: formValue.shelfId,
    };

    console.log('Payload:', newItem); // Log the payload

    this.itemService.registerItem(newItem).subscribe({
      next: (response: Item) => {
        console.log('API Response:', response); // Log the API response
        this.successMessage = 'Item registered successfully!';
        this.errorMessage = '';
        this.itemForm.reset(); // Reset the form
      },
      error: (error: HttpErrorResponse) => {
        console.error('API Error:', error); // Log the API error
        this.errorMessage = 'Failed to register item. Please try again.';
      },
    });
  }
}