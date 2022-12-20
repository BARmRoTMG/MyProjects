
import { Component, EventEmitter, Input, Output } from '@angular/core';
import Movie from 'src/app/Models/Movie';

@Component({
  selector: 'movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent {
  @Input() movieData?:Movie;

  @Output() remove: EventEmitter<any> = new EventEmitter<any>();
  @Output() duplicate: EventEmitter<any> = new EventEmitter<any>();
  @Output() update: EventEmitter<any> = new EventEmitter<any>();

  onDeleteHandler(){
    this.remove.emit(this.movieData?.name);
  }

  onDuplicateHandler(){
    this.duplicate.emit(this.movieData);
  }

  onUpdateHandler(){
    this.update.emit(this.movieData)
  }

  updateFUNCTION(name:any, year:any, description:any){

     this.movieData!.name = name.value;
     this.movieData!.year = year.value;
     this.movieData!.description = description.value;
   }

   toggleIsWatched(isWatched:any){
    if (isWatched.target.checked){
      this.movieData!.isWatched = true;
    } else {
      this.movieData!.isWatched = false;
    }
   }
}
