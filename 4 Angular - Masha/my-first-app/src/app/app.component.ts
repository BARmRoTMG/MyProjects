import { Component } from '@angular/core';
import Cat from './models/Cat';
import Dog from './models/Dog';
import Person from './models/Person';
import Pet from './models/Pet';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  person: Person = new Person("Bar", 23);
  pet: Pet = new Pet("Giraffe", "Mammal", this.person);
  cat: Cat = new Cat("Ugly Cat", "Hairless", new Person("Koby"));
  dog: Dog = new Dog("Tofy", "Shi-Tzu", new Person("Bar", 23));

  title = 'My First App is Angular';
  src = "https://miro.medium.com/max/480/1*VKY-Ldkt-iHobItql7G_5w.png";

  onPlayHandler(){
    let result = this.cat.destroy('tv');
    console.log(result);
  }
}
