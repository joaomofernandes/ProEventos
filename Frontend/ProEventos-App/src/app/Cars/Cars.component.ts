import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-Cars',
  templateUrl: './Cars.component.html',
  styleUrls: ['./Cars.component.css']
})
export class CarsComponent implements OnInit {

  public cars: any;

  constructor(private http: HttpClient) { }

  ngOnInit() : void{
    this.getCars()
  }

  public getCars() : void {
    this.http.get('https://localhost:7258/api/Car').subscribe(
      response => this.cars = response,
      error => console.log(error)
    );
  }

}
