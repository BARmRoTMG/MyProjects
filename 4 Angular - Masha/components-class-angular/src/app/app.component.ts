import { Component } from '@angular/core';
import Person from './model/Person';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'components-class-angular';

  show: boolean = true;

  image = "https://www.shutterstock.com/image-photo/bandra-worli-sea-link-bridge-260nw-1423004933.jpg"

  width = 300;

  person: any = new Person("Bar", 23, "Givatayim");


  makeBigger(){
    this.width += 20;
  }

  makeSmaller(){
    this.width -= 20;
  }

  updateTitle(event: any){
    console.log(event)
    this.title = event.target.value;
  }

  updateName(event: any){
    this.person.name = event?.target.value;
  }

  updateAge(event: any){
    this.person.age = event?.target.value;
  }

  updatePerson(event: any){
    this.person[event.target.id] = event?.target.value;
  }

  updatePerson2(ref: any){
    this.person[ref.target.id] = ref?.target.value;
  }
}
