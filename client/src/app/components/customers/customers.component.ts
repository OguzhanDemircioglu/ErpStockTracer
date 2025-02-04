import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {BlankComponent} from "../blank/blank.component";
import {SectionComponent} from "../section/section.component";
import {CustomerModel} from "../../models/customer.model";
import {HttpService} from "../../services/http.service";
import {SharedModule} from "../../modules/shared.module";
import {CustomerPipe} from "../../pipes/customer.pipe";
import {NgForm} from "@angular/forms";
import {SwalService} from "../../services/swal.service";

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
export class CustomersComponent implements OnInit {
  customers: CustomerModel[] = [];
  search: string = "";

  @ViewChild("createModalCloseBtn") createModalCloseBtn: ElementRef<HTMLButtonElement> | undefined;
  @ViewChild("updateModalCloseBtn") updateModalCloseBtn: ElementRef<HTMLButtonElement> | undefined;

  createModel: CustomerModel = new CustomerModel();
  updateModel: CustomerModel = new CustomerModel();

  constructor(
    private http: HttpService,
    private swal: SwalService
  ) {
  }

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this.http.post<CustomerModel[]>("Customers/GetAll", {}, (res) => {
      this.customers = res
    })
  }

  create(form: NgForm) {
    if (form.valid) {
      this.http.post<string>("Customers/Create", this.createModel, (res) => {
        this.swal.callToast(res);
        this.createModel = new CustomerModel();
        this.createModalCloseBtn?.nativeElement.click();
        this.getAll();
      });
    }
  }

  deleteById(model: CustomerModel) {
    this.swal.callSwal("Müşteri Sil?", `${model.name} müşterisini silmek istiyor musunuz`, () => {
      this.http.post<string>("Customers/DeleteById", {id: model.id}, (res) => {
        this.getAll();
        this.swal.callToast(res, "info");
      })
    })
  }

  update(form: NgForm) {
    if (form.valid) {
      this.http.post<string>("Customers/Update", this.updateModel, (res) => {
        this.swal.callToast(res, "info");
        this.updateModalCloseBtn?.nativeElement.click();
        this.getAll();
      });
    }
  }

  get(model: CustomerModel) {
    this.updateModel = {...model};
  }
}
