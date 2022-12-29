import { Injectable } from "@angular/core";
import {
  IsUserExistsResponseModel,
  UserDetailsRequestModel,
} from "../models/user";
import { BaseService } from "./base.service";

@Injectable({
  providedIn: "root",
})
export class UsersService extends BaseService {
  public isUserExists(userName: string) {
    return this.http.get<IsUserExistsResponseModel>(
      `${this.baseURL}api/Users/is-user-exists/${userName}`
    );
  }

  public saveUserDetail(userDetailsRequestModel: UserDetailsRequestModel) {
    return this.http.post<number>(
      `${this.baseURL}api/Users/create-user`,
      userDetailsRequestModel
    );
  }
}
