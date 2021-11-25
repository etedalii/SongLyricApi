using System;
using System.Collections.Generic;

#nullable disable

namespace SongLyricEntities
{
    public partial class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Lyric { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
