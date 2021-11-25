using SongLyricDataAccess.Data.Repository.IRepository;
using SongLyricEntities;

namespace SongLyricDataAccess.Data.Repository
{
    internal class AlbumRepository : Repository<Album> , IAlbumRepository
    {
        private readonly SongLyricDbContext _dbContext;

        public AlbumRepository(SongLyricDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext; 
        }
    }
}