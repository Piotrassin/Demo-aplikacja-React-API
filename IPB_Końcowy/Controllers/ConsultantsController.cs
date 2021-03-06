﻿using System;
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
    public class ConsultantsController : ControllerBase
    {
        private readonly spaceyContext _context = new spaceyContext();

        public ConsultantsController()
        {
            //_context = context;
        }

        // GET: api/Consultants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consultant>>> GetConsultant()
        {
            /*return Ok(_context.Consultant.Join(_context.Person, c => c.PersonId, p => p.Id,
                        (c, p) => new Consultant { PersonId = c.PersonId, Person = p}).ToList());*/

            return Ok(_context.Consultant.Include(p => p.Person).ToList());
        }

        // GET: api/Consultants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Consultant>> GetConsultant(int id)
        {
            var consultant = await _context.Consultant.FindAsync(id);

            if (consultant == null)
            {
                return NotFound();
            }

            return consultant;
        }

        // PUT: api/Consultants/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsultant(int id, Consultant consultant)
        {
            if (id != consultant.PersonId)
            {
                return BadRequest();
            }

            _context.Entry(consultant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultantExists(id))
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

        // POST: api/Consultants
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Consultant>> PostConsultant(Consultant consultant)
        {
            _context.Consultant.Add(consultant);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ConsultantExists(consultant.PersonId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetConsultant", new { id = consultant.PersonId }, consultant);
        }

        // DELETE: api/Consultants/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Consultant>> DeleteConsultant(int id)
        {
            var consultant = await _context.Consultant.FindAsync(id);
            if (consultant == null)
            {
                return NotFound();
            }

            _context.Consultant.Remove(consultant);
            await _context.SaveChangesAsync();

            return consultant;
        }

        private bool ConsultantExists(int id)
        {
            return _context.Consultant.Any(e => e.PersonId == id);
        }
    }
}
