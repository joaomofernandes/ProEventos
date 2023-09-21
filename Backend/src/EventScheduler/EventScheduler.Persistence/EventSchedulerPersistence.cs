using EventScheduler.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventScheduler.Persistence
{
    internal class EventSchedulerPersistence : IEventSchedulerPersistence
    {
        private readonly EventSchedulerContext _context;

        public EventSchedulerPersistence(EventSchedulerContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
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

        public async Task<Speaker[]> GetAllSpeakersByNameAsync(string name, bool includeEvents)
        {
            IQueryable<Speaker> query = _context.Speakers
                .Include(s => s.SocialNetworks);

            if (includeEvents)
            {
                query = query
                    .Include(s => s.PalestrantesEventos)
                    .ThenInclude(pe => pe.Event);
            }
            query = query.OrderBy(s => s.Id)
                .Where(s => s.Name.ToLower()
                .Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
                .Include(s => s.SocialNetworks);

            if (includeEvents)
            {
                query = query
                    .Include(s => s.PalestrantesEventos)
                    .ThenInclude(pe => pe.Event);
            }
            query = query.OrderBy(s => s.Id);

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

        public async Task<Speaker> GetSpeakerByIdAsync(int speakerId, bool includeEvents)
        {
            IQueryable<Speaker> query = _context.Speakers
               .Include(s => s.SocialNetworks);

            if (includeEvents)
            {
                query = query
                    .Include(s => s.PalestrantesEventos)
                    .ThenInclude(pe => pe.Event);
            }
            query = query.OrderBy(e => e.Id)
                .Where(s => s.Id == speakerId);

            return await query.FirstOrDefaultAsync();
        }  
    }
}
