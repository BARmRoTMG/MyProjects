import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AirportApiService } from 'src/app/airport-api.service';

@Component({
  selector: 'airport',
  templateUrl: './airport.component.html',
  styleUrls: ['./airport.component.css']
})
export class AirportComponent implements OnInit{

  flightsList$!:Observable<any[]>;

  constructor(private service:AirportApiService) {}

  ngOnInit(): void {
    this.flightsList$ = this.service.getFlightsList();
  }
  
}
