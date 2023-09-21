using EventScheduler.Application.Contracts;
using EventScheduler.Domain;
using EventScheduler.Persistence.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventScheduler.Application
{
    internal class EventService : IEventService
    {
        private readonly IEventSchedulerRepository _eventSchedulerRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ISpeakerRepository _speakerRepository;

        public EventService(IEventSchedulerRepository eventSchedulerRepository, IEventRepository eventRepository)
        {
            _eventSchedulerRepository = eventSchedulerRepository;
            _eventRepository = eventRepository;
        }
        public async Task<Event> AddEvents(Event model)
        {
            try
            {
                _eventSchedulerRepository.Add<Event>(model);
                if(await _eventSchedulerRepository.SaveChangesAsync())
                {
                    return await _eventRepository.GetEventByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event> UpdateEvent(int eventId, Event model)
        {
            try
            {
                var eve = await _eventRepository.GetEventByIdAsync(eventId, false);
                if (eve == null)
                    return null;

                model.Id = eve.Id;

                _eventSchedulerRepository.Update(model);
                if (await _eventSchedulerRepository.SaveChangesAsync())
                {
                    return await _eventRepository.GetEventByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvent(int eventId)
        {
            try
            {
                var eve = await _eventRepository.GetEventByIdAsync(eventId, false);
                if (eve == null)
                    throw new Exception("No event was found!");

                _eventSchedulerRepository.Delete<Event>(eve);
                await _eventSchedulerRepository.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            try
            {
                var events = await _eventRepository.GetAllEventsAsync(includeSpeakers);
                
                if (events == null)
                    return null; 
                
                return events;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false)
        {
            try
            {
                var events = await _eventRepository.GetAllEventsByThemeAsync(theme, includeSpeakers);

                if (events == null)
                    return null;

                return events;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers = false)
        {
            try
            {
                var events = await _eventRepository.GetEventByIdAsync(eventId, includeSpeakers);

                if (events == null)
                    return null;

                return events;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
    }
}
