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
    } else{
      this.userDataService.getUserTasks().subscribe((result) => {
        if (result) {
          this.Tasks = result;
          this.updateDates();
        } else {
          alert('Falha na busca de tarefas cadastradas pelo usuário.');
        }
      }, error => {
        console.log(error);
          alert('Falha na busca de tarefas cadastradas pelo usuário.');
      })
    }
  }
  constructor(private userDataService: UserDataService, private router: Router) { 
  }
    
  updateDates(){
    let date: Date;
    let dateNow: Date = new Date();
    let status: string;
    this.Tasks.forEach(task => {
      let deadline = new Date(task.deadline);
      if(deadline < dateNow){
        status = "Tarefa atrasada."
      } else{
        status = "Tarefa em andamento."
      }
      date = new Date(task.deadline);
      this.DisplayTasks.push(new TaskDisplayDto(task.description, date.toLocaleDateString('pt-BR', {timeZone: 'UTC'}), status));
    });
  }
}
