import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { LoginComponent } from '../login/login.component';

import { UserDataService } from '../data-services/user.data-service';
import { TaskDto } from '../dtos/TaskDto';
import { TaskDisplayDto } from '../dtos/TaskDisplayDto';

import { faPencil, faCheck, faTimes } from '@fortawesome/free-solid-svg-icons';

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
  defaultDate: Date = new Date("0001-01-01T00:00:00");
  faPencil = faPencil;
  faCheck = faCheck;
  faTimes = faTimes;

  ngOnInit(): void {
    if(!LoginComponent.getIsAuthenticated()){
      this.router.navigate(['']);
      alert('Faça login para acessar essa página.');
    } else{
      this.getUserTasks();
    }
  }
  constructor(private userDataService: UserDataService, private router: Router) { 
  }
    
  updateDates(){
    let dateNow: Date = new Date();
    let status: string;
    this.Tasks.forEach(task => {
      let deadline = new Date(task.deadline);
      let finishDate = new Date(task.finishDate);
      
      if(!(finishDate.toDateString() === this.defaultDate.toDateString())){
        status = "Tarefa concluida."
      } else if(deadline < dateNow){
        status = "Tarefa atrasada."
      } else{
        status = "Tarefa em andamento."
      }

      this.DisplayTasks.push(new TaskDisplayDto(task, this.formateDate(deadline), status));
    });
  }

  formateDate(date: Date){
    return date.toLocaleDateString('pt-BR', {timeZone: 'UTC'});
  }

  editTaskDetails(task: TaskDisplayDto){
    this.isEditingTask = true;
    this.editingTask = task;
  }

  setTaskDone(task: TaskDisplayDto){
    let finishedTask: TaskDto = new TaskDto(task);
    finishedTask.finishDate = new Date();

    this.putEditedTask(finishedTask);
    this.router.navigate(['']);
  }

  finishTaskEditing(){
    let editedTask: TaskDto = new TaskDto(this.editingTask);
    editedTask.editDate = new Date();

    this.putEditedTask(editedTask);

    this.isEditingTask = false;
    this.router.navigate(['']);
  }

  exitTaskEdit(){
    this.isEditingTask = false;
  }

  getUserTasks(){
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

  putEditedTask(editedTask: TaskDto){
    this.userDataService.editTask(editedTask).subscribe(data => {
      if (data) {
        alert('Tarefa atualizada com sucesso.');
      } else {
        alert('Falha na atualização da tarefa.');
      }
    }, error => {
      console.log(error);
      alert('Falha na atualização da tarefa.');
    })
  }
  
}
