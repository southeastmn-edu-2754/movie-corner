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
    public class TitleEpisodeController : ControllerBase
    {
        private readonly MoviesContext _context;

        public TitleEpisodeController(MoviesContext context)
        {
            _context = context;
        }

        // GET: api/TitleEpisode
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TitleEpisode>>> GetTitleEpisode()
        {
            return await _context.TitleEpisode.ToListAsync();
        }

        // GET: api/TitleEpisode/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TitleEpisode>> GetTitleEpisode(string id)
        {
            var titleEpisode = await _context.TitleEpisode.FindAsync(id);

            if (titleEpisode == null)
            {
                return NotFound();
            }

            return titleEpisode;
        }

        // PUT: api/TitleEpisode/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTitleEpisode(string id, TitleEpisode titleEpisode)
        {
            if (id != titleEpisode.Tconst)
            {
                return BadRequest();
            }

            _context.Entry(titleEpisode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TitleEpisodeExists(id))
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

        // POST: api/TitleEpisode
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TitleEpisode>> PostTitleEpisode(TitleEpisode titleEpisode)
        {
            _context.TitleEpisode.Add(titleEpisode);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TitleEpisodeExists(titleEpisode.Tconst))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTitleEpisode", new { id = titleEpisode.Tconst }, titleEpisode);
        }

        // DELETE: api/TitleEpisode/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TitleEpisode>> DeleteTitleEpisode(string id)
        {
            var titleEpisode = await _context.TitleEpisode.FindAsync(id);
            if (titleEpisode == null)
            {
                return NotFound();
            }

            _context.TitleEpisode.Remove(titleEpisode);
            await _context.SaveChangesAsync();

            return titleEpisode;
        }

        private bool TitleEpisodeExists(string id)
        {
            return _context.TitleEpisode.Any(e => e.Tconst == id);
        }
    }
}
