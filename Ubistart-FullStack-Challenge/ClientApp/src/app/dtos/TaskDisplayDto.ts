import { TaskDto } from "./TaskDto";

export class TaskDisplayDto{
    public id: string;
    public email: string;
    public insertionDate: Date;
    public description: string;
    public deadline: Date;
    public finishDate: Date;
    public editDate: Date;
    public formatedDeadline: string;
    public status: string;

    constructor(task: TaskDto, formatedDeadline: string, status: string){
        this.id = task.idTask;
        this.email = task.email;
        this.insertionDate = task.insertionDate;
        this.description = task.description;
        this.deadline = task.deadline;
        this.finishDate = task.finishDate;
        this.editDate = task.editDate;
        this.formatedDeadline = formatedDeadline;
        this.status = status;
    }
}