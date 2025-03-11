import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError as observableThrowError, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { Item } from '../Mastercard/models/mastercard.model';
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root',
})
export class MasterCardService {
  constructor(private http: HttpClient) {}

  private mockItems: Item[] = [];
  private apiUrl = 'http://localhost:5131/api/MasterCard';





  updateItem(id: string, updatedItem: any): Observable<any> {

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



  updateItemStatus(itemId: string, newStatus: Item): Observable<Item> {
    const url = `${this.apiUrl}/${itemId}`;



    return this.http.put<Item>(url, newStatus, {
      headers: { 'Content-Type': 'application/json' }
    });
  }



  deleteItem(itemId: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${itemId}`);
  }




  // Get items sent for inspection


  // Get notifications (items from inspection unit)


  sendToStore(item: Item) {
        // return this.http.post<Item>(`${this.apiUrl}/send-to-store`, item);
      }



    sendToInspection(item: Item): Observable<Item> {
    return this.http.post<Item>(`${this.apiUrl}`, item);
  }

  getMasterCards(): Observable<Item[]> {
    return this.http.get<Item[]>(`${this.apiUrl}`);
  }





  getItemById(id: string): Observable<Item> {
    return this.http.get<Item>(`${this.apiUrl}/${id}`);
  }

  // Save a new MasterCard
  saveMasterCard(masterCard: Item): Observable<any> {
    return this.http.post<any>(this.apiUrl, masterCard);
  }

  // Get a MasterCard by ID (if needed for fetching data)
  // getMasterCardById(id: number): Observable<MasterCard> {
  //   return this.http.get<MasterCard>(`${this.apiUrl}/${id}`);
  // }

  // Update an existing MasterCard (if needed for updates)
  // updateMasterCard(id: number, masterCard: MasterCard): Observable<any> {
  //   return this.http.put<any>(`${this.apiUrl}/${id}`, masterCard);
  // }


}
function throwError(errorFactory: () => Error): Observable<never> {
  return observableThrowError(errorFactory());
}

