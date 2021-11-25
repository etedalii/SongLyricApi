namespace SongLyricDataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IAlbumDetailRepository AlbumDetail { get; }
        IAlbumRepository Album { get; }
        IArtistRepository Artist { get; }
        IGenreRepository Genre { get; }
        ISongRepository Song { get; }
        int Save();
    }
}