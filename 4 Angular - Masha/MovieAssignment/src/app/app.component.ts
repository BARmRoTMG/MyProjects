import { Component } from '@angular/core';
import Movie from './Models/Movie';
import MovieService from './services/movie.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Movie Assignment';
  movies: Movie[] = [];
  newMovie: Movie = new Movie();
  isError = false;

  constructor(private movieService: MovieService) {
    movieService.get().subscribe({
      next: (data) => {
      this.movies = data as Movie[];
    },
    error: (error) => {
      this.isError = true;
    }
  })
  }

  //post
  addMovie() {
    this.movieService.post(this.newMovie)
      .subscribe((newMovie) => {
        this.movies.push(newMovie as Movie);
        return newMovie;
      })
  }
}
