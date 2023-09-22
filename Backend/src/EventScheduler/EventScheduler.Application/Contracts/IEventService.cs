﻿using EventScheduler.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventScheduler.Application.Contracts
{
    public interface IEventService
    {
        Task<Event> AddEvents(Event model);
        Task<Event> UpdateEvent(int eventId, Event model);
        Task<bool> DeleteEvent(int eventId);
        Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false);
        Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false);        
        Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers = false);
    }
}
