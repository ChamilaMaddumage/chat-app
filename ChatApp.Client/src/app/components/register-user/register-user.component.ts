import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormControl, FormGroup } from "@angular/forms";
import { Router } from "@angular/router";
import { UserDetailsRequestModel } from "src/app/models/user";
import { SpinnerService } from "src/app/services/spinner.service";
import { UsersService } from "src/app/services/users.service";

@Component({
  selector: "app-register-user",
  templateUrl: "./register-user.component.html",
  styleUrls: ["./register-user.component.css"],
})
export class RegisterUserComponent implements OnInit {
  public userName: string;
  public userForm: FormGroup;
  userNameFormControl: string = "userNameFormControl";
  displayNameFormControl: string = "displayNameFormControl";
  userDetailsRequestModel: UserDetailsRequestModel;

  constructor(
    private router: Router,
    private usersService: UsersService,
    public spinnerService: SpinnerService,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit() {
    this.userForm = this.formBuilder.group({
      userNameFormControl: new FormControl(""),
      displayNameFormControl: new FormControl(""),
    });
  }

  private onRegister() {
    this.spinnerService.IsVisible(true);

    this.spinnerService.IsVisible(true);
    this.usersService
      .isUserExists(this.userForm.get("userNameFormControl").value)
      .subscribe(
        (data) => {
          if (data.isUserExists) {
            //already exits
          } else {
            var userDetailsRequestModel = new UserDetailsRequestModel();
            userDetailsRequestModel.displayName = this.userForm.get(
              "displayNameFormControl"
            ).value;
            userDetailsRequestModel.userName = this.userForm.get(
              "userNameFormControl"
            ).value;

            this.usersService.saveUserDetail(userDetailsRequestModel).subscribe(
              (x) => {
                if (x > 0) {
                  this.spinnerService.IsVisible(false);
                  this.router.navigateByUrl("");
                  //success
                }
              },
              (error) => {
                this.spinnerService.IsVisible(false);
                //this.toast.show('Error occured while saving record', ToastType.Error);
              }
            );
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