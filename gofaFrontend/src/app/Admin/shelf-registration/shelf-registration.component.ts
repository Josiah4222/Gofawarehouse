// shelf-registration.component.ts
import { Component, OnInit } from '@angular/core';
import { ShelfService, Shelf } from '../../services/shelf.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-shelf-registration',
  templateUrl: './shelf-registration.component.html',
  styleUrls: ['./shelf-registration.component.css']
})
export class ShelfRegistrationComponent implements OnInit {
  shelfForm: FormGroup;
  warehouses: any[] = [];
  errorMessage: string = '';
  successMessage: string = '';

  constructor(
    private shelfService: ShelfService,
    private fb: FormBuilder
  ) {
    this.shelfForm = this.fb.group({
      name: ['', Validators.required],
      column: ['', Validators.required],
      row: ['', Validators.required],
      warehouseName: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.loadWarehouses();
  }

  loadWarehouses(): void {
    this.shelfService.getWarehouses().subscribe({
      next: (warehouses: any[]) => {
        this.warehouses = warehouses;
      },
      error: (error: any) => {
        this.errorMessage = 'Failed to load warehouses';
        console.error(error);
      }
    });
  }

  onSubmit(): void {
    if (this.shelfForm.valid) {
      const shelf: Shelf = this.shelfForm.value;
      
      this.shelfService.createShelf(shelf).subscribe({
        next: (response: any) => {
          this.successMessage = 'Shelf registered successfully';
          this.errorMessage = '';
          this.shelfForm.reset();
        },
        error: (error: any) => {
          this.errorMessage = 'Failed to register shelf';
          this.successMessage = '';
          console.error(error);
        }
      });
    }
  }
}