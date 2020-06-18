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
    public class PersonalizedoffersController : ControllerBase
    {
        private readonly spaceyContext _context = new spaceyContext();

        public PersonalizedoffersController()
        {
            //_context = context;
        }

        // GET: api/Personalizedoffers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personalizedoffer>>> GetPersonalizedoffer()
        {
            return await _context.Personalizedoffer.Include(p => p.UserPerson).ToListAsync();
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<Personalizedoffer>>> GetPersonalizedofferForUser(int id)
        {
            return await _context.Personalizedoffer.Where(p => p.UserPersonId == id).Include(p => p.UserPerson).ToListAsync();
        }

        // GET: api/Personalizedoffers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Personalizedoffer>> GetPersonalizedoffer(int id)
        {
            var personalizedoffer = await _context.Personalizedoffer.FindAsync(id);

            if (personalizedoffer == null)
            {
                return NotFound();
            }

            return personalizedoffer;
        }

        // PUT: api/Personalizedoffers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalizedoffer(int id, Personalizedoffer personalizedoffer)
        {
            if (id != personalizedoffer.Id)
            {
                return BadRequest();
            }

            _context.Entry(personalizedoffer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalizedofferExists(id))
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

        // POST: api/Personalizedoffers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Personalizedoffer>> PostPersonalizedoffer(Personalizedoffer personalizedoffer)
        {
            _context.Personalizedoffer.Add(personalizedoffer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonalizedoffer", new { id = personalizedoffer.Id }, personalizedoffer);
        }

        // DELETE: api/Personalizedoffers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Personalizedoffer>> DeletePersonalizedoffer(int id)
        {
            var personalizedoffer = await _context.Personalizedoffer.FindAsync(id);
            if (personalizedoffer == null)
            {
                return NotFound();
            }

            _context.Personalizedoffer.Remove(personalizedoffer);
            await _context.SaveChangesAsync();

            return personalizedoffer;
        }

        private bool PersonalizedofferExists(int id)
        {
            return _context.Personalizedoffer.Any(e => e.Id == id);
        }
    }
}
