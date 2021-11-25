using SongLyricDataAccess.Data.Repository.IRepository;
using SongLyricEntities;

namespace SongLyricDataAccess.Data.Repository
{
    internal class SongRepository : Repository<Song> , ISongRepository
    {
        private readonly SongLyricDbContext _dbContext;

        public SongRepository(SongLyricDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext; 
        }
    }
}