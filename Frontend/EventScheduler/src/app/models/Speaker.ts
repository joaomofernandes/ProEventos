import { SocialNetwork } from "./SocialNetwork";
import { SpeakerEvent } from "./SpeakerEvent";

export interface Speaker {
    id : number;
    name : string;
    miniResume : string;
    imageURL : string;
    phone : string;
    email : string;
    socialNetworks : SocialNetwork[];
    palestrantesEventos : SpeakerEvent[];
}
