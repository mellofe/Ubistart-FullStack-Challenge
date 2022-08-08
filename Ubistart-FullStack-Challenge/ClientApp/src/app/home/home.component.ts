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
    this.userDataService.getUserTasks().subscribe((result) => {
      if (result) {
        this.Tasks = result;
      } else {
        alert('Falha na busca de tarefas cadastradas pelo usuário.');
      }
    }, error => {
      console.log(error);
        alert('Falha na busca de tarefas cadastradas pelo usuário.');
    })
  }

  constructor(private userDataService: UserDataService, private router: Router) { }
  
}
