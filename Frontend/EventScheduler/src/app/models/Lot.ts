export interface Lot {
    Id : number;
    Name : string; 
    Price : number;
    BeginningDate? : Date; 
    EndDate? : Date; 
    Quantity : number;
    EventId : number 
    Event? : Event;
}
