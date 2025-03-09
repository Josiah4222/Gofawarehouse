import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Item } from '../model/item.model'; // Adjust the path
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ItemService {
  private apiUrl = `${environment.apiBaseUrl}/api/items`; // e.g., http://localhost:5131/api/items

  constructor(private http: HttpClient) {}

  // Get all items
  getItems(): Observable<Item[]> {
    return this.http.get<Item[]>(this.apiUrl);
  }

  // Get a single item by ID
  getItemById(id: number): Observable<Item> {
    return this.http.get<Item>(`${this.apiUrl}/${id}`);
  }

  // Register a new item with transformation to PascalCase
  registerItem(item: Item): Observable<Item> {
    const payload = {
      Name: item.name,
      SerialNumber: item.serialNumber,
      Description: item.description || null,
      Location: item.location,
      VoucherNumber: item.voucherNumber || null,
      ReceivedFrom: item.receivedFrom || null,
      Condition: item.condition,
      Quantity: item.quantity,
      NumOfBox: item.numOfBox,
      RegisteredBy: item.registeredBy,
      ItemType: item.itemType,
      ShelfId: item.shelfId,
    };

    console.log('Payload sent to API:', payload);

    return this.http.post<Item>(this.apiUrl, payload);
  }

  // Update an existing item
  updateItem(id: number, item: Item): Observable<any> {
    const payload = {
      Name: item.name,
      SerialNumber: item.serialNumber,
      Description: item.description || null,
      Location: item.location,
      VoucherNumber: item.voucherNumber || null,
      ReceivedFrom: item.receivedFrom || null,
      Condition: item.condition,
      Quantity: item.quantity,
      NumOfBox: item.numOfBox,
      RegisteredBy: item.registeredBy,
      ItemType: item.itemType,
      ShelfId: item.shelfId,
    };
    return this.http.put(`${this.apiUrl}/${id}`, payload);
  }

  // Delete an item
  deleteItem(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}