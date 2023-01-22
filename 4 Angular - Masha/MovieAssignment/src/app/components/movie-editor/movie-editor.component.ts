import { Component, EventEmitter, Input, Output } from '@angular/core';
import Movie from 'src/app/Models/Movie';
import MovieService from 'src/app/services/movie.service';

@Component({
  selector: 'movie-editor',
  templateUrl: './movie-editor.component.html',
  styleUrls: ['./movie-editor.component.css']
})
export class MovieEditorComponent {
  @Input() EditData? : any;
  @Input() buttonText?: string;
  @Output() update:EventEmitter<any> = new EventEmitter<any>();

  updateData(id:string, watched:boolean, name: string, years: string, description: string, image: string){
    this.EditData = new Movie(Number(id), name, Number(years), description, image, watched);
    this.update.emit(this.EditData);
  }
}
