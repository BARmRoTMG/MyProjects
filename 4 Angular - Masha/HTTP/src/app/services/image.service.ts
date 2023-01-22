import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, Observable } from "rxjs";
import Image from "../model/image.model";

@Injectable()
class ImageService {

    private api: string = "http://localhost:3000/images/";

    constructor(private httpClient: HttpClient){}

    get(){
        return this.httpClient.get(this.api)
                              .pipe(catchError((error: any, caught: Observable<any>): Observable<any> => {
                                   // this.errorMessage = error.message;
                                    console.error('There was an error!', error);

                                    // after handling error, return a new observable 
                                    // that doesn't emit any values and completes
                                    throw new Error(error.message)
                              }))
    }

    post(newImage: Image){
        return this.httpClient
        .post(this.api, newImage)
    }

    delete(id:number){
        return  this.httpClient.delete(this.api+id)
    }

    put(id:number, image: Image){
        return this.httpClient.put(this.api+id, image)

    }

}

export default ImageService;