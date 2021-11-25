using SongLyricDataAccess.Data.Repository.IRepository;
using SongLyricEntities;

namespace SongLyricDataAccess.Data.Repository
{
    internal class AlbumDetailRepository : Repository<AlbumDetail> , IAlbumDetailRepository
    {
        private readonly SongLyricDbContext _dbContext;

        public AlbumDetailRepository(SongLyricDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext; 
        }
    }
}