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
  public authenticationRequestDto: AuthenticationRequestDto = new AuthenticationRequestDto();
  static authenticationResponseDto: AuthenticationResponseDto;
  static isAuthenticated: any;
  static token: any;
  static getIsAuthenticated(): any {
    return this.isAuthenticated;
  }
  static getToken(): any {
    return this.token;
  }

  ngOnInit(): void {
  }
  
  constructor(private userDataService: UserDataService, private router: Router) { }

  authenticate() {
    this.userDataService.authenticate(this.authenticationRequestDto).subscribe((authenticationResponseDto:AuthenticationResponseDto) => {
      if (authenticationResponseDto.userDto) {
        LoginComponent.isAuthenticated = true;
        LoginComponent.token = authenticationResponseDto.token;
        console.log(LoginComponent.token);
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
