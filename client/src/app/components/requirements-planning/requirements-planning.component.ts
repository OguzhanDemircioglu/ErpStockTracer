import {Component} from '@angular/core';
import {RequirementsPlanningModel} from "../../models/requirements-planning.model";
import {CommonModule} from "@angular/common";
import {HttpService} from "../../services/http.service";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-requirements-planning',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './requirements-planning.component.html',
  styleUrl: './requirements-planning.component.css'
})
export class RequirementsPlanningComponent {
  data: RequirementsPlanningModel = new RequirementsPlanningModel();
  orderId!: string;

  constructor(
    private http: HttpService,
    private activated: ActivatedRoute
  ) {
    this.activated.params.subscribe(res => {
      this.orderId = res['id'];
      this.getPlanning();
    });
  }

  getPlanning() {
    this.http.post<RequirementsPlanningModel>("Orders/RequirementsPlanningByOrderIdCommand", {orderId: this.orderId}, (res) => {
      this.data = res
    })
  }

}
