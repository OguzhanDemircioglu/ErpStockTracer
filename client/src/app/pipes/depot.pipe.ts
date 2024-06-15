import { Pipe, PipeTransform } from '@angular/core';
import {DepotModel} from "../models/depot.model";

@Pipe({
  name: 'depot',
  standalone: true
})
export class DepotPipe implements PipeTransform {

  transform(value: DepotModel[], search:string): DepotModel[] {
    if(!search){
      return value;
    }

    return value.filter(item =>
      item.name.toLowerCase().includes(search.toLowerCase()) ||
      item.city.toLowerCase().includes(search.toLowerCase()) ||
      item.town.toLowerCase().includes(search.toLowerCase()) ||
      item.fullAdress.toLowerCase().includes(search.toLowerCase())
    );
  }

}
