import {CustomerModel} from "./customer.model";
import {OrderDetailModel} from "./order-detail.model";

export class OrderModel {
  id!: string;
  customerId!: string;
  customer: CustomerModel = new CustomerModel();
  orderNumberYear!: number;
  orderNumber!: number;
  orderPrefix!: string;
  productId!: string;
  status: OrderStatusEnum = new OrderStatusEnum();
  orderDate!: string | null;
  deliveryDate!: string;
  details: OrderDetailModel[] = [];
}

export class OrderStatusEnum{
  value: number = 1;
  name: string  ="";
}
