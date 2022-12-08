import { Component } from '@angular/core';
import Movie from './Models/Movie';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Movie Assignment';
  src = "https://m.media-amazon.com/images/M/MV5BMjIxMjgxNTk0MF5BMl5BanBnXkFtZTgwNjIyOTg2MDE@._V1_.jpg";

  movie: Movie = new Movie("The Wolf of Wall Street", 2013, "The Wolf of Wall Street is a 2013 American biographical black comedy crime film directed by Martin Scorsese", this.src, true);
}
