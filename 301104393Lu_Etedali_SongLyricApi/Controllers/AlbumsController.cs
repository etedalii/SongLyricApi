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
    public class AlbumsController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;

        public AlbumsController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Albums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
        {
            var albums = await _context.Album.GetAllAsync();
            var artists = await _context.Artist.GetAllAsync();
            var genres = await _context.Genre.GetAllAsync();

            var query =
               (from album in albums
               join artist in artists on album.ArtistId equals artist.Id
               join genre in genres on album.GenreId equals genre.Id
               select new { Id = album.Id,  AlbumName = album.AlbumName, ReleaseDate = album.ReleaseDate, ArtistName = artist.ArtistName, GenreName = genre.GenreName }).ToList();

            return Ok(query);
        }

        // GET: api/Albums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {
            var albums = await _context.Album.GetAllAsync();
            var artists = await _context.Artist.GetAllAsync();
            var genres = await _context.Genre.GetAllAsync();

            var query =
                (from album in albums
                 join artist in artists on album.ArtistId equals artist.Id
                 join genre in genres on album.GenreId equals genre.Id
                 where album.Id == id
                 select new { Id = album.Id, AlbumName = album.AlbumName, ReleaseDate = album.ReleaseDate, ArtistName = artist.ArtistName, GenreName = genre.GenreName }).ToList();

            return Ok(query);
        }

        // PUT: api/Albums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlbum(int id, Album album)
        {
            if (album == null)
                return BadRequest();

            var oldAlbum = _context.Album.Find(id);
            var result = _mapper.Map<Album>(album);
            oldAlbum.AlbumName = result.AlbumName;
            oldAlbum.ArtistId = result.ArtistId;
            oldAlbum.GenreId = result.GenreId;
            oldAlbum.ReleaseDate = result.ReleaseDate;

            _context.Album.Update(oldAlbum);
            try
            {
                if (await _context.SaveAsync() == 0)
                {
                    return StatusCode(500, "A problem with handelling your request.");
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(id))
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

        // POST: api/Albums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Album>> PostAlbum(Album album)
        {
            if (album == null)
                return BadRequest();

            var result = _mapper.Map<Album>(album);
            _context.Album.Insert(new Album() { AlbumName = result.AlbumName, ArtistId = result.ArtistId, GenreId = result.GenreId,ReleaseDate = result.ReleaseDate });
            if (await _context.SaveAsync() == 0)
            {
                return StatusCode(500, "A problem with handelling your request.");
            }

            var createAlbum = _mapper.Map<Album>(result);
            return Ok(createAlbum);
        }

        // DELETE: api/Albums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            var album = await _context.Album.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            _context.Album.Remove(album);
            await _context.SaveAsync();

            return NoContent();
        }

        private bool AlbumExists(int id)
        {
            return _context.Album.Any(e => e.Id == id);
        }
    }
}
