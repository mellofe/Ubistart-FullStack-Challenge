import * as internal from "assert";
import { TaskDisplayDto } from "./TaskDisplayDto";

export class TaskDto{
    public idTask: string;
    public insertionDate: Date;
    public description: string;
    public deadline: Date;
    public finishDate: Date;
    public editDate: Date;
    public userFk: string;
    public email: string;

    constructor(displayTask: TaskDisplayDto){
        this.idTask = displayTask.id;
        this.insertionDate = displayTask.insertionDate;
        this.description = displayTask.description;
        this.deadline = displayTask.deadline;
        this.finishDate = displayTask.finishDate;
        this.editDate = displayTask.editDate;
    }
}