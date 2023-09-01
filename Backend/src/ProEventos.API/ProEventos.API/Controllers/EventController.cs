using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        
        private readonly DataContext _context;
        
        public EventController(DataContext context)
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
            return _context.Events.Where(x => x.EventId == id);
        }


    }
}