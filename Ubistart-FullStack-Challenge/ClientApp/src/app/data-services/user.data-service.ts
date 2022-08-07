import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class UserDataService {

  module: string = '/api/user';

  constructor(private http: HttpClient) { }

  authenticate(data: any) {
    return this.http.post(this.module + '/authenticate', data);
  }
  signup(data: any){
    return this.http.post(this.module + '/signup', data);
  }
  taskRegister(data: any){
    return this.http.post(this.module + '/taskregister', data);
  }
}