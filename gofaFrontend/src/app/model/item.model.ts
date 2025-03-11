export interface Item {
  itemId?: number;
  name: string;
  serialNumber: string;
  description?: string;
  voucherNumber?: string;
  receivedFrom?: string;
  condition: string;
  quantity: number;
  numOfBox: number;
  registeredBy: string;
  itemType: string;
  shelfName?: string;
}

export interface Transaction {
  transactionId?: number;
  itemId: number;
  oldQuantity: number;
  newQuantity: number;
  changeType: 'ADD' | 'WITHDRAW';
  changedBy: string;
  changeDate: Date;
}