using EventScheduler.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventScheduler.Persistence.Context
{
    public class EventSchedulerContext : DbContext
    {
        public EventSchedulerContext(DbContextOptions options) : base(options) { }
        public DbSet<Event> Events { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<SpeakerEvent> SpeakersEvents { get; set; }
        public DbSet<SocialNetwork> SocialNetworks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpeakerEvent>()
                .HasKey(e => new { e.EventId, e.SpeakerId });
        }
    }
}