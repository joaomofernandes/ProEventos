import { Speaker } from "./Speaker";

export interface SpeakerEvent {
    SpeakerId : number;
    Speaker : Speaker;
    EventId : number;
    Event? : Event;
}
