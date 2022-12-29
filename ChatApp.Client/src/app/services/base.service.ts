import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root",
})
export class BaseService {
  public httpClient: HttpClient;
  public baseURL = environment.baseApi;

  constructor(public http: HttpClient) {
    this.httpClient = http;
  }
}
