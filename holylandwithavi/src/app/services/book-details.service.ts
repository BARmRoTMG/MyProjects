import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BookDetailsService {

  constructor() { }

  tours =
    [
      {
        id: 1,
        title: "Private Day Trip to the Old City in Jerusalem",
        description: "We will visit the Old City of Jerusalem with a history of over 3,000 years We will see all the important holy sites in the Old City and beyond, The trip can be tailored to customer preferences, the price is up to 4 participant",
        price: 600,
        img: "https://imgcdn.bokun.tools/7bbc6017-6966-4308-8f29-90896919ed0a.jpg"
      },
      {
        id: 2,
        title: "Private Day Trip to the Dead Sea",
        description: "Experienced driver with in-depth knowledge of the area, rich history, religion and more, large and spacious vehicle suitable for up to 4 passengers.",
        price: 550,
        img: "https://images.unsplash.com/photo-1529066516367-36973222c957?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80"
      }
    ]
}
