import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-Cars',
  templateUrl: './Cars.component.html',
  styleUrls: ['./Cars.component.css']
})
export class CarsComponent implements OnInit {

  public cars: any = [];

  showImg: boolean = true;
  _showkeyword: boolean = true;
  filterList: string = '';

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

  showImage(){
    this.showImg = !this.showImg;
  }
  showKeyword(){
    this._showkeyword = !this._showkeyword;
  }

}
