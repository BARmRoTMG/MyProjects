import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AirportApiService {

  readonly airportAPIUrl = "https://localhost:7126/api/airport";

  constructor(private http: HttpClient) { }

  getFlightsList(): Observable<any[]> {
    return this.http.get<any[]>(this.airportAPIUrl + '/get');
  }

  addFlight(data: any) {
    return this.http.post(this.airportAPIUrl + '', data)
  }

  updateFlight(id: number | string, data: any) {
    return this.http.put(this.airportAPIUrl + `/${id}`, data);
  }

  deleteFlight(id: number | string) {
    return this.http.delete(this.airportAPIUrl + `/${id}`)
  }

  //GET ENUMS
  getFlightTypesList(): Observable<any[]> {
    return this.http.get<any[]>(this.airportAPIUrl + '/get');
  }
}
