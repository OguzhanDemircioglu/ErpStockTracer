import {ProductModel} from "./product.model";

export class RecipeDetail {
  id!: string;
  productId!: string;
  product: ProductModel = new ProductModel();
  quantity!: number;
}
