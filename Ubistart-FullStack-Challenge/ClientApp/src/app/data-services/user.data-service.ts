import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class UserDataService {

  userModule: string = '/api/user';
  taskModule: string = '/api/task';

  constructor(private http: HttpClient) { }

  authenticate(data: any) {
    return this.http.post(this.userModule + '/authenticate', data);
  }
  signup(data: any){
    return this.http.post(this.userModule + '/signup', data);
  }
  taskRegister(data: any){
    return this.http.post(this.taskModule + '/taskregister', data);
  }
}