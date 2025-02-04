import {Routes} from '@angular/router';
import {LoginComponent} from "./components/login/login.component";
import {LayoutsComponent} from "./components/layouts/layouts.component";
import {HomeComponent} from "./components/home/home.component";
import {inject} from "@angular/core";
import {AuthService} from "./services/auth.service";
import {CustomersComponent} from "./components/customers/customers.component";
import {DepotsComponent} from "./components/depots/depots.component";
import {ProductsComponent} from "./components/products/products.component";
import {RecipesComponent} from "./components/recipes/recipes.component";
import {RecipeDetailsComponent} from "./components/recipe-details/recipe-details.component";
import {OrdersComponent} from "./components/orders/orders.component";
import {RequirementsPlanningComponent} from "./components/requirements-planning/requirements-planning.component";
import {InvoiceComponent} from "./components/invoices/invoices.component";
import {ProductionComponent} from "./components/production/production.component";

export const routes: Routes = [
  {
    path: "login",
    component: LoginComponent
  }, {
    path: "requirements-planning/:id",
    component: RequirementsPlanningComponent
  },
  {
    path: "",
    component: LayoutsComponent,
    canActivateChild: [() => inject(AuthService).isAuthenticated()],
    children: [
      {
        path: "",
        component: HomeComponent
      }, {
        path: "Customers",
        component: CustomersComponent
      }, {
        path: "Depots",
        component: DepotsComponent
      }, {
        path: "Products",
        component: ProductsComponent
      }, {
        path: "Recipes",
        component: RecipesComponent
      }, {
        path: "RecipeDetails/:id",
        component: RecipeDetailsComponent,
        canActivate: [() => inject(AuthService).isAuthenticated()]
      }, {
        path: "Orders",
        component: OrdersComponent
      }, {
        path: "invoices/:type",
        component: InvoiceComponent
      }, {
        path: "Production",
        component: ProductionComponent
      }
    ]
  }
];
