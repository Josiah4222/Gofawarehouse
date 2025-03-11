import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ItemListComponent } from './Bincard/item-list/item-list.component';
import { ItemRegistrationBinComponent } from './Bincard/item-registration-bin/item-registration-bin.component';
import { AddItemQuantityComponent } from './Bincard/add-item-quantity/add-item-quantity.component';
import { WithdrawItemQuantityComponent } from './Bincard/withdraw-item-quantity/withdraw-item-quantity.component';

import { WarehouseComponent } from './Admin/warehouse/warehouse.component';
import { SendToStoreFormComponent } from './transit/components/send-to-store-form/send-to-store-form.component';
import { InspectedItemsListComponent } from './transit/components/inspected-items-list/inspected-items-list.component';
import { ReceivedItemsListComponent } from './transit/components/received-items-list/received-items-list.component';
import { SentForInspectionListComponent } from './transit/components/sent-for-inspection-list/sent-for-inspection-list.component';
import { ReceiveItemFormComponent } from './transit/components/receive-item-form/receive-item-form.component';
import { ItemDetailComponent } from './Bincard/item-detail/item-detail.component';
import { WarehouseListComponent } from './Admin/warehouse-list/warehouse-list.component';
import { ShelfListComponent } from './Admin/shelf-list/shelf-list.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './Admin/register/register.component';
import { AdminDashboardComponent } from './components/admin-dashboard/admin-dashboard.component';
import { AuthGuard } from './guards/auth.guard';
import { EditWarehouseComponent } from './Admin/edit-warehouse/edit-warehouse.component'; // Import the EditWarehouseComponent
import { UserListComponent } from './Admin/user-list/user-list.component';
import { EditItemComponent } from './transit/components/edit-item/edit-item.component';
import { Model19ListComponent } from './transit/components/model19-list/model19-list.component';
import { ViewDetailsComponent } from './transit/components/view-details/view-details.component';
import { TransitComponent } from './transit/transit.component';
import { SidebarComponent } from './Bincard/sidebar/sidebar.component';
import { ShelfRegistrationComponent } from './Admin/shelf-registration/shelf-registration.component';
import { MastercardListComponent } from './Mastercard/components/mastercard-list/mastercard-list.component';
import { MastercardDetailsComponent } from './Mastercard/components/mastercard-details/mastercard-details.component';
import { MastercardEditComponent } from './Mastercard/components/mastercard-edit/mastercard-edit.component';
import { MasterCardFormComponent } from './Mastercard/components/mastercard-form/mastercard-form.component';


const routes: Routes = [
  {path: 'register-item',
    component: ItemRegistrationBinComponent,
    },// Registration page
  { path: 'items', component: ItemListComponent }, // Registered items page
  { path: 'admin-dashboard', component: AdminDashboardComponent, canActivate: [AuthGuard] },
  { path: 'add-quantity/:itemCode', component: AddItemQuantityComponent }, // New route for AddItemQuantity
  { path: 'withdraw-quantity/:itemCode', component: WithdrawItemQuantityComponent },
  { path: 'admin/warehouse', component: WarehouseComponent }, // Warehouse registration
  { path: 'admin/warehouses', component: WarehouseListComponent }, // Warehouse list
  { path: 'admin/warehouses/edit/:id', component: EditWarehouseComponent} ,  
  { path: 'admin/shelves', component: ShelfListComponent }, // Send to
  { path: 'login', component: LoginComponent },
  { path: 'admin/register', component: RegisterComponent },
  { path: 'shelf', component: ShelfRegistrationComponent},
  
  {
    path: 'admin-dashboard',
    component: AdminDashboardComponent,
    canActivate: [AuthGuard], // Apply the guard to this route
    data: { role: 'Admin' }, // Optionally specify required role
  },
  { path: 'admin/users', component: UserListComponent },
  { path: 'transit/receive-item-form', component: ReceiveItemFormComponent },
  { path: 'transit-root', component: TransitComponent },
  { path: 'transit/received-items', component: ReceivedItemsListComponent },
  { path: 'transit/sent-for-inspection', component: SentForInspectionListComponent },
  { path: 'transit/inspected-items', component: InspectedItemsListComponent },
  { path: 'transit/send-to-store', component: SendToStoreFormComponent },
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'transit/edit-item/:id', component: EditItemComponent },
  {path: 'transit/view-details/:id', component: ViewDetailsComponent },

  { path: 'transit/model19-list', component: Model19ListComponent },
  {path: 'MasterCard/mastercard-list', component: MastercardListComponent },
  { path: 'MasterCard/mastercard-form', component: MasterCardFormComponent },
  { path: 'MasterCard/mastercard-details/:id', component: MastercardDetailsComponent },
  { path: 'MasterCard/mastercard-edit/:id', component: MastercardEditComponent },

  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}