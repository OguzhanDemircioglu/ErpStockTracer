import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {BlankComponent} from "../blank/blank.component";
import {FormValidateDirective} from "form-validate-angular";
import {FormsModule, NgForm} from "@angular/forms";
import {SectionComponent} from "../section/section.component";
import {SharedModule} from "../../modules/shared.module";
import {ProductModel} from "../../models/product.model";
import {HttpService} from "../../services/http.service";
import {SwalService} from "../../services/swal.service";
import {RecipeModel} from "../../models/recipe.model";
import {RecipePipe} from "../../pipes/recipe.pipe";
import {ProductPipe} from "../../pipes/product.pipe";
import {RecipeDetail} from "../../models/recipe-detail.model";

@Component({
  selector: 'app-recipes',
  standalone: true,
  imports: [
    BlankComponent,
    RecipePipe,
    FormValidateDirective,
    FormsModule,
    SectionComponent,
    SharedModule,
    ProductPipe
  ],
  templateUrl: './recipes.component.html',
  styleUrl: './recipes.component.css'
})
export class RecipesComponent implements OnInit {
  recipes: RecipeModel[] = [];
  search: string = "";
  products: ProductModel[] = [];
  semiProducts: ProductModel[] = [];

  detail = new RecipeDetail();
  numbers = Array.from({length: 10}, (_, i) => i + 1);

  @ViewChild("createModalCloseBtn") createModalCloseBtn: ElementRef<HTMLButtonElement> | undefined;

  createModel: RecipeModel = new RecipeModel();
  updateModel: RecipeModel = new RecipeModel();

  constructor(
    private http: HttpService,
    private swal: SwalService
  ) {
  }

  ngOnInit(): void {
    this.getAll();
    this.getProducts();
  }

  getAll() {
    this.http.post<RecipeModel[]>("Recipes/GetAll", {}, (res) => {
      this.recipes = res
    })
  }

  create(form: NgForm) {
    if (form.valid) {
      this.http.post<string>("Recipes/Create", this.createModel, (res) => {
        this.swal.callToast(res);
        this.createModel = new RecipeModel();
        this.createModalCloseBtn?.nativeElement.click();
        this.getAll();
      });
    }
  }

  deleteById(model: RecipeModel) {
    this.swal.callSwal("Reçeteyi Sil?", `${model.product.name} ürüne ait reçeteyi silmek istiyor musunuz`, () => {
      this.http.post<string>("Recipes/DeleteById", {id: model.id}, (res) => {
        this.getAll();
        this.swal.callToast(res, "info");
      })
    })
  }

  addDetail() {
    let product = this.semiProducts.find(p => p.id === this.detail.productId);

    if (product) {
      this.detail.product = product;
      if (this.detail.quantity !== undefined) {
        this.createModel.details.push(this.detail);
      }
    }

    this.detail = new RecipeDetail();
  }

  removeDetail(index: number){
    this.createModel.details.splice(index, 1);
  }

  getProducts() {
    this.http.post<ProductModel[]>("Products/GetAll", {}, (res) => {
      this.semiProducts = res.filter(recipe => recipe.type.value === 2);
      this.products = res.filter(recipe => recipe.type.value === 1);

    })
  }
}
