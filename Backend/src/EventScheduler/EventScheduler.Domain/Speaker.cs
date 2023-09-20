﻿using System.Collections.Generic;
namespace EventScheduler.Domain
{
    public class Speaker
    {
        public int Id { get; set; }
        public string MiniResume { get; set; }
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email{ get; set; }
        public IEnumerable<SocialNetwork> RedesSociais { get; set; }
        public IEnumerable<SpeakerEvent> PalestrantesEventos { get; set; }
    }
}