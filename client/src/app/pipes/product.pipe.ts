import { Pipe, PipeTransform } from '@angular/core';
import {DepotModel} from "../models/depot.model";
import {ProductModel} from "../models/product.model";

@Pipe({
  name: 'product',
  standalone: true
})
export class ProductPipe implements PipeTransform {

  transform(value: ProductModel[], search:string): ProductModel[] {
    if(!search){
      return value;
    }

    return value.filter(item =>
      item.name.toLowerCase().includes(search.toLowerCase()) ||
      item.type.name.toLowerCase().includes(search.toLowerCase())
    );
  }

}
