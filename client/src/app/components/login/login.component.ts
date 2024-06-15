import {Component} from '@angular/core';
import {SharedModule} from "../../modules/shared.module";
import {LoginModel} from "../../models/login.model";
import {LoginResponseModel} from "../../models/loginResponse.model";
import {HttpService} from "../../services/http.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  model: LoginModel = new LoginModel();

  constructor(
    private http: HttpService,
    private router: Router
  ) {
  }

  login() {
    this.http.post<LoginResponseModel>("Auth/Login", this.model, (res) => {
      localStorage.setItem("token", res.token);
      this.router.navigateByUrl("/");
    })
  }
}
