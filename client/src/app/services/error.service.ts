import { Injectable } from '@angular/core';
import {HttpErrorResponse} from "@angular/common/http";
import {SwalService} from "./swal.service";

@Injectable({
  providedIn: 'root'
})
export class ErrorService {

  constructor(
    private swal: SwalService
  ) {}

  errorHandler(err: HttpErrorResponse){
    console.log(err);

    if(err.status === 403){
      let messages = "";

      for(const e of err.error.ErrorMessages){
        messages += e + "\n";
      }

      this.swal.callToast(messages, "error");
    }else if(err.status === 500) {
      this.swal.callToast(err.error.errorMessages[0], "error");
    }
  }
}
