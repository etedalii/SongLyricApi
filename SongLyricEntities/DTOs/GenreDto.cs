using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongLyricEntities.DTOs
{
    public class GenreDto
    {
        public int Id { get; set; }
        public string GenreName { get; set; }

        public int NumberOfAlbumOnThisGenre
        {
            get
            {
                return Albums.Count;
            }
        }

        public ICollection<AlbumDto> Albums { get; set; } = new List<AlbumDto>();
    }
}
