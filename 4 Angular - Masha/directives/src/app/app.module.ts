import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { PetListComponent } from './components/pet-list/pet-list.component';
import { PetComponent } from './components/pet/pet.component';

@NgModule({
  declarations: [
    AppComponent,
    PetListComponent,
    PetComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
