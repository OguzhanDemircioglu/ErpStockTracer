import { Pipe, PipeTransform } from '@angular/core';
import {CustomerModel} from "../models/customer.model";

@Pipe({
  name: 'customer',
  standalone: true
})
export class CustomerPipe implements PipeTransform {

  transform(value: CustomerModel[], search:string): CustomerModel[] {
    if(!search){
      return value;
    }

    return value.filter(item =>
      item.name.toLowerCase().includes(search.toLowerCase()) ||
      item.taxDepartment.toLowerCase().includes(search.toLowerCase()) ||
      item.taxNumber.toString().toLowerCase().includes(search.toLowerCase()) ||
      item.city.toLowerCase().includes(search.toLowerCase()) ||
      item.town.toLowerCase().includes(search.toLowerCase()) ||
      item.fullAdress.toLowerCase().includes(search.toLowerCase())
    );
  }

}
