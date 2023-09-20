import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-Events',
  templateUrl: './Events.component.html',
  styleUrls: ['./Events.component.css']
})
export class EventsComponent implements OnInit {

  public events: any = [];

  showImg: boolean = true;
  _showkeyword: boolean = true;
  private _filterList: string = '';
  public filteredEvents: any = [];

  public get filterList() : string{
    return this._filterList;
  }

  public set filterList(value: string){
    this._filterList = value;
    this.filteredEvents = this.filterList ? this.filterCars(this.filterList) : this.events;
  }

  constructor(private http: HttpClient) { }

  ngOnInit() : void{
    this.getCars()
  }
  public getCars() : void {
    this.http.get('https://localhost:7258/api/Car').subscribe(
      response => {
        this.events = response;
        this.filteredEvents = this.events;
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
    return this.events.filter (        
        (event: { manufacturer: string; model: string})  => event.manufacturer.toLowerCase().indexOf(filterBy) !== -1 ||
        event.model.toLowerCase().indexOf(filterBy) !== -1
    )   
  }

}
