import {ProductModel} from "./product.model";
import {DepotModel} from "./depot.model";

export class ProductionModel{
  id!: string;
  productId!: string;
  product: ProductModel = new ProductModel();
  depot: DepotModel = new DepotModel();
  depotId!: string;
  quantity!: number;
  createdAt!: string;
}
