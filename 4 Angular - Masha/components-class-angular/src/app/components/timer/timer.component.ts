import { Component, OnDestroy, OnInit } from '@angular/core';

@Component({
  selector: 'app-timer',
  templateUrl: './timer.component.html',
  styleUrls: ['./timer.component.css']
})
export class TimerComponent implements OnInit, OnDestroy{
  
secondCount: number = 0;
interval: any;

  constructor() {
    console.log("constructor");
  }

  ngOnInit(): void {
    console.log("ngOnInt");
    this.interval = setInterval(() => {
    this.secondCount++;
  }, 1000);
  }
  ngOnDestroy(): void {
    console.log("ngOnDestroy");
    clearInterval(this.interval);
  }
}
