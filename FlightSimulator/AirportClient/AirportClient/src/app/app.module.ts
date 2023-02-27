import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AirportComponent } from './components/airport/airport.component';

import { AirportApiService } from './airport-api.service';
import { ClockComponent } from './components/clock/clock.component';
import { DeparturesComponent } from './components/departures/departures.component';
import { LandingsComponent } from './components/landings/landings.component';

@NgModule({
  declarations: [
    AppComponent,
    AirportComponent,
    ClockComponent,
    DeparturesComponent,
    LandingsComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [AirportApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
