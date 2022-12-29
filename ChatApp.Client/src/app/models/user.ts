export class IsUserExistsResponseModel {
  isUserExists: boolean;
  userId: number;
  displayName: string;
}

export class User {
  userId: number;
  userName: string;
  displayName: string;
  isDeleted: boolean;
}

export class UserDetailsRequestModel {
  userName: string;
  displayName: string;
}
