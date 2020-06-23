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
    public class TitleBasicsController : ControllerBase
    {
        private readonly MoviesContext _context;

        public TitleBasicsController(MoviesContext context)
        {
            _context = context;
        }

        // GET: api/TitleBasics/{value}
        [HttpGet("{value}")]
        public async Task<IActionResult> GetTitleBasics([FromRoute] string value)
        {
            // Returns an array of TitleBasics objects:
            // 1) If "value" is primary key (tt0000000), search Tconst
            // 2) Else search primary title
            List<TitleBasics> titleBasics = new List<TitleBasics>();

            int i = 0;
            if (value.Length == 9 && value.Substring(0,2) == "tt" && Int32.TryParse(value.Substring(2, 7), out i)) {
                titleBasics = await _context.TitleBasics
                    .Where(p => p.Tconst == value)
                    .ToListAsync();
            }
            else 
            {
            titleBasics = await _context.TitleBasics
                .Where(p => p.PrimaryTitle.Contains(value))
                .OrderBy(p => p.PrimaryTitle)
                .Take(10)
                .ToListAsync();
            }

            return Ok(new { titleBasics = titleBasics });    // wrap array in object to prevent JSON hijacking
        }

        // GET: api/TitleBasics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TitleBasics>>> GetTitleBasics()
        {
            return await _context.TitleBasics.Take(10).ToListAsync();
        }

        // // GET: api/TitleBasics/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<TitleBasics>> GetTitleBasicsOnId(string id)
        // {
        //     var titleBasics = await _context.TitleBasics.FindAsync(id);

        //     if (titleBasics == null)
        //     {
        //         return NotFound();
        //     }

        //     return titleBasics;
        // }

        // GET: api/TitleBasics/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<TitleBasics>> GetTitleBasics(string id)
        // {
        //     var titleBasics = await _context.TitleBasics.FindAsync(id);

        //     if (titleBasics == null)
        //     {
        //         return NotFound();
        //     }

        //     return titleBasics;
        // }

        // PUT: api/TitleBasics/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTitleBasics(string id, TitleBasics titleBasics)
        {
            if (id != titleBasics.Tconst)
            {
                return BadRequest();
            }

            _context.Entry(titleBasics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TitleBasicsExists(id))
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

        // POST: api/TitleBasics
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TitleBasics>> PostTitleBasics(TitleBasics titleBasics)
        {
            _context.TitleBasics.Add(titleBasics);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TitleBasicsExists(titleBasics.Tconst))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTitleBasics", new { id = titleBasics.Tconst }, titleBasics);
        }

        // DELETE: api/TitleBasics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TitleBasics>> DeleteTitleBasics(string id)
        {
            var titleBasics = await _context.TitleBasics.FindAsync(id);
            if (titleBasics == null)
            {
                return NotFound();
            }

            _context.TitleBasics.Remove(titleBasics);
            await _context.SaveChangesAsync();

            return titleBasics;
        }

        private bool TitleBasicsExists(string id)
        {
            return _context.TitleBasics.Any(e => e.Tconst == id);
        }
    }
}
