// shelf.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

// shelf.service.ts
export interface Warehouse {
  warehouseId: string;
  name: string;
  location: string;
}

export interface Shelf {
  shelfId?: string;
  name: string;
  column: string;
  row: string;
  warehouse: Warehouse; // Change from warehouseName to warehouse object
}

@Injectable({
  providedIn: 'root'
})
export class ShelfService {
  private apiUrl = 'http://localhost:5131/api/shelf'; // Adjust URL to match your backend

  constructor(private http: HttpClient) { }

  createShelf(shelf: Shelf): Observable<Shelf> {
    return this.http.post<Shelf>(this.apiUrl, shelf);
  }

  getShelves(): Observable<Shelf[]> {
    return this.http.get<Shelf[]>(this.apiUrl);
  }

  getWarehouses(): Observable<any[]> {
    // Assuming you have a warehouse endpoint
    return this.http.get<any[]>('http://localhost:5131/api/warehouses');
  }


  updateShelf(shelfId: string, shelf: Shelf): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${shelfId}`, {
      name: shelf.name,
      column: shelf.column,
      row: shelf.row,
      warehouseName: shelf.warehouse.name // Backend expects warehouseName
    });
  }
}