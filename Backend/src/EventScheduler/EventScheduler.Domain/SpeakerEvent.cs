using EventScheduler.Domain;

namespace EventScheduler.Domain
{
    public class SpeakerEvent
    {
        public int SpeakerId { get; set; }
        public Speaker Speaker { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
