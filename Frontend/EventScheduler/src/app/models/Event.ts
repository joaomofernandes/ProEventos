import { Lot } from "./Lot";
import { SocialNetwork } from "./SocialNetwork";
import { SpeakerEvent } from "./SpeakerEvent";

export interface Event {
     Id : number; 
     Place : string; 
     EventDate? : Date; 
     Theme : string;  
     PeopleQuantity : number; 
     ImageURL : string; 
     Phone : string; 
     Email :string; 
     Lots? : Lot[] ; 
     SocialNetworks? : SocialNetwork[];
     SpeakersEvents? : SpeakerEvent[]; 
}
