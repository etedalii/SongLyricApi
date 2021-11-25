using Microsoft.EntityFrameworkCore;
using SongLyricEntities;

#nullable disable

namespace SongLyricDataAccess.Data
{
    public partial class SongLyricDbContext : DbContext
    {
        public SongLyricDbContext()
        {
        }

        public SongLyricDbContext(DbContextOptions<SongLyricDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<AlbumDetail> AlbumDetails { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");

            modelBuilder.Entity<Album>(entity =>
            {
                entity.Property(e => e.AlbumName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK_Albums_Genres");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.Property(e => e.ActiveFrom).HasColumnType("date");

                entity.Property(e => e.ArtistName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.GenreName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.Property(e => e.Lyric).IsRequired();

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
