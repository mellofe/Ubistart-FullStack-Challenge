export class TaskDisplayDto{
    public id: string;
    public description: string;
    public deadline: Date;
    public formatedDeadline: string;
    public status: string;
    constructor(id: string, description: string, deadline: Date, formatedDeadline: string, status: string){
        this.id = id;
        this.description = description;
        this.deadline = deadline;
        this.formatedDeadline = formatedDeadline;
        this.status = status;
    }
}