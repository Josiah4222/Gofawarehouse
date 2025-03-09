export interface Item {
  model1Id: number;
  supplier: string;
  category: string;
  prno: string;
  date: Date;
  invoiceNo: string;
  itemType: string;
  contactNumber: string;
  number: string;
  registeredBy: string;
  serialNumber: string;
  description: string;
  unitOfMeasurment: string;
  quality: string;
  unitOfPrice: string;
  amount: number;
  location: string;
  remark: string;
  checkedByName: string;
  recivedByName: string;
  authorizedByName: string;

  quantity: number;
  unitPrice: number;
  totalPrice: number;
  currency: string;
  // Remarks: string;
  // UnitOfMeasurement: string;
  Manufacturer: string;
  Warranty: string;
  ExpiryDate: Date;
  BatchNumber: string;

  DateSentForInspection?: Date;
  DateReceivedByInspection?: Date;
  DateSentToStore?: Date;
  Store?: string;
  status?: string; // For inspection status (e.g., 'Pending', 'Received by Inspection Unit')
}
