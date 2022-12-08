class Project{
    Name: string;
    DueDate: Date;
    Description: string;
    Image: string;

    constructor(name: string, duedate: Date, description: string, image: string){
        this.Name = name;
        this.DueDate = duedate;
        this.Description = description;
        this.Image = image;
    }
    currentDate: Date = new Date();
}

export default Project;