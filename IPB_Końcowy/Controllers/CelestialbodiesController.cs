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
    public class CelestialbodiesController : ControllerBase
    {
        private readonly spaceyContext _context = new spaceyContext();

        public CelestialbodiesController()
        {
            //_context = context;
        }

        // GET: api/Celestialbodies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Celestialbody>>> GetCelestialbody()
        {
            return await _context.Celestialbody.ToListAsync();
        }

        // GET: api/Celestialbodies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Celestialbody>> GetCelestialbody(int id)
        {
            var celestialbody = await _context.Celestialbody.FindAsync(id);

            if (celestialbody == null)
            {
                return NotFound();
            }

            return celestialbody;
        }

        // PUT: api/Celestialbodies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCelestialbody(int id, Celestialbody celestialbody)
        {
            if (id != celestialbody.Id)
            {
                return BadRequest();
            }

            _context.Entry(celestialbody).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CelestialbodyExists(id))
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

        // POST: api/Celestialbodies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Celestialbody>> PostCelestialbody(Celestialbody celestialbody)
        {
            _context.Celestialbody.Add(celestialbody);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCelestialbody", new { id = celestialbody.Id }, celestialbody);
        }

        // DELETE: api/Celestialbodies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Celestialbody>> DeleteCelestialbody(int id)
        {
            var celestialbody = await _context.Celestialbody.FindAsync(id);
            if (celestialbody == null)
            {
                return NotFound();
            }

            _context.Celestialbody.Remove(celestialbody);
            await _context.SaveChangesAsync();

            return celestialbody;
        }

        private bool CelestialbodyExists(int id)
        {
            return _context.Celestialbody.Any(e => e.Id == id);
        }
    }
}
