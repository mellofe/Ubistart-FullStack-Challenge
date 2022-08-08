import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { LoginComponent } from '../login/login.component';

import { UserDataService } from '../data-services/user.data-service';
import { TaskDto } from '../dtos/TaskDto';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public Tasks: TaskDto[];

  ngOnInit(): void {
    if(!LoginComponent.getIsAuthenticated()){
      this.router.navigate(['']);
      alert('Faça login para acessar essa página.');
    }
  }

  constructor(private userDataService: UserDataService, private router: Router) { }
  
}
