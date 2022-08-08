export class TaskDisplayDto{
    public description: string;
    public deadline: string;
    public status: string;
    constructor(description: string, deadline: string, status: string){
        this.description = description;
        this.deadline = deadline;
        this.status = status;
    }
}