using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusProject.Models;

namespace BusProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly BusReservationProjectContext _context;

        public BusController(BusReservationProjectContext context)
        {
            _context = context;
        }

        // GET: api/Bus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bu>>> Getbuses()
        {
            return await _context.buses.ToListAsync();
        }

        // GET: api/Bus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bu>> GetBu(int id)
        {
            var bu = await _context.buses.FindAsync(id);

            if (bu == null)
            {
                return NotFound();
            }

            return bu;
        }

        // PUT: api/Bus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBu(int id, Bu bu)
        {
            if (id != bu.BusId)
            {
                return BadRequest();
            }

            _context.Entry(bu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Bus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bu>> PostBu(Bu bu)
        {
            _context.buses.Add(bu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBu", new { id = bu.BusId }, bu);
        }

        // DELETE: api/Bus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBu(int id)
        {
            var bu = await _context.buses.FindAsync(id);
            if (bu == null)
            {
                return NotFound();
            }

            _context.buses.Remove(bu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuExists(int id)
        {
            return _context.buses.Any(e => e.BusId == id);
        }
    }
}
