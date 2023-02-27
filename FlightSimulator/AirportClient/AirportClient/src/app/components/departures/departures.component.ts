import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AirportApiService } from 'src/app/airport-api.service';

@Component({
  selector: 'departures',
  templateUrl: './departures.component.html',
  styleUrls: ['./departures.component.css']
})
export class DeparturesComponent implements OnInit{
  flightsList$!: Observable<any[]>;

  constructor(private service: AirportApiService) { }

  ngOnInit(): void {
    this.flightsList$ = this.service.getFlightsList();
  }
}
