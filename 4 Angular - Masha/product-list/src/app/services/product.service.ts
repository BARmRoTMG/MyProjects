import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable } from 'rxjs';
import Product from '../model/product.model';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private url = "http://localhost:4100/products/";

  constructor(private httpClient: HttpClient) { }

  get() {
    return this.httpClient.get(this.url)
      .pipe(catchError((error: any) => {
        // this.errorMessage = error.message;
        console.error('There was an error!', error);

        // after handling error, return a new observable 
        // that doesn't emit any values and completes
        throw new Error(error.message)
      }))
  }

  getById(id: number){
    return this.httpClient.get(this.url+id)
    .pipe(catchError((error: any) => {
      // this.errorMessage = error.message;
      console.error('There was an error!', error);

      // after handling error, return a new observable 
      // that doesn't emit any values and completes
      throw new Error(error.message)
    }))
  }

  post(newProduct: Product) {
    return this.httpClient.post(this.url, newProduct)
      .pipe(catchError((error: any) => {
        console.error('There was an error!', error);
        throw new Error(error.message)
      }))
  }

  put(product?: Product) {
    return this.httpClient.put(this.url + product?.id, product)
      .pipe(catchError((error: any) => {
        console.error('There was an error!', error);
        throw new Error(error.message)
      }))
  }

  delete(id: number) {
    return this.httpClient.delete(this.url + id)
      .pipe(catchError((error: any) => {
        console.error('There was an error!', error);
        throw new Error(error.message)
      }));
  }

}
