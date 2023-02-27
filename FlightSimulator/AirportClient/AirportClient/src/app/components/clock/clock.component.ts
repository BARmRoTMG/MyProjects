import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'clock',
  templateUrl: './clock.component.html',
  styleUrls: ['./clock.component.css']
})
export class ClockComponent implements OnInit {
  time = new Date();
  intervalId: any;

  ngOnInit(): void {
        this.intervalId = setInterval(() => {
          this.time = new Date();
        }, 1000);
  }  
}
