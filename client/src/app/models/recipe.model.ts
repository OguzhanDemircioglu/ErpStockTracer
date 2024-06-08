import {ProductModel} from "./product.model";
import {RecipeDetail} from "./recipe-detail.model";

export class RecipeModel{
  id!: string;
  productId!: string;
  product: ProductModel = new ProductModel();
  details: RecipeDetail[] = [];
}
