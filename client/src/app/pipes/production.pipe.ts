import {Pipe, PipeTransform} from '@angular/core';
import {ProductionModel} from "../models/production.model";

@Pipe({
  name: 'production',
  standalone: true
})
export class ProductionPipe implements PipeTransform {
  transform(value: ProductionModel[], search: string): ProductionModel[] {
    if (!search) {
      return value;
    }

    return value.filter(item =>
      item.product.name.toLowerCase().includes(search.toLowerCase()) ||
      item.depot.name.toLowerCase().includes(search.toLowerCase())
    );
  }

}
