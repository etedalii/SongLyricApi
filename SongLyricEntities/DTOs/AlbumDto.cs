using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongLyricEntities.DTOs
{
    public class AlbumDto
    {
        public int Id { get; set; }
        public string AlbumName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int? ArtistId { get; set; }
    }
}