import { Lot } from "./Lot";
import { SocialNetwork } from "./SocialNetwork";
import { SpeakerEvent } from "./SpeakerEvent";

export interface Event {
     id : number; 
     place : string; 
     eventDate? : Date; 
     theme : string;  
     peopleQuantity : number; 
     imageURL : string; 
     phone : string; 
     email :string; 
     lots? : Lot[] ; 
     socialNetworks? : SocialNetwork[];
     speakersEvents? : SpeakerEvent[]; 
}
