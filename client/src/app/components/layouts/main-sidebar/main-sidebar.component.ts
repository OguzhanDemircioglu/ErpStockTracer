import {Component} from '@angular/core';
import {Menus} from "../../../menu";
import {RouterLink, RouterLinkActive} from "@angular/router";
import {FormsModule} from "@angular/forms";
import {MenuPipe} from "../../../pipes/menu.pipe";
import {AuthService} from "../../../services/auth.service";
import {NgForOf, NgIf} from "@angular/common";

@Component({
  selector: 'app-main-sidebar',
  standalone: true,
  imports: [RouterLink, RouterLinkActive, FormsModule, MenuPipe, NgForOf, NgIf],
  templateUrl: './main-sidebar.component.html',
  styleUrl: './main-sidebar.component.css'
})
export class MainSidebarComponent {
  search: string = "";
  menus = Menus;

  constructor(
    public auth: AuthService
  ) {}
}
