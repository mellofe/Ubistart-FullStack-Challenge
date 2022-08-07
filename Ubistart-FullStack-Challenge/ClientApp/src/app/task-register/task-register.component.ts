import { Component, OnInit } from '@angular/core';
import { UserDataService } from '../data-services/user.data-service';

import { TaskRegisterDto } from '../dtos/TaskRegisterDto';

@Component({
  selector: 'app-task-register',
  templateUrl: './task-register.component.html',
  styleUrls: ['./task-register.component.css']
})
export class TaskRegisterComponent implements OnInit {
  public taskRegisterDto: TaskRegisterDto = new TaskRegisterDto();

  ngOnInit(): void {
  }

  constructor(private userDataService: UserDataService) { }
  
  taskRegister(){
    this.userDataService.taskRegister(this.taskRegisterDto).subscribe((response) => {
      if (response) {
        alert('Cadastro de tarefa realizado com sucesso.');
      } else {
        alert('Falha no cadastro da tarefa.');
      }      
    }, error => {
      console.log(error);
        alert('Falha no cadastro da tarefa.');
    })
  }
}
