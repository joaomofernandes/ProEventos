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
  private _filterList: string = '';
  public filteredCars: any = [];

  public get filterList() : string{
    return this._filterList;
  }

  public set filterList(value: string){
    this._filterList = value;
    this.filteredCars = this.filterList ? this.filterCars(this.filterList) : this.cars;
  }

  constructor(private http: HttpClient) { }

  ngOnInit() : void{
    this.getCars()
  }

  public getCars() : void {
    this.http.get('https://localhost:7258/api/Car').subscribe(
      response => {
        this.cars = response;
        this.filteredCars = this.cars;
      },
      error => console.log(error)
    );
  }

  showImage(){
    this.showImg = !this.showImg;
  }
  showKeyword(){
    this._showkeyword = !this._showkeyword;
  }

  filterCars(filterBy: string): any{
    filterBy = filterBy.toLowerCase();
    return this.cars.filter (        
        (car: { manufacturer: string; model: string})  => car.manufacturer.toLowerCase().indexOf(filterBy) !== -1 ||
        car.model.toLowerCase().indexOf(filterBy) !== -1
    )   
  }

}
