import {Component, OnInit} from '@angular/core';
import {BlankComponent} from "../blank/blank.component";
import {FormValidateDirective} from "form-validate-angular";
import {FormsModule, NgForm} from "@angular/forms";
import {SectionComponent} from "../section/section.component";
import {SharedModule} from "../../modules/shared.module";
import {HttpService} from "../../services/http.service";
import {SwalService} from "../../services/swal.service";
import {RecipeDetailPipe} from "../../pipes/recipe-detail.pipe";
import {RecipeDetailModel} from "../../models/recipe-detail.model";
import {ActivatedRoute} from "@angular/router";
import {RecipeModel} from "../../models/recipe.model";
import {ProductModel} from "../../models/product.model";
import {ProductPipe} from "../../pipes/product.pipe";

@Component({
  selector: 'app-recipe-details',
  standalone: true,
  imports: [
    BlankComponent,
    RecipeDetailPipe,
    FormValidateDirective,
    FormsModule,
    SectionComponent,
    SharedModule,
    ProductPipe
  ],
  templateUrl: './recipe-details.component.html',
  styleUrl: './recipe-details.component.css'
})
export class RecipeDetailsComponent implements OnInit {
  recipeDetails: RecipeDetailModel[] = [];
  recipe: RecipeModel = new RecipeModel();
  recipeId: string = "";
  products: ProductModel[] = []
  search: string ="";
  numbers = Array.from({length: 10}, (_, i) => i + 1);
  isUpdateActive:boolean=false;

  createModel: RecipeDetailModel = new RecipeDetailModel();
  updateModel: RecipeDetailModel = new RecipeDetailModel();

  constructor(
    private http: HttpService,
    private swal: SwalService,
    private activated: ActivatedRoute
  ) {
    this.activated.params.subscribe(res => {
      this.recipeId = res["id"];
      this.GetByIdRecipeWithDetails();
      this.createModel.recipeId = this.recipeId;
    })
  }

  ngOnInit(): void {
    this.getAllProducts();
  }

  getAllProducts() {
    this.http.post<ProductModel[]>("Products/GetAll", {}, (res) => {
      this.products = res//.filter(recipe => recipe.type.value === 2);
    })
  }

  GetByIdRecipeWithDetails() {
    this.http.post<RecipeModel>("RecipeDetails/GetByIdRecipeWithDetails", {id: this.recipeId}, (res) => {
      this.recipe = res
    })
  }

  create(form: NgForm) {
    if (form.valid) {
      this.http.post<string>("RecipeDetails/CreateRecipeDetail", this.createModel, (res) => {
        this.swal.callToast(res);
        this.createModel = new RecipeDetailModel();
        this.createModel.recipeId = this.recipeId;
        this.GetByIdRecipeWithDetails();
      });
    }
  }

  deleteById(model: RecipeDetailModel) {
    this.swal.callSwal("Ürünü Sil?", `${model.product.name} ürününü silmek istiyor musunuz`, () => {
      this.http.post<string>("RecipeDetails/DeleteRecipeDetailById/", {id: model.id}, (res) => {
        this.GetByIdRecipeWithDetails();
        this.swal.callToast(res, "info");
      })
    })
  }

  UpdateRecipeDetail(form: NgForm) {
    if (form.valid) {
      this.http.post<string>("RecipeDetails/UpdateRecipeDetail", this.updateModel, (res) => {
        this.swal.callToast(res, "info");
        this.GetByIdRecipeWithDetails();
        this.isUpdateActive=false;
      });
    }
  }

  get(model: RecipeDetailModel) {
    this.updateModel = {...model};
    this.updateModel.product = this.products.find(p=> p.id == this.updateModel.productId) ?? new ProductModel();
    this.isUpdateActive=true;
  }

  protected readonly NgForm = NgForm;
}
