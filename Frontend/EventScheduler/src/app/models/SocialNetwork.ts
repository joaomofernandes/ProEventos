import { Speaker } from "./Speaker";

export interface SocialNetwork {
    id : number;
    name : string;
    URL : string;
    eventId? : number;
    event? : Event;
    speakerId? : number;
    speaker? : Speaker;
}
