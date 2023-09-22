using EventScheduler.Domain;
using EventScheduler.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _eventService.GetAllEventsAsync();
                if (response == null)
                    return NotFound("No events were found!");

                return Ok(response);
            }
            catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while retrieving events. Erro: {ex.Message}");
            }
            
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(int id)
        {
            try
            {
                var response = await _eventService.GetEventByIdAsync(id, true);
                if (response == null)
                    return NotFound("No event with the given ID was found!");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while retrieving events. Erro: {ex.Message}");
            }
        }

        [HttpGet("{theme}")]
        public async Task<IActionResult> GetEventsbyTheme(string theme)
        {
            try
            {
                var response = await _eventService.GetAllEventsByThemeAsync(theme, true);
                if (response == null)
                    return NotFound("No events were found!");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while retrieving events. Erro: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddEvent(Event Event)
        {
            try
            {
                var response = await _eventService.AddEvents(Event);
                if (response == null)
                    return BadRequest("Error while inserting event!");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while inserting events. Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(Event Event, int id)
        {
            try
            {
                var response = await _eventService.UpdateEvent(id, Event);
                if (response == null)
                    return BadRequest("Error while updating event!");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while updating the event with id {id}. Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            try
            {
                var response = await _eventService.DeleteEvent(id);
                if (response == null)
                    return BadRequest("Error while deleting event!");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while deleting the event with id {id}. Error: {ex.Message}");
            }
        }


    }
}