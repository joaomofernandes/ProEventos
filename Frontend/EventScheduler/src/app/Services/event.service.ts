import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class EventService {
  baseUrl = 'https://localhost:7258/api/Event';
  getByThemeUrl = 'https://localhost:7258/getByTheme';

constructor(private http: HttpClient) { }

getEvents() : Observable<Event[]> {
  return this.http.get<Event[]>(this.baseUrl);
}

getEventsByTheme(theme : string) : Observable<Event[]> {
  return this.http.get<Event[]>(`${this.getByThemeUrl}/${theme}`);
}

getEventsById(id : number) : Observable<Event>{
  return this.http.get<Event>(`${this.baseUrl}/${id}`);
}

}
