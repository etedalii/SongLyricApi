using SongLyricDataAccess.Data.Repository.IRepository;
using SongLyricEntities;

namespace SongLyricDataAccess.Data.Repository
{
    internal class GenreRepository : Repository<Genre> , IGenreRepository
    {
        private readonly SongLyricDbContext _dbContext;

        public GenreRepository(SongLyricDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext; 
        }
    }
}