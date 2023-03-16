import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookDetailsService } from 'src/app/services/book-details.service';

@Component({
  selector: 'app-tour-page',
  templateUrl: './tour-page.component.html',
  styleUrls: ['./tour-page.component.css']
})
export class TourPageComponent implements OnInit {

  constructor(private param: ActivatedRoute, private service: BookDetailsService) { }

  getTourId: any;
  tourData: any;

  ngOnInit(): void {
    this.getTourId = this.param.snapshot.paramMap.get('id');
    console.log(this, this.getTourId, 'gettourid');

    if (this.getTourId) {
      this.tourData = this.service.tours.filter((value) => {
        return value.id == this.getTourId;
      });
    }
  }
}
