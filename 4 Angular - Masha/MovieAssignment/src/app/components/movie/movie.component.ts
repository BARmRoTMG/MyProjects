
import { Component, EventEmitter, Input, Output } from '@angular/core';
import Movie from 'src/app/Models/Movie';

@Component({
  selector: 'movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent {
  @Input() movieData?:Movie;

   toggleIsWatched(isWatched:any){
    if (isWatched.target.checked){
      this.movieData!.isWatched = true;
    } else {
      this.movieData!.isWatched = false;
    }
   }
}
