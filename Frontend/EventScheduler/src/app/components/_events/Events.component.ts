import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventService } from '../../Services/event.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-Events',
  templateUrl: './Events.component.html',
  styleUrls: ['./Events.component.css']
})
export class EventsComponent implements OnInit {
  modalRef?: BsModalRef;
  public events: any = [];
  public filteredEvents: any = [];

  showImg: boolean = true;
  _showkeyword: boolean = true;
  private _filterList: string = '';
  

  public get filterList() : string{
    return this._filterList;
  }

  public set filterList(value: string){
    this._filterList = value;
    this.filteredEvents = this.filterList ? this.filterEvents(this.filterList) : this.events;
  }

  constructor(private eventService : EventService, 
              private modalService: BsModalService,
              private toastr : ToastrService,
              private spinner: NgxSpinnerService) {}

  ngOnInit() : void{
    this.getEvents();
    this.spinner.show();
  }
  public getEvents() : void {
    this.eventService.getEvents().subscribe({
      next: (events: Event[]) =>{
        this.events = events;
        this.filteredEvents = this.events;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Error while loading events!', 'Error!');
      },
      complete: () => this.spinner.hide()
    })
  }

  showImage(){
    this.showImg = !this.showImg;
  }
  showKeyword(){
    this._showkeyword = !this._showkeyword;
  }

  filterEvents(filterBy: string): Event[]{
    filterBy = filterBy.toLowerCase();
    return this.events.filter (        
        (event: { theme: string; place: string})  => event.theme.toLowerCase().indexOf(filterBy) !== -1 ||
        event.place.toLowerCase().indexOf(filterBy) !== -1
    )   
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }
 
  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('The event was succesfully deleted.', 'Deleted!');
  }
 
  decline(): void {
    this.modalRef?.hide();
  }

}
