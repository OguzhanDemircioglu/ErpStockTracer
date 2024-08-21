import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {HttpService} from "../../services/http.service";
import {SwalService} from "../../services/swal.service";
import {NgForm} from "@angular/forms";
import {ProductionModel} from "../../models/production.model";
import {SharedModule} from "../../modules/shared.module";
import {ProductionPipe} from "../../pipes/production.pipe";
import {ProductModel} from "../../models/product.model";
import {DepotModel} from "../../models/depot.model";

@Component({
  selector: 'app-production',
  standalone: true,
  imports: [SharedModule, ProductionPipe],
  templateUrl: './production.component.html',
  styleUrl: './production.component.css'
})
export class ProductionComponent implements OnInit{
  productions: ProductionModel[] = [];
  products: ProductModel[] = [];
  depots: DepotModel[] = [];
  search: string = "";
  numbers = Array.from({length: 10}, (_, i) => i + 1);

  @ViewChild("createModalCloseBtn") createModalCloseBtn: ElementRef<HTMLButtonElement> | undefined;

  createModel: ProductionModel = new ProductionModel();

  constructor(
    private http: HttpService,
    private swal: SwalService
  ) {
  }

  ngOnInit(): void {
    this.getAll();
    this.getAllDepots();
    this.getAllProducts();
  }

  getAll() {
    this.http.post<ProductionModel[]>("production/GetAll", {}, (res) => {
      this.productions = res
    })
  }

  getAllProducts() {
    this.http.post<ProductModel[]>("Products/GetAll", {}, (res) => {
      this.products = res
    })
  }

  getAllDepots() {
    this.http.post<DepotModel[]>("Depots/GetAll", {}, (res) => {
      this.depots = res
    })
  }

  create(form: NgForm) {
    if (form.valid) {
      this.http.post<string>("production/Create", this.createModel, (res) => {
        this.swal.callToast(res);
        this.createModel = new ProductionModel();
        this.createModalCloseBtn?.nativeElement.click();
        this.getAll();
      });
    }
  }

  deleteById(model: ProductionModel) {
    this.swal.callSwal("Üretim Sil?", `${model.product.name} üretimini silmek istiyor musunuz`, () => {
      this.http.post<string>("production/DeleteById", {id: model.id}, (res) => {
        this.getAll();
        this.swal.callToast(res, "info");
      })
    })
  }
}
