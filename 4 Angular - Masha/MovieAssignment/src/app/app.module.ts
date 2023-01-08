import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { MovieListComponent } from './components/movie-list/movie-list.component';
import { MovieComponent } from './components/movie/movie.component';
import { UserComponent } from './components/user/user.component';
import { MovieEditorComponent } from './components/movie-editor/movie-editor.component';
import MovieService from './services/movie.service';

@NgModule({
  declarations: [
    AppComponent,
    MovieListComponent,
    MovieComponent,
    UserComponent,
    MovieEditorComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [MovieService],
  bootstrap: [AppComponent]
})
export class AppModule { }
