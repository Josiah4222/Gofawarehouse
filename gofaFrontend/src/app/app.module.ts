import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';  // Import RouterModule and Routes
import { AuthInterceptor } from './interceptors/auth-interceptor.service';
import { HttpClientModule, HTTP_INTERCEPTORS, provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { ReceiveItemFormComponent } from './transit/components/receive-item-form/receive-item-form.component';
import { ReceivedItemsListComponent } from './transit/components/received-items-list/received-items-list.component';
import { SentForInspectionListComponent } from './transit/components/sent-for-inspection-list/sent-for-inspection-list.component';
import { InspectedItemsListComponent } from './transit/components/inspected-items-list/inspected-items-list.component';
import { NotificationIconComponent } from './transit/components/notification-icon/notification-icon.component';
import { SendToStoreFormComponent } from './transit/components/send-to-store-form/send-to-store-form.component';
import { SentToStoreListComponent } from './transit/components/sent-to-store-list/sent-to-store-list.component';

import { AddItemQuantityComponent } from './Bincard/add-item-quantity/add-item-quantity.component';
import { WithdrawItemQuantityComponent } from './Bincard/withdraw-item-quantity/withdraw-item-quantity.component';
import { NavbarComponent } from './Bincard/navbar/navbar.component';
import { WarehouseComponent } from './Admin/warehouse/warehouse.component';


import { ItemRegistrationBinComponent } from './Bincard/item-registration-bin/item-registration-bin.component';
import { ItemListComponent } from './Bincard/item-list/item-list.component';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ItemDetailComponent } from './Bincard/item-detail/item-detail.component';
import { SidebarComponent } from './Bincard/sidebar/sidebar.component';
import { WarehouseListComponent } from './Admin/warehouse-list/warehouse-list.component';
import { ShelfListComponent } from './Admin/shelf-list/shelf-list.component';

import { LoginComponent } from './login/login.component';
import { CommonModule } from '@angular/common';
import { RegisterComponent } from './Admin/register/register.component';
import { AdminDashboardComponent } from './components/admin-dashboard/admin-dashboard.component';
import { EditWarehouseComponent } from './Admin/edit-warehouse/edit-warehouse.component';
import { UserListComponent } from './Admin/user-list/user-list.component';
import { ViewDetailsComponent } from './transit/components/view-details/view-details.component';
import { TransitService } from './transit/services/transit.service';
import { EditItemComponent } from './transit/components/edit-item/edit-item.component';
import { TSidebarComponent } from './transit/sidebar/sidebarr.component';
import { AdminSidebarComponent } from './Admin/admin-sidebar/admin-sidebar.component';
import { ShelfRegistrationComponent } from './Admin/shelf-registration/shelf-registration.component';
import { MastercardDetailsComponent } from './Mastercard/components/mastercard-details/mastercard-details.component';
import { MastercardEditComponent } from './Mastercard/components/mastercard-edit/mastercard-edit.component';
import { MasterCardFormComponent } from './Mastercard/components/mastercard-form/mastercard-form.component';
import { MastercardListComponent } from './Mastercard/components/mastercard-list/mastercard-list.component';
import { MSidebarComponent } from './Mastercard/sidebar/sidebarr.component';





@NgModule({
  declarations: [
    AppComponent,
    ReceiveItemFormComponent,
    ViewDetailsComponent,
    SentForInspectionListComponent,
    InspectedItemsListComponent,
    NotificationIconComponent,
    SendToStoreFormComponent,
    SentToStoreListComponent,
    ItemRegistrationBinComponent,
    ItemListComponent,
    ReceivedItemsListComponent,
    
    AddItemQuantityComponent,
    WithdrawItemQuantityComponent,
    NavbarComponent,
    WarehouseComponent,

    ItemDetailComponent,
    SidebarComponent,
    WarehouseListComponent,
    ShelfListComponent,

    LoginComponent,
    RegisterComponent,
    AdminDashboardComponent,
    EditWarehouseComponent,
    UserListComponent,
    EditItemComponent,
    TSidebarComponent,
    MSidebarComponent,
    AdminSidebarComponent,
    ShelfRegistrationComponent,

    MasterCardFormComponent,
    MastercardListComponent,
    MastercardDetailsComponent,
    MastercardEditComponent,
    
    
    
    

  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule , // Set up the routes in the RouterModule,
    ReactiveFormsModule,
    HttpClientModule,
    CommonModule,
    
    
  ],
  providers: [{
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,}
  , TransitService, provideHttpClient(withInterceptorsFromDi())],
  bootstrap: [AppComponent]
})
export class AppModule { }
