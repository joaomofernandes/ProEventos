﻿using System;
using System.Collections.Generic;
using EventScheduler.Domain;

namespace EventScheduler.Domain
{
    public class Event
    {
        public int Id { get; set; }
        public string Place { get; set; }
        public DateTime? EventDate { get; set; }
        public string Theme { get; set; }
        public int PeopleQuantity { get; set; }
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Lot>? Lots { get; set; }
        public IEnumerable<SocialNetwork>? SocialNetworks { get; set; }
        public IEnumerable<SpeakerEvent>? SpeakersEvents { get; set; }
    }
}
