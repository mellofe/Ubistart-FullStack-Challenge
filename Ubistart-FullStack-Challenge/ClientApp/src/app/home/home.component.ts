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

  constructor(private userDataService: UserDataService, private router: Router) { 
    this.userDataService.getUserTasks().subscribe((result) => {
      if (result) {
        this.Tasks = result;
        console.log(this.Tasks);
        this.updateDates();
        console.log(this.Tasks);
      } else {
        alert('Falha na busca de tarefas cadastradas pelo usuário.');
      }
    }, error => {
      console.log(error);
        alert('Falha na busca de tarefas cadastradas pelo usuário.');
    })
  }
  updateDates(){
    let defaultDate = "0001-01-01T00:00:00";
    this.Tasks.forEach(function (task){
      if(task.editDate === defaultDate){
        task.editDate = "-";
      }
      if(task.finishDate === defaultDate){
        task.finishDate = "-";
      }
    });
  }
  
}
