import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.css']
})
export class ItemListComponent {
calculateBalance(_t27: any) {
throw new Error('Method not implemented.');
}


clearSearch() {
throw new Error('Method not implemented.');
}

filterItems() {
throw new Error('Method not implemented.');
}
itemNameFilter: any;
searchQuery: any;
openItemDetail(_t21: any) {
throw new Error('Method not implemented.');
}
viewDetails(_t21: any) {
throw new Error('Method not implemented.');
}

openWithdrawQuantity(_t20: any) {
throw new Error('Method not implemented.');
}
deleteItem(_t19: any) {
throw new Error('Method not implemented.');
}
openAddQuantity(_t19: any) {
throw new Error('Method not implemented.');
}

  registeredItems: any[] = [];

  constructor(private route: ActivatedRoute) {
    const itemsData = this.route.snapshot.queryParamMap.get('items');
    this.registeredItems = itemsData ? JSON.parse(itemsData) : [];
  }
}
