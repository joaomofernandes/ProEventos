import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-Events',
  templateUrl: './Events.component.html',
  styleUrls: ['./Events.component.scss']
})
export class EventsComponent implements OnInit {

  public events: any;
  

  constructor(private http: HttpClient) { }

  ngOnInit() : void{
    this.getEventos()
  }

  public getEventos() : void {
    this.http.get('https://localhost:7258/api/Event').subscribe(
      response => this.events = response,
      error => console.log(error)
    );
  }

}
