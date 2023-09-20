using EventScheduler.Domain;
using EventScheduler.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        
        private readonly EventSchedulerContext _context;
        
        public CarController(EventSchedulerContext context)
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