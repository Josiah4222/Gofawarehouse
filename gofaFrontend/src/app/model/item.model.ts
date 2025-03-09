export interface Item {
  itemId?: number;
  name: string;
  serialNumber: string;
  description?: string;
  location: string;
  voucherNumber?: string;
  receivedFrom?: string;
  condition: string;
  quantity: number;
  numOfBox: number;
  registeredBy: string;
  itemType: string;
  shelfId: string;
}