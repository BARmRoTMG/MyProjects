import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, Observable } from "rxjs";
import Movie from "../Models/Movie";

@Injectable()
class MovieService {

    private api: string = "http://localhost:3000/movies/";

    constructor(private httpClient: HttpClient){
        
    }

    get(){
        return this.httpClient.get(this.api).pipe(catchError((error: any, caught: Observable<any>): Observable<any> => {
            console.error("There was an error!", error);
            throw new Error(error.message);
        }));
    }

    post(newMovie: Movie){
        return this.httpClient.post(this.api, newMovie);
    }

    delete(id: number){
        return this.httpClient.delete(this.api + id);
    }

    put(id: number, movie: Movie){
        return this.httpClient.put(this.api + id, movie);
    }
}

export default MovieService;