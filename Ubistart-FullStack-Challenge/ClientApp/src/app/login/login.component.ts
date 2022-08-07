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
  public authenticationResponseDto: AuthenticationResponseDto = new AuthenticationResponseDto();
  public isAuthenticated = false;

  ngOnInit(): void {
  }

  constructor(private userDataService: UserDataService, private router: Router) { }

  authenticate() {
    this.userDataService.authenticate(this.authenticationRequestDto).subscribe((authenticationResponseDto:AuthenticationResponseDto) => {
      if (authenticationResponseDto.userDto) {
        this.isAuthenticated = true;
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
