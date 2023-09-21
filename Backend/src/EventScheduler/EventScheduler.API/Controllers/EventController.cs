using EventScheduler.Domain;
using EventScheduler.Persistence.Context;
using Microsoft.AspNetCore.Mvc;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        
        private readonly EventSchedulerContext _context;
        
        public EventController(EventSchedulerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _context.Events;
            
        }
        [HttpGet("{id}")]
        public IEnumerable<Event> Get(int id)
        {
            return _context.Events.Where(x => x.Id == id);
        }
        [HttpPost]
        public IActionResult Add(Event Event)
        {
            _context.Events.Add(Event);
            _context.SaveChanges();
            return Ok();
        }


    }
}