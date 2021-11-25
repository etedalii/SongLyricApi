using System;
using System.Collections.Generic;

#nullable disable

namespace SongLyricEntities
{
    public partial class Artist
    {
        public int Id { get; set; }
        public string ArtistName { get; set; }
        public DateTime ActiveFrom { get; set; }
    }
}
