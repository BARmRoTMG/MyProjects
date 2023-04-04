import { Component, OnInit, AfterViewInit } from '@angular/core';
import { BookDetailsService } from 'src/app/services/book-details.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, AfterViewInit {

  constructor (private service: BookDetailsService) {}

  tourData:any;
  reviewData:any;


  ngOnInit(): void {
    this.tourData = this.service.tours;
    this.reviewData = this.service.reviews;
  }

  ngAfterViewInit() {
    const script = document.createElement('script');
    script.src = './assets/main.js';
    document.body.appendChild(script);
  }

}
