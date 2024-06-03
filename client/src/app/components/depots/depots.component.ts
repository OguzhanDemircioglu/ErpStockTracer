import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {BlankComponent} from "../blank/blank.component";
import {FormValidateDirective} from "form-validate-angular";
import {FormsModule, NgForm} from "@angular/forms";
import {SectionComponent} from "../section/section.component";
import {SharedModule} from "../../modules/shared.module";
import {HttpService} from "../../services/http.service";
import {SwalService} from "../../services/swal.service";
import {DepotModel} from "../../models/depot.model";
import {DepotPipe} from "../../pipes/depot.pipe";

@Component({
  selector: 'app-depots',
  standalone: true,
  imports: [
    BlankComponent,
    DepotPipe,
    FormValidateDirective,
    FormsModule,
    SectionComponent,
    SharedModule
  ],
  templateUrl: './depots.component.html',
  styleUrl: './depots.component.css'
})
export class DepotsComponent implements OnInit {
  depots: DepotModel[] = [];
  search: string = "";

  @ViewChild("createModalCloseBtn") createModalCloseBtn: ElementRef<HTMLButtonElement> | undefined;
  @ViewChild("updateModalCloseBtn") updateModalCloseBtn: ElementRef<HTMLButtonElement> | undefined;

  createModel: DepotModel = new DepotModel();
  updateModel: DepotModel = new DepotModel();

  constructor(
    private http: HttpService,
    private swal: SwalService
  ) {
  }

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this.http.post<DepotModel[]>("Depots/GetAll", {}, (res) => {
      this.depots = res
    })
  }

  create(form: NgForm) {
    if (form.valid) {
      this.http.post<string>("Depots/Create", this.createModel, (res) => {
        this.swal.callToast(res);
        this.createModel = new DepotModel();
        this.createModalCloseBtn?.nativeElement.click();
        this.getAll();
      });
    }
  }

  deleteById(model: DepotModel) {
    this.swal.callSwal("Depo Sil?", `${model.name} deposunu silmek istiyor musunuz`, () => {
      this.http.post<string>("Depots/DeleteById", {id: model.id}, (res) => {
        this.getAll();
        this.swal.callToast(res, "info");
      })
    })
  }

  update(form: NgForm) {
    if (form.valid) {
      this.http.post<string>("Depots/Update", this.updateModel, (res) => {
        this.swal.callToast(res, "info");
        this.updateModalCloseBtn?.nativeElement.click();
        this.getAll();
      });
    }
  }

  get(model: DepotModel) {
    this.updateModel = {...model};
  }
}
