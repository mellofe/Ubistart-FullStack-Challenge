import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { UserDataService } from '../data-services/user.data-service';
import { AuthenticationRequestDto } from '../dtos/AuthenticationRequestDto';
import { AuthenticationResponseDto } from '../dtos/AuthenticationResponseDto';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  private authenticationRequestDto: AuthenticationRequestDto = new AuthenticationRequestDto();
  private static isAuthenticated: boolean;
  private static token: string;

  static getIsAuthenticated(): boolean {
    return this.isAuthenticated;
  }
  static setIsAuthenticated(isAuthenticated: boolean){
    LoginComponent.isAuthenticated = isAuthenticated;
  }
  static getToken(): string {
    return this.token;
  }

  ngOnInit(): void {
    if(LoginComponent.getIsAuthenticated()){
      this.router.navigate(['/home']);
    }
  }
  
  constructor(private userDataService: UserDataService, private router: Router) { }

  private authenticate() {
    this.userDataService.authenticate(this.authenticationRequestDto).subscribe((result: AuthenticationResponseDto) => {
      if (result) {
        LoginComponent.isAuthenticated = true;
        LoginComponent.token = result.token;
        this.router.navigate(['/home']);
      } else {
        alert('Usuário/senha invalidos.');
      }      
    }, error => {
      console.log(error);
        alert('Usuário/senha invalidos.');
    })
  }
  
}
