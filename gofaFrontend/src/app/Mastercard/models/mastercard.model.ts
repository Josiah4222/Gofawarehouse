// item.model.ts
export interface Item {

  masterCardId: number;
  model: string;
  partNumber: string;
  description: string;
  um: string;
  inCHAb: string;
  unitPack: string;
  leadTime: string;
  avgUsage: string;
  ssl: string;
  maxLevel: string;
  recordPoint: string;
  ved: string;
  abc: string;
  status: string;
  orderTime: Date;
  location: string;
  date: Date;
  orderNo: number;
  consigning: string;
  qytOrder: string;
  qyt: string;
  voucherNo: string;
  received: string;
  issued: string;
  inStock: string;
  unitPrice: string;
  org: string;
  postedBy: string;

  [key: string]: any;
}
