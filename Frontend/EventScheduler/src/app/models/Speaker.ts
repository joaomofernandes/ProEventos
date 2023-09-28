import { SocialNetwork } from "./SocialNetwork";
import { SpeakerEvent } from "./SpeakerEvent";

export interface Speaker {
    Id : number;
    Name : string;
    MiniResume : string;
    ImageURL : string;
    Phone : string;
    Email : string;
    SocialNetworks : SocialNetwork[];
    PalestrantesEventos : SpeakerEvent[];
}
