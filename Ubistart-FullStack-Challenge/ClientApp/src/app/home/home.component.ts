import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { LoginComponent } from '../login/login.component';

import { UserDataService } from '../data-services/user.data-service';
import { TaskDto } from '../dtos/TaskDto';
import { TaskDisplayDto } from '../dtos/TaskDisplayDto';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public Tasks: TaskDto[];
  public DisplayTasks: TaskDisplayDto[] = [];

  ngOnInit(): void {
    if(!LoginComponent.getIsAuthenticated()){
      this.router.navigate(['']);
      alert('Faça login para acessar essa página.');
    }
    this.userDataService.getUserTasks().subscribe((result) => {
      if (result) {
        this.Tasks = result;
        this.DisplayTasks = this.updateDates();
      } else {
        alert('Falha na busca de tarefas cadastradas pelo usuário.');
      }
    }, error => {
      console.log(error);
        alert('Falha na busca de tarefas cadastradas pelo usuário.');
    })
  }
  updateDates(){
    let date: Date;
    let dateNow: Date = new Date();
    let DisplayTasksArray: TaskDisplayDto[] = [];
    let status: string;
    this.Tasks.forEach(function (task){
      if(task.deadline < dateNow){
        status = "A tarefa está atrasada."
      } else{
        status = "A tarefa está em dia."
      }
      date = new Date(task.deadline);
      DisplayTasksArray.push(new TaskDisplayDto(task.description, date.toLocaleDateString('pt-BR', {timeZone: 'UTC'}), status));
    });
    return DisplayTasksArray;
  }
  
}
