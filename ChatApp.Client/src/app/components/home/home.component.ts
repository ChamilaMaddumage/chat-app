import { Component, OnInit } from "@angular/core";
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from "@angular/forms";
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
  chatRoomFormControl: string = "chatRoomFormControl";

  constructor(
    private router: Router,
    private usersService: UsersService,
    public spinnerService: SpinnerService,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit() {
    this.userForm = this.formBuilder.group({
      userNameFormControl: new FormControl("", [Validators.required]),
      chatRoomFormControl: new FormControl("", [Validators.required]),
    });
  }

  onRegister() {
    this.router.navigateByUrl("registerUser");
  }

  onJoin() {
    if (
      this.userForm.get("userNameFormControl").value == "" ||
      this.userForm.get("chatRoomFormControl").value == ""
    ) {
      window.alert("Please fill required fields");
      return;
    }
    this.usersService
      .isUserExists(this.userForm.get("userNameFormControl").value)
      .subscribe(
        (data) => {
          if (data.isUserExists) {
            if (
              this.userForm
                .get("chatRoomFormControl")
                .value.toString()
                .toLowerCase() != "pt room"
            ) {
              this.userForm.controls["chatRoomFormControl"].setErrors({
                invalid: true,
              });
              return;
            } else {
              window.sessionStorage.setItem(
                "userName",
                this.userForm.get("userNameFormControl").value
              );
              window.sessionStorage.setItem("displayName", data.displayName);
              window.sessionStorage.setItem("userId", data.userId.toString());

              this.router.navigateByUrl("chatRoom");
            }
          } else {
            this.userForm.controls["userNameFormControl"].setErrors({
              invalid: true,
            });
          }
        },
        (error) => {
          window.alert("Error Occured"); //Error
        }
      );
  }
}
