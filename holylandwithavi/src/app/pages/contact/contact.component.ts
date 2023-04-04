import { Component } from '@angular/core';
import emailjs, { EmailJSResponseStatus } from '@emailjs/browser';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent {
  public sendEmail(e: Event) {
    e.preventDefault();
    emailjs.sendForm('service_a2qlc3m', 'template_6cje9no', e.target as HTMLFormElement, 'sZilIYBIM8FkLA-I8')
      .then((result: EmailJSResponseStatus) => {
        console.log(result.text);
      }, (error) => {
        console.log(error.text);
      });
  }
}