using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        
        private readonly DataContext _context;
        
        public CarController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return _context.Cars;
            
        }
        [HttpGet("{id}")]
        public IEnumerable<Car> Get(int id)
        {
            return _context.Cars.Where(x => x.CarId == id);
        }
        [HttpPost]
        public IActionResult Add(Car car)
        {
            _context.Add(car);
            _context.SaveChanges();
            return Ok();

        }


    }
}