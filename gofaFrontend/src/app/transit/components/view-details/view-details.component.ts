// view-details.component.ts
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TransitService } from '../../services/transit.service';
import { Item } from '../../models/item.model';

@Component({
  selector: 'app-view-details',
  templateUrl: './view-details.component.html',
  styleUrls: ['./view-details.component.css']
})
export class ViewDetailsComponent implements OnInit {
  item: Item | null = null; // Initialize as null
  isLoading = true; // Track loading state
  errorMessage: string | null = null; // Track errors

  constructor(
    private route: ActivatedRoute,
    private transitService: TransitService
  ) {}

  ngOnInit() {
    const itemId = this.route.snapshot.paramMap.get('id')!; // Use non-null assertion
    this.loadItemDetails(itemId);
  }

  loadItemDetails(itemId: string) {
    this.isLoading = true;
    this.errorMessage = null;

    this.transitService.getItemById(itemId).subscribe({
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
