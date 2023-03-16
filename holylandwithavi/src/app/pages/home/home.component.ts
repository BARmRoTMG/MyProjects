import { Component, OnInit } from '@angular/core';
import { BookDetailsService } from 'src/app/services/book-details.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor (private service: BookDetailsService) {}

  tourData:any;

  ngOnInit(): void {
    this.tourData = this.service.tours;
  }

}
