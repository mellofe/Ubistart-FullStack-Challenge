import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserDataService } from '../data-services/user.data-service';

import { TaskRegisterDto } from '../dtos/TaskRegisterDto';
import { LoginComponent } from '../login/login.component';

@Component({
  selector: 'app-task-register',
  templateUrl: './task-register.component.html',
  styleUrls: ['./task-register.component.css']
})
export class TaskRegisterComponent implements OnInit {
  public taskRegisterDto: TaskRegisterDto = new TaskRegisterDto();

  ngOnInit(): void {
    if(!LoginComponent.getIsAuthenticated()){
      this.router.navigate(['']);
      alert('Faça login para acessar essa página.');
    }
  }

  constructor(private userDataService: UserDataService, private router: Router) { }
  
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
