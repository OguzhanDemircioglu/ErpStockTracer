import {Component, OnInit} from '@angular/core';
import {BlankComponent} from "../blank/blank.component";
import {SectionComponent} from "../section/section.component";
import {CustomerModel} from "../../models/customer.model";
import {HttpService} from "../../services/http.service";
import {SharedModule} from "../../modules/shared.module";
import {CustomerPipe} from "../../pipes/customer.pipe";

@Component({
  selector: 'app-customers',
  standalone: true,
  imports: [
    BlankComponent,
    SectionComponent,
    SharedModule,
    CustomerPipe
  ],
  templateUrl: './customers.component.html',
  styleUrl: './customers.component.css'
})
export class CustomersComponent implements OnInit{
  customers: CustomerModel[] = [];
  search: string ="";

  constructor(
    private http: HttpService
  ) {}

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this.http.post<CustomerModel[]>("Customer/GetAll", {},(res)=> {
      this.customers = res
    })
  }
}
