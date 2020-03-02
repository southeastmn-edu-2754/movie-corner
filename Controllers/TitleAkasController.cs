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
    public class TitleAkasController : ControllerBase
    {
        private readonly MoviesContext _context;

        public TitleAkasController(MoviesContext context)
        {
            _context = context;
        }

        // GET: api/TitleAkas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TitleAkas>>> GetTitleAkas()
        {
            return await _context.TitleAkas.ToListAsync();
        }

        // GET: api/TitleAkas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TitleAkas>> GetTitleAkas(string id)
        {
            var titleAkas = await _context.TitleAkas.FindAsync(id);

            if (titleAkas == null)
            {
                return NotFound();
            }

            return titleAkas;
        }

        // PUT: api/TitleAkas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTitleAkas(string id, TitleAkas titleAkas)
        {
            if (id != titleAkas.TitleId)
            {
                return BadRequest();
            }

            _context.Entry(titleAkas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TitleAkasExists(id))
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

        // POST: api/TitleAkas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TitleAkas>> PostTitleAkas(TitleAkas titleAkas)
        {
            _context.TitleAkas.Add(titleAkas);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TitleAkasExists(titleAkas.TitleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTitleAkas", new { id = titleAkas.TitleId }, titleAkas);
        }

        // DELETE: api/TitleAkas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TitleAkas>> DeleteTitleAkas(string id)
        {
            var titleAkas = await _context.TitleAkas.FindAsync(id);
            if (titleAkas == null)
            {
                return NotFound();
            }

            _context.TitleAkas.Remove(titleAkas);
            await _context.SaveChangesAsync();

            return titleAkas;
        }

        private bool TitleAkasExists(string id)
        {
            return _context.TitleAkas.Any(e => e.TitleId == id);
        }
    }
}
