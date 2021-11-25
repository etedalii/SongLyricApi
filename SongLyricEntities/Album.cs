using System;
using System.Collections.Generic;

#nullable disable

namespace SongLyricEntities
{
    public partial class Album
    {
        public int Id { get; set; }
        public string AlbumName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int? ArtistId { get; set; }
        public int? GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
