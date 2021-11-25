using System;
using System.Collections.Generic;

#nullable disable

namespace SongLyricEntities
{
    public partial class Genre
    {
        public Genre()
        {
            Albums = new HashSet<Album>();
        }

        public int Id { get; set; }
        public string GenreName { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
