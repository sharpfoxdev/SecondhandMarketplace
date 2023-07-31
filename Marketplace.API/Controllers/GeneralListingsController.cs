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
    public class GeneralListingsController : ControllerBase
    {
        private readonly MarketplaceDbContext _context;

        public GeneralListingsController(MarketplaceDbContext context)
        {
            _context = context;
        }

        // GET: api/GeneralListings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneralListing>>> GetGeneralListings()
        {
          if (_context.GeneralListings == null)
          {
              return NotFound();
          }
            return await _context.GeneralListings.ToListAsync();
        }

        // GET: api/GeneralListings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneralListing>> GetGeneralListing(Guid id)
        {
          if (_context.GeneralListings == null)
          {
              return NotFound();
          }
            var generalListing = await _context.GeneralListings.FindAsync(id);

            if (generalListing == null)
            {
                return NotFound();
            }

            return generalListing;
        }

        // PUT: api/GeneralListings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneralListing(Guid id, GeneralListing generalListing)
        {
            if (id != generalListing.Id)
            {
                return BadRequest();
            }

            _context.Entry(generalListing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneralListingExists(id))
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

        // POST: api/GeneralListings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GeneralListing>> PostGeneralListing(GeneralListing generalListing)
        {
          if (_context.GeneralListings == null)
          {
              return Problem("Entity set 'MarketplaceDbContext.GeneralListings'  is null.");
          }
            _context.GeneralListings.Add(generalListing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneralListing", new { id = generalListing.Id }, generalListing);
        }

        // DELETE: api/GeneralListings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeneralListing(Guid id)
        {
            if (_context.GeneralListings == null)
            {
                return NotFound();
            }
            var generalListing = await _context.GeneralListings.FindAsync(id);
            if (generalListing == null)
            {
                return NotFound();
            }

            _context.GeneralListings.Remove(generalListing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GeneralListingExists(Guid id)
        {
            return (_context.GeneralListings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
