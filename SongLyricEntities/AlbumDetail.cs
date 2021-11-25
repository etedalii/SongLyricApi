using System;
using System.Collections.Generic;

#nullable disable

namespace SongLyricEntities
{
    public partial class AlbumDetail
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public int SongId { get; set; }
    }
}
