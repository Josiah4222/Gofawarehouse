export interface Shelf {
  shelfId?: string;
  name: string;
  column: string;
  row: string;
  warehouse: { // Use a warehouse object instead of warehouseName
    warehouseId: string;
    name: string;
    location: string;
  };
}