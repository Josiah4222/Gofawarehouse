import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TransitService } from '../../services/transit.service';
import { Item } from '../../models/item.model';

@Component({
  selector: 'app-receive-item-form',
  templateUrl: './receive-item-form.component.html',
  styleUrl: './receive-item-form.component.css'
})
export class ReceiveItemFormComponent {
  receiveForm: FormGroup;

  constructor(private fb: FormBuilder, private transitService: TransitService) {
    this.receiveForm = this.fb.group({
      supplier: ['', Validators.required],
      category: ['', Validators.required],
      // model1Id: ['', Validators.required],
      status: ['', Validators.required],
      prno: ['', Validators.required],
      date: ['', Validators.required],
      invoiceNo: ['', Validators.required],
      itemType: ['', Validators.required],
      contactNumber: ['', Validators.required],
      number: ['', Validators.required],
      registeredBy: ['', Validators.required],
      serialNumber: ['', Validators.required],
      description: ['', Validators.required],
      unitOfMeasurment: ['', Validators.required],
      quality: ['', Validators.required],
      unitOfPrice: ['', Validators.required],
      amount: ['', Validators.required],
      location: ['', Validators.required],
      remark: [''],
      checkedByName: ['', Validators.required],
      recivedByName: ['', Validators.required],
      authorizedByName: ['', Validators.required],
    });
  }

  onSubmit() {
    if (this.receiveForm.valid) {
      const newItem: Item = this.receiveForm.value;
      console.log(newItem);
      this.transitService.sendToInspection(newItem).subscribe((response) => {
        console.log('Item received and sent for inspection:', response);
      });
    }
  }
}
