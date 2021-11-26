using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SongLyricDataAccess.Data;
using SongLyricDataAccess.Data.Repository.IRepository;
using SongLyricEntities;
using SongLyricEntities.DTOs;

namespace _301104393Lu_Etedali_SongLyricApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;

        public GenresController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            var genres = await _context.Genre.GetAllAsync();
            var result = _mapper.Map<IEnumerable<GenreWithoutAlbumDto>>(genres);
            return Ok(result);
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenre(int id, bool includeAlbum = false)
        {
            var genre = await _context.Genre.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            if (includeAlbum)
            {
                var genres = _mapper.Map<GenreDto>(genre);
                return Ok(genres);
            }

            return Ok(_mapper.Map<GenreWithoutAlbumDto>(genre));
        }

        // PUT: api/Genres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre(int id, Genre genre)
        {
            if (genre == null)
                return BadRequest();

            var oldGenre = _context.Genre.Find(id);
            var result = _mapper.Map<Genre>(genre);
            oldGenre.GenreName = result.GenreName;

            _context.Genre.Update(oldGenre);
            try
            {
                if (await _context.SaveAsync() == 0)
                {
                    return StatusCode(500, "A problem with handelling your request.");
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(id))
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

        // POST: api/Genres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
            if (genre == null)
                return BadRequest();

            var result = _mapper.Map<Genre>(genre);
            _context.Genre.Insert(new Genre() {  GenreName = result.GenreName});
            if (await _context.SaveAsync() == 0)
            {
                return StatusCode(500, "A problem with handelling your request.");
            }

            var createGenre = _mapper.Map<Genre>(result);
            return Ok(createGenre);
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var genre = await _context.Genre.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            _context.Genre.Remove(genre);
            if (await _context.SaveAsync() == 0)
            {
                return StatusCode(500, "A problem with handelling your request.");
            }

            return NoContent();
        }

        private bool GenreExists(int id)
        {
            return _context.Genre.Any(e => e.Id == id);
        }
    }
}
