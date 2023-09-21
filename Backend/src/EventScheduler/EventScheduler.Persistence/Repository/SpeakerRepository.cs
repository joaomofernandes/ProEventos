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
    internal class SpeakerRepository : ISpeakerRepository
    {
        private readonly EventSchedulerContext _context;

        public SpeakerRepository(EventSchedulerContext context)
        {
            _context = context;
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
