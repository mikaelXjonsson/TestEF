using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestEF.Data;
using TestEF.Models;

namespace TestEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ShipsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Ships
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ship>>> GetShips()
        {
            return await _context.Ships.ToListAsync();

        }

        // GET: api/Ships/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ship>> GetShip(int id)
        {
            var ship = await _context.Ships.FindAsync(id);
            if (ship == null) 
            {
                return NotFound();
            }
            return Ok(ship);
        }

        // POST: api/Ships
        [HttpPost]
        public async Task<ActionResult<Ship>> PostShip(Ship ship)
        {
            _context.Ships.Add(ship);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetShip), new { id = ship.Id }, ship);
        }

    }
}
