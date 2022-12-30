import { Component, OnInit } from "@angular/core";
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from "@angular/forms";
import { Router } from "@angular/router";
import { UserDetailsRequestModel } from "src/app/models/user";
import { SpinnerService } from "src/app/services/spinner.service";
import { ToastService } from "src/app/services/toast.service";
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
    private formBuilder: FormBuilder,
    public toast: ToastService
  ) {}

  ngOnInit() {
    this.userForm = this.formBuilder.group({
      userNameFormControl: new FormControl("", [Validators.required]),
      displayNameFormControl: new FormControl("", [Validators.required]),
    });
  }

  private onRegister() {
    if (
      this.userForm.get("userNameFormControl").value == "" ||
      this.userForm.get("displayNameFormControl").value == ""
    ) {
      window.alert("Please fill required fields");
      return;
    }
    this.usersService
      .isUserExists(this.userForm.get("userNameFormControl").value)
      .subscribe(
        (data) => {
          if (data.isUserExists) {
            window.alert("User Already Exists"); //user already exists
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
                  this.router.navigateByUrl("");
                  window.alert("User Succefully Created"); //success
                }
              },
              (error) => {
                window.alert("Error Occured"); //Error
              }
            );
          }
        },
        (error) => {
          window.alert("Error Occured"); //Error
        }
      );
  }
}
