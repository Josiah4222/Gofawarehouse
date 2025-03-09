// import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
// import { Observable } from 'rxjs';
// import { Item } from '../models/item.model';

// @Injectable({
//   providedIn: 'root',
// })
// export class TransitService {
//   private apiUrl = 'https://transit-api.com';

//   constructor(private http: HttpClient) {}


//   getReceivedItems(): Observable<Item[]> {
//     return this.http.get<Item[]>(`${this.apiUrl}/received-items`);
//   }


//   getSentForInspection(): Observable<Item[]> {
//     return this.http.get<Item[]>(`${this.apiUrl}/sent-for-inspection`);
//   }


//   getInspectedItems(): Observable<Item[]> {
//     return this.http.get<Item[]>(`${this.apiUrl}/inspected-items`);
//   }


//   sendToInspection(item: Item): Observable<Item> {
//     return this.http.post<Item>(`${this.apiUrl}/send-to-inspection`, item);
//   }


//   receiveFromInspection(itemId: number): Observable<Item> {
//     return this.http.post<Item>(`${this.apiUrl}/receive-from-inspection`, { itemId });
//   }


//   sendToStore(item: Item): Observable<Item> {
//     return this.http.post<Item>(`${this.apiUrl}/send-to-store`, item);
//   }


//   getSentToStore(): Observable<Item[]> {
//     return this.http.get<Item[]>(`${this.apiUrl}/sent-to-store`);
//   }
// }

// src/app/transit/services/transit.service.ts
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { throwError as observableThrowError } from 'rxjs';
import { Item } from '../models/item.model';
import {
  MOCK_SENT_TO_STORE_ITEMS,
  MOCK_SENT_FOR_INSPECTION_ITEMS,
  MOCK_NOTIFICATIONS,
  MOCK_INSPECTED_ITEMS,
  MOCK_RECEIVED_ITEMS,
} from '../mock-data';

@Injectable({
  providedIn: 'root',
})
export class TransitService {
  constructor(private http: HttpClient) {}

  private mockItems: Item[] = [];
  private apiUrl = 'http://localhost:5131/api/Model1';
  // Get items sent to store

  //  getItemById(id: number): Observable<Item> {
  //    const item = MOCK_RECEIVED_ITEMS.find(item => item.model1Id === id);
  //    if (item) {
  //      return of(item); // Return an observable of the found item
  //    } else {
  //      throw new Error(`Item with id ${id} not found`);
  //    }
  //  }

   getItemById(id: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }

  getModels(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl).pipe(
      catchError((error) => {
        console.error('Error fetching models:', error);
        return of([]); // Return empty array on error to avoid breaking the app
      })
    );
  }

  // getItemById(id: number): Observable<Item> {
  //   // Replace with actual API call
  //   const foundItem = this.mockItems.find(item => item.Model1Id === id);
  //   if (foundItem) {
  //     return of(foundItem);
  //   } else {
  //     throw new Error(`Item with id ${id} not found`);
  //   }
  // }

  updateItem(id: string, updatedItem: any): Observable<any> {
    // Replace with actual API call
    const url = `${this.apiUrl}/${id}`;
    return this.http.put(url, updatedItem).pipe(
      catchError((error) => {
        console.error('Error updating item:', error);
        return throwError(() => new Error('Failed to update item'));
      })
    );

  }

  updateProfile(id: number, profileData: any): Observable<any> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.put(url, profileData).pipe(
      catchError((error) => {
        console.error('Error updating profile:', error);
        return throwError(() => new Error('Failed to update profile'));
      })
    );
  }

  // updateItem(id: number, updatedItem: Item): Observable<Item> {
  //   const index = this.mockItems.findIndex(item => item.Model1Id === id);
  //   if (index > -1) {
  //     this.mockItems[index] = { ...this.mockItems[index], ...updatedItem };
  //   }
  //   return of(this.mockItems[index]);
  // }

  // getItemById(id: number): Observable<Item> {
  //   const foundItem = this.mockItems.find(item => item.Model1Id === id);
  //   if (foundItem) {
  //     return of(foundItem);
  //   } else {
  //     throw new Error(`Item with id ${id} not found`);
  //   }
  // }

  // updateItemStatus(itemId: number, newStatus: Item): Observable<Item> {
  //   // Update in mock data
  //   const item = this.mockItems.find(i => i.model1Id === itemId);
  //   if (item) {
  //     item.status = newStatus;
  //   }
  //   return of(item!);
  // }

  // updateItemStatus(itemId: string, newStatus: Item): Observable<Item> {
  //   const apiUrl = `http://localhost:5006/api/Model1/${itemId}`;

  //   return this.http.put<Item>(apiUrl, { model1Id: itemId, status: newStatus });

  // }

  updateItemStatus(itemId: string, newStatus: Item): Observable<Item> {
    const url = `${this.apiUrl}/${itemId}`;



    return this.http.put<Item>(url, newStatus, {
      headers: { 'Content-Type': 'application/json' }
    });
  }

  // updateItemStatus(itemId: string, updatedItem: Item): Observable<Item> {
  //   const url = `${this.apiUrl}/${itemId}`;

  //   return this.http.put<Item>(url, updatedItem, {
  //     headers: { 'Content-Type': 'application/json' }
  //   });
  // }







  // deleteItem(itemId: number): Observable<void> {
  //   // Delete from mock data
  //   this.mockItems = this.mockItems.filter(item => item.model1Id !== itemId);
  //   return of(undefined);
  // }

  deleteItem(itemId: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${itemId}`);
  }


  getSentToStore(): Observable<Item[]> {
    return of(MOCK_SENT_TO_STORE_ITEMS);
  }

  // Get items sent for inspection
  getSentForInspection(): Observable<Item[]> {
    return of(MOCK_SENT_FOR_INSPECTION_ITEMS);
  }

  // Get notifications (items from inspection unit)
  getNotifications(): Observable<Item[]> {
    return of(MOCK_NOTIFICATIONS);
  }

  sendToStore(item: Item) {
        // return this.http.post<Item>(`${this.apiUrl}/send-to-store`, item);
      }

  receiveFromInspection(itemId: number) {
    return of(MOCK_RECEIVED_ITEMS);
      }

  getInspectedItems(){
    return of(MOCK_INSPECTED_ITEMS);
  }
  // sendToInspection(item: Item){
  //   return of(MOCK_RECEIVED_ITEMS);
  // }
    sendToInspection(item: Item): Observable<Item> {
    return this.http.post<Item>(`${this.apiUrl}`, item);
  }
  // getReceivedItems(){
  //   return of(MOCK_RECEIVED_ITEMS);
  // }
    getReceivedItems(): Observable<Item[]> {
    return this.http.get<Item[]>(`${this.apiUrl}`);
  }
  addSentToStoreItem(item: Item): Observable<Item> {
    MOCK_SENT_TO_STORE_ITEMS.push(item);
    return of(item);
  }

  addSentForInspectionItem(item: Item): Observable<Item> {
    MOCK_SENT_FOR_INSPECTION_ITEMS.push(item);
    return of(item);
  }
}
function throwError(errorFactory: () => Error): Observable<never> {
  return observableThrowError(errorFactory());
}

