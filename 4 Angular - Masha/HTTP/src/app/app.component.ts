import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import Image from './model/image.model';
import ImageService from './services/image.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'http';
  images: Image[] = [];
  newImage: Image = new Image();
  isError = false;

  now: Date = new Date();
  price: number = 65.356656;
  number = 3;

  constructor(private imageService: ImageService){
      imageService.get().subscribe({
        next: (data)=>{
          this.images = data as Image[];
        },
        error: (error)=>{
          this.isError = true;
        }
      })
  }

  addImage(){
    this.imageService.post(this.newImage)
        .subscribe((newImage)=>{
            this.images.push(newImage as Image)
            return newImage;
        }) 
  }

  deleteImage(id:number){
    this.imageService.delete(id).subscribe(()=>{
      this.images = this.images.filter(image => image.id != id);
    })
  }
}
