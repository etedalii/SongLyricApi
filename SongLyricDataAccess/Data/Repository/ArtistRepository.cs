using SongLyricDataAccess.Data.Repository.IRepository;
using SongLyricEntities;

namespace SongLyricDataAccess.Data.Repository
{
    internal class ArtistRepository : Repository<Artist> , IArtistRepository
    {
        private readonly SongLyricDbContext _dbContext;

        public ArtistRepository(SongLyricDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext; 
        }
    }
}