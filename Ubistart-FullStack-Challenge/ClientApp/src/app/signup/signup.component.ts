import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { UserDataService } from '../data-services/user.data-service';
import { UserSignUpDto } from '../dtos/UserSignUpDto';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignUpComponent implements OnInit {
  public userSignUpDto: UserSignUpDto = new UserSignUpDto();

  ngOnInit(): void {
  }

  constructor(private userDataService: UserDataService, private router: Router) { }
  
  signup(){
    this.userDataService.signup(this.userSignUpDto).subscribe((response) => {
      if (response) {
        alert('Cadastro realizado com sucesso.');
        this.router.navigate(['']);
      } else {
        alert('Falha no cadastro.');
      }      
    }, error => {
      console.log(error);
        alert('Falha no cadastro.');
    })
  }
}
