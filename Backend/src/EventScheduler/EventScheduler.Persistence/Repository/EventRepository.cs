using EventScheduler.Domain;
using EventScheduler.Persistence.Context;
using EventScheduler.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventScheduler.Persistence.Repository
{
    internal class EventRepository : IEventRepository
    {
        private readonly EventSchedulerContext _context;

        public EventRepository(EventSchedulerContext context)
        {
            _context = context;
        }

        public async Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Lotes)
                .Include(e => e.SocialNetworks);

            if (includeSpeakers)
            {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Speaker);
            }
            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Lotes)
                .Include(e => e.SocialNetworks);

            if (includeSpeakers)
            {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Speaker);
            }
            query = query.OrderBy(e => e.Id)
                .Where(e => e.Theme.ToLower()
                .Contains(theme.ToLower()));

            return await query.ToArrayAsync();
        }  

        public async Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Lotes)
                .Include(e => e.SocialNetworks);

            if (includeSpeakers)
            {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Speaker);
            }
            query = query.OrderBy(e => e.Id)
                .Where(e => e.Id == eventId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
