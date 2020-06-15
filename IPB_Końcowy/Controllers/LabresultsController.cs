using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IPB_Końcowy.Models;

namespace IPB_Końcowy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabresultsController : ControllerBase
    {
        private readonly spaceyContext _context = new spaceyContext();

        public LabresultsController()
        {
            //_context = context;
        }

        // GET: api/Labresults
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Labresults>>> GetLabresults()
        {
            return await _context.Labresults.ToListAsync();
        }

        // GET: api/Labresults/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Labresults>> GetLabresults(int id)
        {
            var labresults = await _context.Labresults.FindAsync(id);

            if (labresults == null)
            {
                return NotFound();
            }

            return labresults;
        }

        // PUT: api/Labresults/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLabresults(int id, Labresults labresults)
        {
            if (id != labresults.Id)
            {
                return BadRequest();
            }

            _context.Entry(labresults).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LabresultsExists(id))
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

        // POST: api/Labresults
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Labresults>> PostLabresults(Labresults labresults)
        {
            _context.Labresults.Add(labresults);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLabresults", new { id = labresults.Id }, labresults);
        }

        // DELETE: api/Labresults/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Labresults>> DeleteLabresults(int id)
        {
            var labresults = await _context.Labresults.FindAsync(id);
            if (labresults == null)
            {
                return NotFound();
            }

            _context.Labresults.Remove(labresults);
            await _context.SaveChangesAsync();

            return labresults;
        }

        private bool LabresultsExists(int id)
        {
            return _context.Labresults.Any(e => e.Id == id);
        }
    }
}
