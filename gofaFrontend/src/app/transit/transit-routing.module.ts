 // src/app/app-routing.module.ts
// import { NgModule } from '@angular/core';
// import { RouterModule, Routes } from '@angular/router';
// import { ReceivedItemsListComponent } from './components/received-items-list/received-items-list.component';
// import { SentForInspectionListComponent } from './components/sent-for-inspection-list/sent-for-inspection-list.component';
// import { InspectedItemsListComponent } from './components/inspected-items-list/inspected-items-list.component';
// import { SendToStoreFormComponent } from './components/send-to-store-form/send-to-store-form.component';

// const routes: Routes = [
//   { path: 'received-items', component: ReceivedItemsListComponent },
//   { path: 'sent-for-inspection', component: SentForInspectionListComponent },
//   { path: 'inspected-items', component: InspectedItemsListComponent },
//   { path: 'send-to-store', component: SendToStoreFormComponent },
//   { path: '', redirectTo: '/received-items', pathMatch: 'full' },
// ];

// @NgModule({
//   imports: [RouterModule.forRoot(routes)],
//   exports: [RouterModule],
// })
// export class AppRoutingModule {}



import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ReceiveItemFormComponent } from './components/receive-item-form/receive-item-form.component';
import { ReceivedItemsListComponent } from './components/received-items-list/received-items-list.component';
import { SentForInspectionListComponent } from './components/sent-for-inspection-list/sent-for-inspection-list.component';
import { InspectedItemsListComponent } from './components/inspected-items-list/inspected-items-list.component';
import { SendToStoreFormComponent } from './components/send-to-store-form/send-to-store-form.component';
import { EditItemComponent } from './components/edit-item/edit-item.component';
import { ViewDetailsComponent } from './components/view-details/view-details.component';

import { Model19ListComponent } from './components/model19-list/model19-list.component';




const routes: Routes = [
  { path: 'receive-item-form', component: ReceiveItemFormComponent },
  { path: '', component: ReceivedItemsListComponent },
  { path: 'sent-for-inspection', component: SentForInspectionListComponent },
  { path: 'inspected-items', component: InspectedItemsListComponent },
  { path: 'send-to-store', component: SendToStoreFormComponent },
  { path: '', redirectTo: '', pathMatch: 'full' },
  { path: 'edit-item/:id', component: EditItemComponent },
  {path: 'view-details/:id', component: ViewDetailsComponent },

  { path: 'model19-list', component: Model19ListComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class TransitRoutingModule { }

