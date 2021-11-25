using SongLyricDataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongLyricDataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SongLyricDbContext _dbContext;
        public UnitOfWork(SongLyricDbContext dbContext)
        {
            _dbContext = dbContext;

            AlbumDetail = new AlbumDetailRepository(dbContext);
            Album = new AlbumRepository(dbContext);
            Artist = new ArtistRepository(dbContext);
            Genre = new GenreRepository(dbContext); 
            Song = new SongRepository(dbContext);
        }

        public IAlbumDetailRepository AlbumDetail { get; private set; }

        public IAlbumRepository Album { get; private set; }

        public IArtistRepository Artist { get; private set; }

        public IGenreRepository Genre { get; private set; }

        public ISongRepository Song { get; private set; }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
