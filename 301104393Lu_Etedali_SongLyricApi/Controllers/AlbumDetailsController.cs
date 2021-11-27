using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SongLyricDataAccess.Data;
using SongLyricDataAccess.Data.Repository.IRepository;
using SongLyricEntities;

namespace _301104393Lu_Etedali_SongLyricApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumDetailsController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public AlbumDetailsController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/AlbumDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlbumDetail>> GetAlbumDetail(int id)
        {
            var albumDetail = await _context.AlbumDetail.GetAllAsync(_ => _.AlbumId == id);
            var albums = await _context.Album.GetAllAsync(_ => _.Id == id);
            var songs = await _context.Song.GetAllAsync();

            var query =
               (from albumdetails in albumDetail
                join album in albums on albumdetails.AlbumId equals album.Id
                join song in songs on albumdetails.SongId equals song.Id
                select new { Id = albumdetails.Id, AlbumName = album.AlbumName, SongTitle = song.Title, AlbumId = album.Id, SongId = song.Id }).ToList();

            return Ok(query);
        }

        // PUT: api/AlbumDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlbumDetail(int id, AlbumDetail albumDetail)
        {
            if (id != albumDetail.Id)
            {
                return BadRequest();
            }

            _context.AlbumDetail.Update(albumDetail);

            try
            {
                await _context.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumDetailExists(id))
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

        // POST: api/AlbumDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AlbumDetail>> PostAlbumDetail(AlbumDetail albumDetail)
        {
            _context.AlbumDetail.Insert(albumDetail);
            await _context.SaveAsync();

            return Ok(albumDetail);
        }

        // DELETE: api/AlbumDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbumDetail(int id)
        {
            var albumDetail = await _context.AlbumDetail.FindAsync(id);
            if (albumDetail == null)
            {
                return NotFound();
            }

            _context.AlbumDetail.Remove(albumDetail);
            await _context.SaveAsync();

            return NoContent();
        }

        private bool AlbumDetailExists(int id)
        {
            return _context.AlbumDetail.Any(e => e.Id == id);
        }
    }
}