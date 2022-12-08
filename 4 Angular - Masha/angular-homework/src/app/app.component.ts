import { Component } from '@angular/core';
import Project from './models/Project';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Project Information';
  description = "Present a project on the main page of your angular project, and show the name of the project, a picutre, is the date already dued and add a description.";
  img = "https://static.vecteezy.com/system/resources/previews/007/004/138/non_2x/notebook-illustration-on-a-background-premium-quality-symbols-icons-for-concept-and-graphic-design-vector.jpg";
  project: Project = new Project("Angular Homework Project", new Date("2022-12-09"), this.description, this.img);

  isDue: boolean = true;

  checkduedate(){
    if(this.project.currentDate > this.project.DueDate){
      this.isDue = true;
      console.log("You've ran out of time to submit the project!");
      alert("You've ran out of time to submit the project!");
    }
    this.isDue = false;
    console.log("You still have time to submit the project!");
    alert("You still have time to submit the project!");
  }
}
