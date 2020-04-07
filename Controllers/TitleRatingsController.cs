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
    public class TitleRatingsController : ControllerBase
    {
        private readonly MoviesContext _context;

        public TitleRatingsController(MoviesContext context)
        {
            _context = context;
        }

        // GET: api/TitleRatings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TitleRatings>>> GetTitleRatings()
        {
            return await _context.TitleRatings.ToListAsync();
        }

        // GET: api/TitleRatings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TitleRatings>> GetTitleRatings(string id)
        {
            var titleRatings = await _context.TitleRatings.FindAsync(id);

            if (titleRatings == null)
            {
                return NotFound();
            }

            return titleRatings;
        }

        // PUT: api/TitleRatings/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTitleRatings(string id, TitleRatings titleRatings)
        {
            if (id != titleRatings.Tconst)
            {
                return BadRequest();
            }

            _context.Entry(titleRatings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TitleRatingsExists(id))
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

        // POST: api/TitleRatings
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TitleRatings>> PostTitleRatings(TitleRatings titleRatings)
        {
            _context.TitleRatings.Add(titleRatings);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TitleRatingsExists(titleRatings.Tconst))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTitleRatings", new { id = titleRatings.Tconst }, titleRatings);
        }

        // DELETE: api/TitleRatings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TitleRatings>> DeleteTitleRatings(string id)
        {
            var titleRatings = await _context.TitleRatings.FindAsync(id);
            if (titleRatings == null)
            {
                return NotFound();
            }

            _context.TitleRatings.Remove(titleRatings);
            await _context.SaveChangesAsync();

            return titleRatings;
        }

        private bool TitleRatingsExists(string id)
        {
            return _context.TitleRatings.Any(e => e.Tconst == id);
        }
    }
}
