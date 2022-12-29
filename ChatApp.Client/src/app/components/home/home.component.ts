import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormControl, FormGroup } from "@angular/forms";
import { Router } from "@angular/router";
import { SpinnerService } from "src/app/services/spinner.service";
import { UsersService } from "src/app/services/users.service";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"],
})
export class HomeComponent implements OnInit {
  public userName: string;
  public userForm: FormGroup;
  userNameFormControl: string = "userNameFormControl";

  constructor(
    private router: Router,
    private usersService: UsersService,
    public spinnerService: SpinnerService,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit() {
    this.userForm = this.formBuilder.group({
      userNameFormControl: new FormControl(""),
    });
  }

  onRegister() {
    this.router.navigateByUrl("registerUser");
  }

  onJoin() {
    this.spinnerService.IsVisible(true);
    this.usersService
      .isUserExists(this.userForm.get("userNameFormControl").value)
      .subscribe(
        (data) => {
          if (data.isUserExists) {
            window.sessionStorage.setItem("userName", this.userForm.get("userNameFormControl").value);
            window.sessionStorage.setItem("displayName", data.displayName);
            window.sessionStorage.setItem("userId", data.userId.toString());

            this.router.navigateByUrl("chatRoom");
          }
          this.spinnerService.IsVisible(false);
        },
        (error) => {
          this.spinnerService.IsVisible(false);
          //this.toast.show('Error occured while retrieving record', ToastType.Error)
        }
      );
  }
}