import { Component, OnInit } from '@angular/core';

import { environment } from 'src/environments/environment';
import { AuthenticationRequestDto } from '../dtos/AuthenticationRequestDto';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public authenticationRequestDto: AuthenticationRequestDto = new AuthenticationRequestDto();
  private readonly AuthenticateUrl = environment.apiUrl + '/user/authenticate';

  ngOnInit(): void {
  }

  constructor() { }

  authenticate() {
    
  }
  
}
