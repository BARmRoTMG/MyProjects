import { Component } from '@angular/core';
import Movie from 'src/app/Models/Movie';
import MovieService from 'src/app/services/movie.service';

@Component({
  selector: 'movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css']
})
export class MovieListComponent {
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

  duplicateMovie(movie: Movie) {
    movie.id = Math.floor(Math.random() * 10000);
    this.movieService.post(movie).subscribe((movie) => {
      this.movies.push(movie as Movie);
    })
  }

  updateMovie(movie: Movie) {
    let m = this.movies.find(m => m.id == movie.id);
    m!.image = movie.image;
    m!.name = movie.name;
    m!.year = movie.year;
    m!.description = movie.description;
    m!.isWatched = movie.isWatched;

    this.movieService.put(m!.id, movie).subscribe();
  }

  deleteMovie(id: number) {
    this.movieService.delete(id).subscribe(() => {
      this.movies = this.movies.filter(m => m.id != id)
    })
  }
}
