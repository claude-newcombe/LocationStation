using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LocationStationDataAccessLibrary.LocationStationContext;
using LocationStationDataAccessLibrary.Models;

namespace LocationStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicItemsController : ControllerBase
    {
        private readonly LocationStationContext _context;

        public MusicItemsController(LocationStationContext context)
        {
            _context = context;
        }

        // GET: api/MusicItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicItem>>> GetMusicItems()
        {
            return await _context.MusicItems.ToListAsync();
        }

        // GET: api/MusicItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MusicItem>> GetMusicItem(int id)
        {
            var musicItem = await _context.MusicItems.FindAsync(id);

            if (musicItem == null)
            {
                return NotFound();
            }

            return musicItem;
        }

        // PUT: api/MusicItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusicItem(int id, MusicItem musicItem)
        {
            if (id != musicItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(musicItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicItemExists(id))
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

        // POST: api/MusicItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MusicItem>> PostMusicItem(MusicItem musicItem)
        {
            _context.MusicItems.Add(musicItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMusicItem), new { id = musicItem.Id }, musicItem);
        }

        // DELETE: api/MusicItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MusicItem>> DeleteMusicItem(int id)
        {
            var musicItem = await _context.MusicItems.FindAsync(id);
            if (musicItem == null)
            {
                return NotFound();
            }

            _context.MusicItems.Remove(musicItem);
            await _context.SaveChangesAsync();

            return musicItem;
        }

        private bool MusicItemExists(int id)
        {
            return _context.MusicItems.Any(e => e.Id == id);
        }
    }
}
