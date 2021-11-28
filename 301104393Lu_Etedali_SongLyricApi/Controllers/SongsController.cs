using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SongLyricDataAccess.Data.Repository.IRepository;
using SongLyricEntities;
using SongLyricEntities.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _301104393Lu_Etedali_SongLyricApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        public SongsController(IUnitOfWork context,  IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Songs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            return Ok(await _context.Song.GetAllAsync());
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(int id)
        {
            var song = await _context.Song.FindAsync(id);

            if (song == null)
            {
                return NotFound();
            }

            return Ok(song);
        }

        [HttpGet("/api/Songs/getbytitle/{title}")]
        public async Task<ActionResult<Song>> GetByTitle(string title)
        {
            var songs = await _context.Song.GetAllAsync(_ => _.Lyric.Contains(title) || _.Title.Contains(title));
            var result = _mapper.Map<IEnumerable<SongWithoutIdDto>>(songs);
            return Ok(result);
        }

        // PUT: api/Songs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong(int id, Song song)
        {
            if (id != song.Id)
            {
                return BadRequest();
            }

            _context.Song.Update(song);

            try
            {
                await _context.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
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

        // POST: api/Songs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            _context.Song.Insert(song);
            await _context.SaveAsync();

            return Ok(song);
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            var song = await _context.Song.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            _context.Song.Remove(song);
            await _context.SaveAsync();

            return NoContent();
        }

        private bool SongExists(int id)
        {
            return _context.Song.Any(e => e.Id == id);
        }
    }
}
