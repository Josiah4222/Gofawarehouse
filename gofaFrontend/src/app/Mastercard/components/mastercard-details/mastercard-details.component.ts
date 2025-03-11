import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
// import { ItemService } from '../../services/item.service';
import { MasterCardService } from '../../../services/mastercard.service';

import { Item } from '../../models/mastercard.model';

@Component({
  selector: 'app-mastercard-details',
  templateUrl: './mastercard-details.component.html',
  styleUrl: './mastercard-details.component.css'
})
export class MastercardDetailsComponent implements OnInit {
  item: Item | null = null; // Initialize as null
  isLoading = true; // Track loading state
  errorMessage: string | null = null; // Track errors

  constructor(
    private route: ActivatedRoute,
    private itemService: MasterCardService
  ) {}

  ngOnInit() {
    const itemId = this.route.snapshot.paramMap.get('id')!; // Use non-null assertion
    this.loadItemDetails(itemId);
  }

  loadItemDetails(itemId: string) {
    this.isLoading = true;
    this.errorMessage = null;

    this.itemService.getItemById(itemId).subscribe({
      next: (item) => {
        if (item) {
          this.item = item;
        } else {
          this.errorMessage = 'Item not found.'; // Handle case where item is undefined
        }
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Error loading item details:', err);
        this.errorMessage = 'Failed to load item details.'; // Handle errors
        this.isLoading = false;
      }
    });
  }

  printDetails() {
    window.print();
  }
}

