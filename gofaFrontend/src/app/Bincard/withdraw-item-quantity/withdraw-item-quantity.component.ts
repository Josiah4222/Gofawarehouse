import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ItemService } from '../../services/item-service.service';
import { Item } from '../../model/item.model';

@Component({
  selector: 'app-withdraw-item-quantity',
  templateUrl: './withdraw-item-quantity.component.html',
  styleUrls: ['./withdraw-item-quantity.component.css']
})
export class WithdrawItemQuantityComponent implements OnInit {
  item: Item | undefined;
  withdrawForm: FormGroup;
  isSubmitting = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder,
    private itemService: ItemService
  ) {
    this.withdrawForm = this.fb.group({
      withdrawnQuantity: [0, [Validators.required, Validators.min(1)]],
      recipient: ['', Validators.required],
      boxCount: [0, [Validators.required, Validators.min(0)]],
      withdrawalDate: [new Date().toISOString().split('T')[0], Validators.required]
    });
  }

  ngOnInit(): void {
    const itemId = Number(this.route.snapshot.paramMap.get('id'));
    this.item = history.state.item;
    if (!this.item) {
      this.itemService.getItemById(itemId).subscribe({
        next: (item) => this.item = item,
        error: (error) => console.error('Error fetching item:', error)
      });
    }
  }

  onSubmit(): void {
    if (this.withdrawForm.invalid || !this.item) {
      this.withdrawForm.markAllAsTouched();
      return;
    }

    this.isSubmitting = true;
    const { withdrawnQuantity, recipient, boxCount, withdrawalDate } = this.withdrawForm.value;
    const currentQuantity = this.item.quantity || 0;

    if (withdrawnQuantity > currentQuantity) {
      alert('የሚወጣው ብዛት ከአሁኑ ብዛት መብለጥ አይችልም።');
      this.isSubmitting = false;
      return;
    }

    const updatedQuantity = currentQuantity - withdrawnQuantity;
    const updatedDescription = `${this.item.description || ''} | Withdrawn on ${withdrawalDate}: ${recipient}, Boxes: ${boxCount}`;

    const updatedItem: Item = {
      ...this.item,
      quantity: updatedQuantity,
      description: updatedDescription // Temporary until transaction table is added
    };

    this.itemService.updateItem(this.item.itemId!, updatedItem).subscribe({
      next: () => {
        this.isSubmitting = false;
        this.router.navigate(['/registered-items']);
      },
      error: (error) => {
        console.error('Error withdrawing quantity:', error);
        this.isSubmitting = false;
      }
    });
  }

  cancel(): void {
    this.router.navigate(['/registered-items']);
  }
}