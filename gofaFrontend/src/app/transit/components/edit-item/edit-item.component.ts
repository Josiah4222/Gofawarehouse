
// // import { Component, Inject } from '@angular/core';
// // import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
// // import { FormBuilder, FormGroup, Validators } from '@angular/forms';
// // import { Item } from '../../models/item.model';

// // @Component({
// //   selector: 'app-edit-item',
// //   templateUrl: './edit-item.component.html',
// //   styleUrl: './edit-item.component.css',
// // })
// // export class EditItemComponent {
// //   editForm: FormGroup;

// //   constructor(
// //     private fb: FormBuilder,
// //     public dialogRef: MatDialogRef<EditItemComponent>,
// //     @Inject(MAT_DIALOG_DATA) public data: { item: Item }
// //   ) {
// //     this.editForm = this.fb.group({
// //       Supplier: [data.item.Supplier, Validators.required],
// //       ItemType: [data.item.ItemType, Validators.required],
// //       SerialNumber: [data.item.SerialNumber, Validators.required],
// //       Status: [data.item.Status]
// //     });
// //   }

// //   saveChanges() {
// //     if (this.editForm.valid) {
// //       this.dialogRef.close(this.editForm.value);
// //     }
// //   }
// // }


// import { Component, OnInit } from '@angular/core';
// import { FormBuilder, FormGroup, Validators } from '@angular/forms';
// import { ActivatedRoute, Router } from '@angular/router';
// import { TransitService } from '../../services/transit.service';
// import { Item } from '../../models/item.model';

// @Component({
//   selector: 'app-edit-item',
//   templateUrl: './edit-item.component.html',
//   styleUrls: ['./edit-item.component.css']
// })
// export class EditItemComponent implements OnInit {
//   editForm!: FormGroup;
//   itemId!: number;


//   constructor(
//     private fb: FormBuilder,
//     private route: ActivatedRoute,
//     public router: Router,
//     private transitService: TransitService
//   ) {}

//   ngOnInit() {
//     this.itemId = +this.route.snapshot.paramMap.get('id')!;
//     this.initializeForm();
//     this.loadItem();
//   }

//   initializeForm() {
//     this.editForm = this.fb.group({
//       Supplier: ['', Validators.required],
//       Category: ['', Validators.required],
//       PRNO: ['', Validators.required],
//       Date: ['', Validators.required],
//       // Add all other form controls matching your model
//       // ...
//       AuthorizedByName: ['', Validators.required]
//     });
//   }

//   loadItem() {
//     this.transitService.getItemById(this.itemId).subscribe(item => {
//       this.editForm.patchValue(item);
//       // If you need to handle date formatting:
//       if(item.Date) {
//         this.editForm.patchValue({
//           Date: new Date(item.Date).toISOString().substring(0,10)
//         });
//       }
//     });
//   }


//   onSubmit() {
//     if (this.editForm.valid) {
//       this.transitService.updateItem(this.itemId, this.editForm.value)
//         .subscribe(() => {
//           this.router.navigate(['/received-items']);
//         });
//     }
//   }
// }


import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TransitService } from '../../services/transit.service';
import { Item } from '../../models/item.model';

@Component({
  selector: 'app-edit-item',
  templateUrl: './edit-item.component.html',
  styleUrls: ['./edit-item.component.css']
})
export class EditItemComponent implements OnInit {
  editForm! : FormGroup;
  itemId! : string;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    public router: Router,
    private transitService: TransitService
  ) {
    this.initializeForm();
  }

  ngOnInit() {
    this.itemId = this.route.snapshot.paramMap.get('id')!;
    if (this.itemId) {
      this.loadItemData(this.itemId);
    } else {
      console.error('Item ID is missing!');
    }
  }
  // ngOnInit() {
  //   const itemId = this.route.snapshot.paramMap.get('id')!; // Use non-null assertion
  //   this.loadItemDetails(itemId);
  // }

  private initializeForm() {
    this.editForm = this.fb.group({
      Supplier: ['', Validators.required],
      Model1Id: ['', Validators.required],
      ItemType: ['', Validators.required],
      SerialNumber: ['', Validators.required],


      Category: ['', Validators.required],
      PRNO: ['', Validators.required],
      Date: ['', Validators.required],
      InvoiceNo: ['', Validators.required],

      ContactNumber: ['', Validators.required],
      Number: ['', Validators.required],
      RegisteredBy: ['', Validators.required],

      Description: ['', Validators.required],
      UnitOfMeasurment: ['', Validators.required],
      Quality: ['', Validators.required],
      UnitOfPrice: ['', Validators.required],
      Amount: [0, [Validators.required, Validators.min(0)]],
      Location: ['', Validators.required],
      Remark: [''],
      checkedByName: ['', Validators.required],
      RecivedByName: ['', Validators.required],
      AuthorizedByName: ['', Validators.required],
      Status: ['Pending Inspection', Validators.required]
    });
  }

  // private getItemId() {
  //   this.route.paramMap.subscribe(params => {
  //     this.itemId = +(params.get('id')!);
  //   });
  // }

  private loadItemData(itemId: string) {
    this.transitService.getItemById(itemId).subscribe({
      next: (item) => {
        this.patchFormValues(item);
        const formattedDate = this.formatDate(item.date);
        this.editForm.patchValue({ ...item, Date: formattedDate });
      },
      error: (err) => console.error('Error loading item:', err)
    });
  }


  private formatDate(date: Date | string): string {
    const d = new Date(date);
    const year = d.getFullYear();
    const month = ('0' + (d.getMonth() + 1)).slice(-2);
    const day = ('0' + d.getDate()).slice(-2);
    return `${year}-${month}-${day}`;
  }


  private patchFormValues(item: Item) {
    this.editForm.patchValue({
      Supplier: item.supplier,
      Model1Id: item.model1Id,
      ItemType: item.itemType,
      SerialNumber: item.serialNumber,
      Status: item.status,
      Category: item.category,
      PRNO: item.prno,
      date: item.date,
      InvoiceNo: item.invoiceNo,

      ContactNumber: item.contactNumber,
      Number: item.number,
      RegisteredBy: item.registeredBy,

      Description: item.description,
      UnitOfMeasurment: item.unitOfMeasurment,
      Quality: item.quality,
      UnitOfPrice: item.unitOfPrice,
      Amount: item.amount,
      Location: item.location,
      Remark: item.remark,
      checkedByName: item.checkedByName,
      RecivedByName: item.recivedByName,
      AuthorizedByName: item.authorizedByName,
    });
  }

  onSubmit(id: string) {
    if (this.editForm.valid) {
      this.transitService.updateItem(id, this.editForm.value)
        .subscribe({
          next: () => this.router.navigate(['/transit/received-items']),
          error: (err) => console.error('Update failed:', err)
        });
    }
  }


}
