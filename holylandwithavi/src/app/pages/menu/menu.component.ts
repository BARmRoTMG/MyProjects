import { Component, OnInit } from '@angular/core';
import { BookDetailsService } from 'src/app/services/book-details.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit{

  constructor (private service:BookDetailsService) {}

  tourData:any;

  ngOnInit(): void {
    this.tourData = this.service.tours;
  }
}
