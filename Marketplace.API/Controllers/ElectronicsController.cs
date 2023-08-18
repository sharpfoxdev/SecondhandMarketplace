using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Marketplace.API.Data;
using Marketplace.API.Models.Domain.Categories.Gear.Electronics;
using Marketplace.API.Models.DTO.AddListing;
using AutoMapper;

namespace Marketplace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectronicsController : ControllerBase
    {
        private readonly MarketplaceDbContext _context;
        private readonly IMapper _mapper;
        public ElectronicsController(MarketplaceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Electronics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Electronics>>> GetElectronics()
        {
          if (_context.Electronics == null)
          {
              return NotFound();
          }
            return await _context.Electronics.ToListAsync();
        }

        // GET: api/Electronics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Electronics>> GetElectronics(Guid id)
        {
          if (_context.Electronics == null)
          {
              return NotFound();
          }
            var electronics = await _context.Electronics.FindAsync(id);

            if (electronics == null)
            {
                return NotFound();
            }

            return electronics;
        }

        // PUT: api/Electronics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElectronics(Guid id, Electronics electronics)
        {
            if (id != electronics.Id)
            {
                return BadRequest();
            }

            _context.Entry(electronics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElectronicsExists(id))
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

        // POST: api/Electronics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Electronics>> PostElectronics([FromBody] CreateElectronicsListingDto electronics)
        {
            var electronicsDomain = _mapper.Map<Electronics>(electronics);
            if (_context.Electronics == null)
            {
                return Problem("Entity set 'MarketplaceDbContext.Electronics'  is null.");
            }
            _context.Electronics.Add(electronicsDomain);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElectronics", new { id = electronicsDomain.Id }, electronicsDomain);
        }

        // DELETE: api/Electronics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElectronics(Guid id)
        {
            if (_context.Electronics == null)
            {
                return NotFound();
            }
            var electronics = await _context.Electronics.FindAsync(id);
            if (electronics == null)
            {
                return NotFound();
            }

            _context.Electronics.Remove(electronics);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ElectronicsExists(Guid id)
        {
            return (_context.Electronics?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
