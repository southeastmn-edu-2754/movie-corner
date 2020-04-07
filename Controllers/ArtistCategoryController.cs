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
    public class ArtistCategoryController : ControllerBase
    {
        private readonly MoviesContext _context;

        public ArtistCategoryController(MoviesContext context)
        {
            _context = context;
        }

        // GET: api/ArtistCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistCategory>>> GetArtistCategory()
        {
            return await _context.ArtistCategory.ToListAsync();
        }

        // GET: api/ArtistCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistCategory>> GetArtistCategory(string id)
        {
            var artistCategory = await _context.ArtistCategory.FindAsync(id);

            if (artistCategory == null)
            {
                return NotFound();
            }

            return artistCategory;
        }

        // PUT: api/ArtistCategory/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtistCategory(string id, ArtistCategory artistCategory)
        {
            if (id != artistCategory.Category)
            {
                return BadRequest();
            }

            _context.Entry(artistCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistCategoryExists(id))
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

        // POST: api/ArtistCategory
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ArtistCategory>> PostArtistCategory(ArtistCategory artistCategory)
        {
            _context.ArtistCategory.Add(artistCategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ArtistCategoryExists(artistCategory.Category))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetArtistCategory", new { id = artistCategory.Category }, artistCategory);
        }

        // DELETE: api/ArtistCategory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArtistCategory>> DeleteArtistCategory(string id)
        {
            var artistCategory = await _context.ArtistCategory.FindAsync(id);
            if (artistCategory == null)
            {
                return NotFound();
            }

            _context.ArtistCategory.Remove(artistCategory);
            await _context.SaveChangesAsync();

            return artistCategory;
        }

        private bool ArtistCategoryExists(string id)
        {
            return _context.ArtistCategory.Any(e => e.Category == id);
        }
    }
}
