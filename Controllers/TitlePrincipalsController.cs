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
    public class TitlePrincipalsController : ControllerBase
    {
        private readonly MoviesContext _context;

        public TitlePrincipalsController(MoviesContext context)
        {
            _context = context;
        }

        // GET: api/TitlePrincipals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TitlePrincipals>>> GetTitlePrincipals()
        {
            return await _context.TitlePrincipals.ToListAsync();
        }

        // GET: api/TitlePrincipals/tconst
        [HttpGet("{tconst}")]
        public async Task<IActionResult> GetTitlePrincipals([FromRoute] string tconst)
        {
            List<TitlePrincipals> titlePrincipals = new List<TitlePrincipals>();
            if (String.IsNullOrEmpty(tconst))
                titlePrincipals = await _context.TitlePrincipals.ToListAsync();
            else
                // titlePrincipals = await _context.TitlePrincipals.Where(c => c.Nconst == nconst).ToListAsync();
                titlePrincipals = await _context.TitlePrincipals
                    .Where(t => t.Tconst.Contains(tconst))
                    .OrderBy(t => t.Tconst)
                    .Take(5)
                    .ToListAsync();

            return Ok(new {titlePrincipals = titlePrincipals});
        }

        // GET: api/TitlePrincipals/5

        // [HttpGet("{id}")]
        // public async Task<ActionResult<TitlePrincipals>> GetTitlePrincipals(string id, string id2)
        // {
        //     var titlePrincipals = await _context.TitlePrincipals.FindAsync(id, id2);

        //     if (titlePrincipals == null)
        //     {
        //         return NotFound();
        //     }

        //     return titlePrincipals;
        // }

        // PUT: api/TitlePrincipals/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTitlePrincipals(string id, TitlePrincipals titlePrincipals)
        {
            if (id != titlePrincipals.Tconst)
            {
                return BadRequest();
            }

            _context.Entry(titlePrincipals).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TitlePrincipalsExists(id))
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

        // POST: api/TitlePrincipals
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TitlePrincipals>> PostTitlePrincipals(TitlePrincipals titlePrincipals)
        {
            _context.TitlePrincipals.Add(titlePrincipals);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TitlePrincipalsExists(titlePrincipals.Tconst))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTitlePrincipals", new { id = titlePrincipals.Tconst }, titlePrincipals);
        }

        // DELETE: api/TitlePrincipals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TitlePrincipals>> DeleteTitlePrincipals(string id)
        {
            var titlePrincipals = await _context.TitlePrincipals.FindAsync(id);
            if (titlePrincipals == null)
            {
                return NotFound();
            }

            _context.TitlePrincipals.Remove(titlePrincipals);
            await _context.SaveChangesAsync();

            return titlePrincipals;
        }

        private bool TitlePrincipalsExists(string id)
        {
            return _context.TitlePrincipals.Any(e => e.Tconst == id);
        }
    }
}
