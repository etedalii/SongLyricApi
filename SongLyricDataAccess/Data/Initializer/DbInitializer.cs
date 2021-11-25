using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongLyricDataAccess.Data.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly SongLyricDbContext _context;

        public DbInitializer(SongLyricDbContext dbContext)
        {
            _context = dbContext;

        }

        public void Initialize()
        {
            CheckMigration();

            if (!_context.Genres.Any())
            {
                _context.Genres.AddRange(new SongLyricEntities.Genre[] {new SongLyricEntities.Genre()
                {
                    GenreName = "Rock"
                },
                new SongLyricEntities.Genre()
                {
                    GenreName = "Pop"
                },
                new SongLyricEntities.Genre()
                {
                    GenreName = "Country"
                },
                new SongLyricEntities.Genre()
                {
                    GenreName = "Jazz"
                },
                new SongLyricEntities.Genre()
                {
                    GenreName = "Hip Hop"
                },
                new SongLyricEntities.Genre()
                {
                    GenreName = "Blues"
                },new SongLyricEntities.Genre()
                {
                    GenreName = "Classical"
                }});

                _context.SaveChanges();
            }
        }

        private void CheckMigration()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
