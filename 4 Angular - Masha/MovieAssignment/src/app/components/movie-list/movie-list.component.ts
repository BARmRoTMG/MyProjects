import { Component } from '@angular/core';
import Movie from 'src/app/Models/Movie';

@Component({
  selector: 'movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css']
})
export class MovieListComponent {
  movies: Movie[] = 
  [
    new Movie("The Wolf of Wall Street", 2013, "The Wolf of Wall Street is a 2013 American biographical black comedy crime film directed by Martin Scorsese", "https://m.media-amazon.com/images/M/MV5BMjIxMjgxNTk0MF5BMl5BanBnXkFtZTgwNjIyOTg2MDE@._V1_.jpg", true),
    new Movie("Shrek", 2001, "Shrek is a 2001 American computer-animated fantasy comedy film loosely based on the 1990 book of the same name by William Steig.", "https://m.media-amazon.com/images/I/81zg+bAdjVS._RI_.jpg", true),
    new Movie("Avatar", 2009, "Epic science fiction film directed, written, co-produced and co-edited by James Cameron.", "https://upload.wikimedia.org/wikipedia/en/d/d6/Avatar_%282009_film%29_poster.jpg", false)
  ]

  removeMovie(name: string) {
    this.movies = this.movies.filter(m => m.name != name)
  }

  duplicateMovie(movie: Movie) {
    let m = {...movie};
    m.name = movie.name + " *duplicated*";
    this.movies.push(m);
  }

  updateMovie(movie: Movie) {
    
  }

  addMovie(movie: Movie) {
    this.movies.push(movie);
  }
}
