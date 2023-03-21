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
        time: "6 hours and 30 minutes",
        difficulty: "Easy",
        img: "https://imgcdn.bokun.tools/7bbc6017-6966-4308-8f29-90896919ed0a.jpg"
      },
      {
        id: 2,
        title: "Private Day Trip to the Dead Sea",
        description: "Experienced driver with in-depth knowledge of the area, rich history, religion and more, large and spacious vehicle suitable for up to 4 passengers.",
        price: 550,
        time: "5 hours",
        difficulty: "Easy",
        img: "https://images.unsplash.com/photo-1529066516367-36973222c957?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80"
      },
      {
        id: 3,
        title: "Day Tour in Tel-Aviv - Walking Tour",
        description: "Together we traveled in the time machine more than 110 years back and we will reach the sand dunes on which Kokma Tel Aviv, who were the people behind the stories, the places, and how it all relates to Herzl, the thinker of the idea of the Jewish state. And from there we will continue in the time machine to Jaffa of 3500 years ago.",
        price: 470,
        time: "6 hours and 30 minutes",
        difficulty: "Easy",
        img: "https://imgcdn.bokun.tools/c0b8bc11-a7da-44f7-82ef-5dd7baabee3b.jpeg"
      },
      {
        id: 4,
        title: "VIP Pick-Up from Ben-Gurion Airport to Jerusalem",
        description: "The driver will wait for you on the arrival all with your name on singe. personal service with a professional driver with a modern and spacious vehicle. The service does not include entry into Palestinian territories.",
        price: 149,
        time: "1 hour",
        difficulty: "Easy",
        img: "https://imgcdn.bokun.tools/9a98fbd3-d2ee-4db3-aca0-99171251b33f.jpeg"
      },
      {
        id: 5,
        title: "VIP Pick-Up from Ben-Gurion Airport to Tel-Aviv",
        description: "Personal and professional service Adherence to schedule Careful and experienced driver Courteous, with high service consciousness The price includes 1 hour of waiting from the time of booking. If the passenger does not arrive, after 45 minutes an attempt will be made to contact him in order to obtain his permission to wait for an additional payment of 10 euros for every 15 minutes. Sometimes the driver will not be able to wait due to other commitments that may be damaged as a result of the delay. In this case the driver will leave after an hour. The customer will find an alternative solution.",
        price: 110,
        time: "40 minutes",
        difficulty: "Easy",
        img: "https://imgcdn.bokun.tools/9a98fbd3-d2ee-4db3-aca0-99171251b33f.jpeg"
      },
      {
        id: 6,
        title: "VIP Pick-Up from Tel-Aviv Hotels to Ben-Gurion Airport",
        description: "Kind and professional service Service oriented Large, clean and tidy vehicle. Adhering to schedules",
        price: 75,
        time: "30 minutes",
        difficulty: "Easy",
        img: "https://imgcdn.bokun.tools/9a98fbd3-d2ee-4db3-aca0-99171251b33f.jpeg"
      },
      {
        id: 7,
        title: "Sunrise from Mount Masada & the Dead Sea Tour",
        description: "This trip includes some of the most amazing experiences in the world, seeing the sunrise from the world's most beautiful place while incorporating the historic site. And of course, enjoy the experience of the Dead Sea, which is among other things the world's leading health remedy thanks to the minerals found in water and mud",
        price: 790,
        time: "9 hours",
        difficulty: "Challenging",
        img: "https://images.unsplash.com/photo-1593027572644-8dc63773b62a?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=735&q=80"
      },
      {
        id: 8,
        title: "A trip to the Bahi Gardens in Haifa and Caesarea",
        description: "A private tour to one of the most beautiful areas in Israel, the trip combines a stroll in the gardens - well-kept and beautiful gardens. In addition, we will tour the Byzantine city of the Roman period and King Herod, which is on the coast of Israel, together we will visit an amazingly preserved Aqueduct,we can add a tasting tour of the boutique winery. The tour can be tailored to the needs and preferences of travelers.",
        price: 490,
        time: "6 hours",
        difficulty: "Easy",
        img: "https://images.unsplash.com/photo-1603741325318-1eda6bf459ec?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=880&q=80"
      },
    ]
}
