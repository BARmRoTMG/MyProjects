import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BookDetailsService {

  constructor() { }

  reviews = 
  [
    {
      id: 1,
      name: "Shanna H",
      date: "February 19, 2023",
      stars: 5,
      title: "A very nice pace to see great historical sites",
      comment: "We really enjoyed having a private tour. Avi was very amenable and had a great wealth of knowledge to share. The pace of the trip is really dependent on your needs and he made sure to be in tune with us."
    },
    {
      id: 2,
      name: "Sherpa601811",
      date: "December 16, 2022",
      stars: 5,
      title: "Amazing people of VANUATU",
      comment: "I can only say that my last trip to VANUATU has regained my faith in human nature and that the country is made of better and kinder people than the rest of the world. I was treated so well and by so many people that I pray I go back soon. From free breakfasts at the COFFEE TREE CAFE to a free night at the BLUE PANGO Pango road. These people know how to treat travelers in need. God bless them."
    },
    {
      id: 3,
      name: "Adam R",
      date: "June 22, 2022",
      stars: 5,
      title: "Amazing people of VANUATU",
      comment: "Avi was great. Very knowledgeable super nice and made the day special my wife and I enjoyed it very much. Review of: Privet day tour (on foot) in Tel Aviv (up to 4 participants)"
    },
    {
      id: 4,
      name: "Iryna Dolyna",
      date: "November 15, 2021",
      stars: 5,
      title: "We can rely on Avi",
      comment: "Avi is a very helpful and amazing guide and transfer manager. Due to the flights delay and other obstacles we had to change the route and reschedule the timing. Avi managed bookings on behalf of us, which was a great help taking into account we had a limited access to the internet."
    },
    {
      id: 5,
      name: "Departure197711",
      date: "August 11, 2020",
      stars: 5,
      title: "Excellent",
      comment: "I wish to come back soon to Israel. When it happens I do want Avi Masciach as my driver and my guide. He is a very gentle, professional, precise person. When I travel abroad I need people I can rely on and Avi is reliable and expert of territory. Than you ,Avi. Thank you, Israel"
    },
    {
      id: 6,
      name: "Dimitris A",
      date: "May 11, 2020",
      stars: 5,
      title: "Excellent Service",
      comment: "Avi was an excellent guide. he really knows about the history of Jerusalem and he is also very entertaining. The tour covered all the basics of all the rellegions and the historry of the old town of the Jerusalem, the restaurant chosen for lunch was a brilliant way to close the tour . I learned a lot and really enjoyed it and would definitely recommend this tour as a must for everyone."
    },
    {
      id: 7,
      name: "Petros A",
      date: "May 10, 2020",
      stars: 5,
      title: "Great tour from Tel Aviv to Jerusalem",
      comment: "Excellent tour by Avi! He was so much fun and attentive to the needs of my family.He has extremely detailed explanations for every aspect of the tour and also is well equipped to address any questions that may arise. He is also funny, friendly, and kind. We visited all the sites of the old town of Jerusalem, all of the sites were extremely interesting and steeped with history. At the end Avi was choose an excelant restaurant before we take the way back to Tel Aviv."
    },
    {
      id: 8,
      name: "Joy P",
      date: "February 19, 2020",
      stars: 5,
      title: "Day sightseeing in Tel Aviv",
      comment: "Excellent day tour Tel Aviv, Avi picked us up when we arrived and drove us to Natanya to meet up with our tour group. He was so knowledgeable and professional we decided to spend a day touring with him in Tel Aviv before our flight back. It was so fun, he went out of his way to find a restaurant that would seat us last minute on Valentines day( not easy) but he found us a great restaurant! Had fun seeing Old Jaffa, local markets and hearing the history of Tel Aviv. He was courteous, realized I was getting too tired to he grabbed I would definitely use him again."
    },
    {
      id: 9,
      name: "Spiegs_in_OR",
      date: "January 21, 2020",
      stars: 5,
      title: "Personalized Day Trips to Dead Sea and Jerusalem",
      comment: "We did two one-day trips with Avi. He did a great job of taking us to the places off the beaten path as well as the places you definitely need to see while in Israel. We fit in a ton of great sites each day and he was great the whole time. Would definitely recommend."
    },
    {
      id: 10,
      name: "Roving288961",
      date: "December 8, 2019",
      stars: 5,
      title: "I recommend Avi",
      comment: "Amazing experience. Clean and big car, a very punctual and professional driver who knows everything about his country. Definitely going to contact Avi within the next trip to Israel."
    },
    {
      id: 11,
      name: "Jake F",
      date: "December 2, 2019",
      stars: 5,
      title: "Israel - through the eyes of a local",
      comment: "Behind every corner, Avi spoils you with a secret hidden gem you would never have found if you were touring by yourself. My favourite was the Druze coffee overlooking Carmel Mountain. My girlfriend and I have toured the holy land 3 times with Avi and each time we are left craving for more. Avi has guided us around Jerusalem, the Dead Sea, Masada, wineries, even a dairy farm and not forgetting the vibey Tel Aviv scene. Avi tailored our tours perfectly to our needs. We loved the coffee and Avi's special hummus sandwiches he provided us with :) Our journeys were filled with laughter and fun. Can't wait for next time Avi!"
    },
    {
      id: 12,
      name: "Daniel L",
      date: "November 29, 2019",
      stars: 5,
      title: "Amazing Trip full of History and Enrichment",
      comment: "We had an amazing trip thanks to Avi. He was very aware of our limited time and managed to curate a trip for us that allowed us to experience more in the day we had then in probably any other trip I have ever taken. Jerusalem is simply one of the most impressive and inspirational places I have I ever traveled to and having a caring expert like Avi to guide you on your way ensures that you can experience all it has to offer. I can highly recommend his services, as we already have done for friends and family who all have similarly had great experiences."
    },
    {
      id: 13,
      name: "Marc",
      date: "November 28, 2019",
      stars: 5,
      title: "Such an excellent driver and a great car!",
      comment: "Avi drove me between Tel Aviv and Jerusalem when I visited Israel this year, He was just amazing: polite, punctual, a true gentleman. The car was fantastic as well. Very grateful to have met him."
    },
    {
      id: 14,
      name: "George C",
      date: "November 27, 2019",
      stars: 5,
      title: "Avi was a great tour guide",
      comment: "Avi has arranged for our group a day trip to the old town of Jerusalem which was one of the best experiences we had in TelAviv.... He has arranged for a pickup from our hotel and drove us to Jerusalem... Along the way we stopped at the mount of olives and then we went to the old town of Jerusalem... we walked through the market and we then visited the old town, the western wall and the Church of the Resurrection....after the day ended avi was very kind to answer any other questions we had regarding TelAviv and shared some tips. Finally we booked Avi for our trip to the airport. For sure if we go back to TelAviv we will contact him to arrange the trip to the dead sea, which we didn’t have the time to do...."
    }
  ]






  tours =
    [
      {
        id: 1,
        title: "Private Day Trip to the Old City in Jerusalem",
        description: "A private day tour of the Old City in Jerusalem, Israel is a popular tourist activity. The tour includes a visit to the Western Wall, the holiest site for Jews, and the Church of the Holy Sepulchre, the holiest site for Christians. The tour also takes visitors through the Muslim and Armenian Quarters. Tourists can see the narrow alleyways, ancient buildings, and beautiful architecture of the Old City. Throughout the tour, the guide provides commentary and answers any questions the tourists may have. The tour starts with a pick-up from the hotel and ends with a drop-off back at the hotel. A private day tour of the Old City is a great way to explore the rich history and culture of Israel. Most of the trip is a walking tour inside the old city.",
        price: 600,
        time: "8 hours",
        difficulty: "Medium",
        img: "../../../assets/images/jerusalem1.jpg"
      },
      {
        id: 2,
        title: "Private Day Trip to the Dead Sea",
        description: "A private day trip to the Dead Sea in Israel. The tour includes a visit to the lowest point on Earth and a chance to float in the mineral-rich waters of the Dead Sea. Tourists can also enjoy the therapeutic mud baths available at the local resort, that also includes all the beach services such as showers, toilets, a resturant and special Dead Sea products. The tour provides a scenic drive through the Judean Desert and offers stunning views of the surrounding mountains and landscapes. The guide provides commentary and answers any questions the tourists may have throughout the tour. The trip starts with a pick-up from the hotel and ends with a drop-off back at the hotel. A private day trip to the Dead Sea is a relaxing way to experience the natural beauty and health benefits of this unique location.",
        price: 550,
        time: "5 hours",
        difficulty: "Easy",
        img: "https://images.unsplash.com/photo-1529066516367-36973222c957?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80"
      },
      {
        id: 3,
        title: "Day Tour in Tel-Aviv - Walking Tour",
        description: "Join us on an exciting journey through time as we explore the ancient history of Tel Aviv and Jaffa. Our private tour will take you back more than 110 years to the sand dunes where Tel Aviv was founded. Discover the stories of the people behind this historic event, and learn how it all relates to Hertzel, the thinker of the idea of the Jewish state. From there, we'll continue our journey through time to Jaffa, a city with a rich history that dates back 3500 years. With the help of our expert guide, you'll explore the ancient streets and alleys of this fascinating city and discover the stories of the people who lived there. This private tour is the perfect way to experience the rich history and culture of Tel Aviv and Jaffa. Book your tour today and get ready to travel back in time! A walking tour (estimated 6KM walk)",
        price: 470,
        time: "5 hours",
        difficulty: "Medium",
        img: "https://imgcdn.bokun.tools/c0b8bc11-a7da-44f7-82ef-5dd7baabee3b.jpeg"
      },
      {
        id: 4,
        title: "VIP Pick-Up from Ben-Gurion Airport to Jerusalem",
        description: "VIP pick-up from Ben-Gurion Airport to Jerusalem. Enjoy a hassle-free and comfortable transfer in a luxury vehicle with a professional driver. Relax and enjoy the scenery as we take care of your transportation needs, the driver will wait for you with a sign at your landing. Book now for a stress-free arrival experience. The price includes 1-hour wait from the time ordered, every additional 15 minutes after the the hour will cost 10€. The service inludes a mineral water bottle for the passengers. (Please include number of luggages)",
        price: 149,
        time: "1 hour",
        difficulty: "Easy",
        img: "https://imgcdn.bokun.tools/9a98fbd3-d2ee-4db3-aca0-99171251b33f.jpeg"
      },
      {
        id: 5,
        title: "VIP Pick-Up from Ben-Gurion Airport to Tel-Aviv",
        description: "VIP pick-up from Ben-Gurion Airport to Tel-Aviv. Enjoy a hassle-free and comfortable transfer in a luxury vehicle with a professional driver. Relax and enjoy the scenery as we take care of your transportation needs, the driver will wait for you with a sign at your landing. Book now for a stress-free arrival experience. The price includes 1-hour wait from the time ordered, every additional 15 minutes after the the hour will cost 10€. The service inludes a mineral water bottle for the passengers. (Please include number of luggages)",
        price: 110,
        time: "40 minutes",
        difficulty: "Easy",
        img: "https://imgcdn.bokun.tools/9a98fbd3-d2ee-4db3-aca0-99171251b33f.jpeg"
      },
      {
        id: 6,
        title: "VIP Pick-Up from Tel-Aviv Hotels to Ben-Gurion Airport",
        description: "Our experienced and careful driver will pick you up at your hotel and ensure you arrive at the airport with plenty of time to spare. We even include a 15-minute wait time at the hotel to ensure you are ready to go when we arrive. If you experience any delays, our driver will wait for an additional fee of 10 euros for every 15 minutes. We understand that traveling can be stressful, so let us take care of your transportation needs. Book now for a worry-free departure experience.",
        price: 75,
        time: "30 minutes",
        difficulty: "Easy",
        img: "https://imgcdn.bokun.tools/9a98fbd3-d2ee-4db3-aca0-99171251b33f.jpeg"
      },
      {
        id: 7,
        title: "Sunrise from Mount Masada & the Dead Sea Tour",
        description: "Experience some of the most amazing and breathtaking moments in the world on this trip. Witness the sunrise from the world's most beautiful place while exploring a historic site. And don't forget to indulge in the world-renowned health benefits of the Dead Sea, known for its mineral-rich water and mud. Join us on this unforgettable journey and create memories that will last a lifetime. Book now for a once-in-a-lifetime experience.",
        price: 790,
        time: "8 hours",
        difficulty: "Hard",
        img: "https://images.unsplash.com/photo-1593027572644-8dc63773b62a?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=735&q=80"
      },
      {
        id: 8,
        title: "A trip to the Bahi Gardens in Haifa and Caesarea",
        description: "We also offer a trip to the Bahai Gardens in Haifa and Caesarea. Explore the stunning Bahai Gardens, a UNESCO World Heritage Site known for its beautifully manicured terraces and intricate landscaping. Afterwards, visit the ancient port city of Caesarea, filled with rich history and breathtaking ruins, including a Roman amphitheater and aqueduct. Let our expert guide take you on a journey through time and culture as you explore these two amazing destinations. Book now for a day filled with adventure and wonder.",
        price: 490,
        time: "6 hours",
        difficulty: "Easy",
        img: "https://images.unsplash.com/photo-1603741325318-1eda6bf459ec?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=880&q=80"
      },
    ]
}
