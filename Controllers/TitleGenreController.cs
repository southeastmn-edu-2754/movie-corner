using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCorner.Data;
using MovieCorner.Models;

namespace MovieCorner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleGenreController : ControllerBase
    {
        private readonly MoviesContext _context;

        public TitleGenreController(MoviesContext context)
        {
            _context = context;
        }

        // GET: api/TitleGenre
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TitleGenre>>> GetTitleGenre()
        {
            return await _context.TitleGenre.ToListAsync();
        }

        // GET: api/TitleGenre/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TitleGenre>> GetTitleGenre(string id)
        {
            var titleGenre = await _context.TitleGenre.FindAsync(id);

            if (titleGenre == null)
            {
                return NotFound();
            }

            return titleGenre;
        }

        // PUT: api/TitleGenre/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTitleGenre(string id, TitleGenre titleGenre)
        {
            if (id != titleGenre.Genre)
            {
                return BadRequest();
            }

            _context.Entry(titleGenre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TitleGenreExists(id))
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

        // POST: api/TitleGenre
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TitleGenre>> PostTitleGenre(TitleGenre titleGenre)
        {
            _context.TitleGenre.Add(titleGenre);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TitleGenreExists(titleGenre.Genre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTitleGenre", new { id = titleGenre.Genre }, titleGenre);
        }

        // DELETE: api/TitleGenre/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TitleGenre>> DeleteTitleGenre(string id)
        {
            var titleGenre = await _context.TitleGenre.FindAsync(id);
            if (titleGenre == null)
            {
                return NotFound();
            }

            _context.TitleGenre.Remove(titleGenre);
            await _context.SaveChangesAsync();

            return titleGenre;
        }

        private bool TitleGenreExists(string id)
        {
            return _context.TitleGenre.Any(e => e.Genre == id);
        }
    }
}
