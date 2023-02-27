import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AirportApiService } from 'src/app/airport-api.service';

@Component({
  selector: 'landings',
  templateUrl: './landings.component.html',
  styleUrls: ['./landings.component.css']
})
export class LandingsComponent implements OnInit{
  flightsList$!: Observable<any[]>;

  constructor(private service: AirportApiService) { }

  ngOnInit(): void {
    this.flightsList$ = this.service.getFlightsList();
  }
}
