using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCorner.Data;
using MovieCorner.Models;

namespace _2754_movie_corner_2020.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NameBasicsController : ControllerBase
    {
        private readonly MoviesContext _context;

        public NameBasicsController(MoviesContext context)
        {
            _context = context;
        }

        // GET: api/NameBasics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NameBasics>>> GetNameBasics()
        {
            return await _context.NameBasics.ToListAsync();
        }

        // GET: api/TitlePrincipals/primaryName
        [HttpGet("{primaryName}")]
        public async Task<IActionResult> GetNameBasics([FromRoute] string primaryName)
        {
            List<NameBasics> nameBasics = new List<NameBasics>();
            if (String.IsNullOrEmpty(primaryName))
                nameBasics = await _context.NameBasics.ToListAsync();
            else
                nameBasics = await _context.NameBasics
                    .Where(p => p.PrimaryName.Contains(primaryName))
                    .OrderBy(p => p.PrimaryName)
                    .Take(5)
                    .ToListAsync();

            return Ok(new {nameBasics = nameBasics});
        }


        // // GET: api/NameBasics/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<NameBasics>> GetNameBasics(string id)
        // {
        //     var nameBasics = await _context.NameBasics.FindAsync(id);

        //     if (nameBasics == null)
        //     {
        //         return NotFound();
        //     }

        //     return nameBasics;
        // }

        // PUT: api/NameBasics/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNameBasics(string id, NameBasics nameBasics)
        {
            if (id != nameBasics.Nconst)
            {
                return BadRequest();
            }

            _context.Entry(nameBasics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NameBasicsExists(id))
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

        // POST: api/NameBasics
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<NameBasics>> PostNameBasics(NameBasics nameBasics)
        {
            _context.NameBasics.Add(nameBasics);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NameBasicsExists(nameBasics.Nconst))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNameBasics", new { id = nameBasics.Nconst }, nameBasics);
        }

        // DELETE: api/NameBasics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NameBasics>> DeleteNameBasics(string id)
        {
            var nameBasics = await _context.NameBasics.FindAsync(id);
            if (nameBasics == null)
            {
                return NotFound();
            }

            _context.NameBasics.Remove(nameBasics);
            await _context.SaveChangesAsync();

            return nameBasics;
        }

        private bool NameBasicsExists(string id)
        {
            return _context.NameBasics.Any(e => e.Nconst == id);
        }
    }
}
