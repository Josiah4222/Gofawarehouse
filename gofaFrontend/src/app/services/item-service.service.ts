import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Item, Transaction } from '../model/item.model';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ItemService {
  private apiUrl = `${environment.apiBaseUrl}/api/items`;
  private transactionUrl = `${environment.apiBaseUrl}/api/transactions`;

  constructor(private http: HttpClient) {}

  getItems(): Observable<Item[]> {
    return this.http.get<Item[]>(this.apiUrl);
  }

  getItemById(id: number): Observable<Item> {
    return this.http.get<Item>(`${this.apiUrl}/${id}`);
  }

  registerItem(item: Item): Observable<Item> {
    const payload = {
      Name: item.name,
      SerialNumber: item.serialNumber,
      Description: item.description || null,
      VoucherNumber: item.voucherNumber || null,
      ReceivedFrom: item.receivedFrom || null,
      Condition: item.condition,
      Quantity: item.quantity,
      NumOfBox: item.numOfBox,
      RegisteredBy: item.registeredBy,
      ItemType: item.itemType,
      ShelfName: item.shelfName || null,
    };
    return this.http.post<Item>(this.apiUrl, payload);
  }

  updateItem(id: number, item: Item): Observable<any> {
    const payload = {
      Name: item.name,
      SerialNumber: item.serialNumber,
      Description: item.description || null,
      VoucherNumber: item.voucherNumber || null,
      ReceivedFrom: item.receivedFrom || null,
      Condition: item.condition,
      Quantity: item.quantity,
      NumOfBox: item.numOfBox,
      RegisteredBy: item.registeredBy,
      ItemType: item.itemType,
      ShelfName: item.shelfName || null,
    };
    return this.http.put(`${this.apiUrl}/${id}`, payload);
  }

  deleteItem(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  logTransaction(transaction: Transaction): Observable<Transaction> {
    return this.http.post<Transaction>(this.transactionUrl, transaction);
  }
}