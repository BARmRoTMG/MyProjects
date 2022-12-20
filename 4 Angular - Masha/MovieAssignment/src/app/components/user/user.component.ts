import { Component, EventEmitter, Input, Output } from '@angular/core';
import User from 'src/app/Models/User';

@Component({
  selector: 'user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent {
  @Input() userData?:User;

  user: User = new User("Bar the King", 123321, "Bar Mashiach", "barmashiach@email.com");

  update(name:any, username:any, password:any, email:any){

    this.user.name = name.value;
    this.user.username = username.value;
    this.user.password = password.value;
    this.user.email = email.value;
  }
}
