using EventScheduler.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventScheduler.Persistence.Interfaces
{
    public interface ISpeakerRepository
    {
        Task<Speaker[]> GetAllSpeakersByNameAsync(string name, bool includeEvents);
        Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents);
        Task<Speaker> GetSpeakerByIdAsync(int speakerId, bool includeEvents);
    }
}
