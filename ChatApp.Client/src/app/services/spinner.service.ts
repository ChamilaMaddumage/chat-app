import { Injectable } from "@angular/core";
import { NgxSpinnerService } from "ngx-spinner";

@Injectable({
  providedIn: "root",
})
export class SpinnerService {
  constructor(private spinnerService: NgxSpinnerService) {}
  public IsVisible(val: boolean): void {
    if (val) {
      this.spinnerService.show();
    } else {
      this.spinnerService.hide();
    }
  }
}
