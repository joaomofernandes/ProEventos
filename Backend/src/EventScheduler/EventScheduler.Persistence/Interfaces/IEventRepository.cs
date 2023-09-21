using EventScheduler.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventScheduler.Persistence.Interfaces
{
    public interface IEventRepository
    {
        Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false);
        Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false);
        Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers = false);
    }
}
