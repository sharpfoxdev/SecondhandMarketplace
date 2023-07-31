using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Marketplace.API.Data;
using Marketplace.API.Models.Domain;

namespace Marketplace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothesController : ControllerBase
    {
        private readonly MarketplaceDbContext _context;

        public ClothesController(MarketplaceDbContext context)
        {
            _context = context;
        }

        // GET: api/Clothes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clothes>>> GetClothes()
        {
          if (_context.Clothes == null)
          {
              return NotFound();
          }
            return await _context.Clothes.ToListAsync();
        }

        // GET: api/Clothes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clothes>> GetClothes(Guid id)
        {
          if (_context.Clothes == null)
          {
              return NotFound();
          }
            var clothes = await _context.Clothes.FindAsync(id);

            if (clothes == null)
            {
                return NotFound();
            }

            return clothes;
        }

        // PUT: api/Clothes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClothes(Guid id, Clothes clothes)
        {
            if (id != clothes.Id)
            {
                return BadRequest();
            }

            _context.Entry(clothes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClothesExists(id))
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

        // POST: api/Clothes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Clothes>> PostClothes(Clothes clothes)
        {
          if (_context.Clothes == null)
          {
              return Problem("Entity set 'MarketplaceDbContext.Clothes'  is null.");
          }
            _context.Clothes.Add(clothes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClothes", new { id = clothes.Id }, clothes);
        }

        // DELETE: api/Clothes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothes(Guid id)
        {
            if (_context.Clothes == null)
            {
                return NotFound();
            }
            var clothes = await _context.Clothes.FindAsync(id);
            if (clothes == null)
            {
                return NotFound();
            }

            _context.Clothes.Remove(clothes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClothesExists(Guid id)
        {
            return (_context.Clothes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
