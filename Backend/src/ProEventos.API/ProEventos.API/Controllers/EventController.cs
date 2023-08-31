using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        public IEnumerable<Event> _events = new Event[] { 
                new Event()
        {
            EventId = 1,
                    Theme = "Angular 11 e .NET 6",
                    Place = "Bobadela",
                    Lot = "1st Lot",
                    PeopleCount = 10,
                    Date = DateTime.Now.AddDays(5).ToString()
                },
                new Event()
        {
            EventId = 1,
                    Theme = "Angular 11 e .NET 6",
                    Place = "Bobadela",
                    Lot = "1st Lot",
                    PeopleCount = 10,
                    Date = DateTime.Now.AddDays(5).ToString()
                }

    };

    public EventController()
        {
            
        }

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _events;
            
        }
        [HttpGet("{id}")]
        public IEnumerable<Event> Get(int id)
        {
            return _events.Where(x => x.EventId == id);
        }


    }
}