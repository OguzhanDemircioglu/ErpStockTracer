import { Pipe, PipeTransform } from '@angular/core';
import {RecipeModel} from "../models/recipe.model";
import {RecipeDetailModel} from "../models/recipe-detail.model";

@Pipe({
  name: 'recipeDetail',
  standalone: true
})
export class RecipeDetailPipe implements PipeTransform {

  transform(value: RecipeDetailModel[], search:string): RecipeDetailModel[] {
    if(!search){
      return value;
    }

    return value.filter(item =>
      item.product.name.toLowerCase().includes(search.toLowerCase())
    );
  }

}
