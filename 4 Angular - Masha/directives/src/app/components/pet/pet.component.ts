import { Component, Input } from '@angular/core';
import Pet from 'src/app/models/Pet';

@Component({
  selector: 'pet',
  templateUrl: './pet.component.html',
  styleUrls: ['./pet.component.css']
})
export class PetComponent {
  @Input() data?: Pet;

  classList = "border shadow"
  classArray = ['border', 'shadow']
  className = 'black'
  counter = 0;

  addClassToList() {
    this.classArray.push('red');
  }

  changeStyle() {
    switch (this.counter) {
      case 0:
        this.className = 'black';
        this.counter++;
        break;
      case 1:
        this.className = 'red';
        this.counter++;
        break;
      case 2:
        this.className = 'green';
        this.counter++;
        break;
    }
  }
}
