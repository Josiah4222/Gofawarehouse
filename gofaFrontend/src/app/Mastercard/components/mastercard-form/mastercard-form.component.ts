
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MasterCardService } from '../../../services/mastercard.service';

@Component({
  selector: 'app-mastercard-form',
  templateUrl: './mastercard-form.component.html',
  styleUrl: './mastercard-form.component.css',
})
export class MasterCardFormComponent {
  masterCardForm: FormGroup;

  constructor(private fb: FormBuilder, private masterCardService: MasterCardService) {
    this.masterCardForm = this.fb.group({
      // masterCardId: ['', Validators.required],
      model: ['', Validators.required],
      partNumber: ['', Validators.required],
      description: ['', Validators.required],
      uM: ['', Validators.required],
      inCHAb: ['', Validators.required],
      unitPack: ['', Validators.required],
      leadTime: ['', Validators.required],
      avgUsage: ['', Validators.required],
      ssl: ['', Validators.required],
      maxLevel: ['', Validators.required],
      recordPoint: ['', Validators.required],
      ved: ['', Validators.required],
      abc: ['', Validators.required],
      status: ['', Validators.required],
      orderTime: ['', Validators.required],
      location: ['', Validators.required],
      date: ['', Validators.required],
      orderNo: ['', Validators.required],
      consigning: ['', Validators.required],
      qytOrder: ['', Validators.required],
      qyt: ['', Validators.required],
      voucherNo: ['', Validators.required],
      received: ['', Validators.required],
      issued: ['', Validators.required],
      inStock: ['', Validators.required],
      unitPrice: ['', Validators.required],
      org: ['', Validators.required],
      postedBy: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.masterCardForm.valid) {
      const formData = this.masterCardForm.value;
      console.log('Form Data:', formData);

      this.masterCardService.saveMasterCard(formData).subscribe(response => {
        console.log('MasterCard data saved successfully:', response);
      }, error => {
        console.error('Error saving data:', error);
      });
    }
  }
}

