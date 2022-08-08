import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { LoginComponent } from '../login/login.component';

import { UserDataService } from '../data-services/user.data-service';
import { TaskDto } from '../dtos/TaskDto';
import { TaskDisplayDto } from '../dtos/TaskDisplayDto';

import { faPencil, faCheck } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  private isEditingTask = false;
  private Tasks: TaskDto[];
  private DisplayTasks: TaskDisplayDto[] = [];
  private editingTask: TaskDisplayDto;
  faPencil = faPencil;
  faCheck = faCheck

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
    let dateNow: Date = new Date();
    let status: string;
    this.Tasks.forEach(task => {
      let deadline = new Date(task.deadline);
      if(deadline < dateNow){
        status = "Tarefa atrasada."
      } else{
        status = "Tarefa em andamento."
      }
      this.DisplayTasks.push(new TaskDisplayDto(task.idTask, task.description, task.deadline, this.formateDate(deadline), status));
    });
  }
  formateDate(date: Date){
    return date.toLocaleDateString('pt-BR', {timeZone: 'UTC'});
  }
  editTaskDetails(task: TaskDisplayDto){
    this.isEditingTask = true;
    this.editingTask = task;
  }
  finishEditing(){
    this.editingTask.formatedDeadline = this.formateDate(this.editingTask.deadline);
    console.log(this.editingTask);
  }
}
