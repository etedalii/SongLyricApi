using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongLyricEntities.DTOs
{
    public class AlbumDetailDto
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public int SongId { get; set; }

        public string AlbumName { get; set; }
        public string SongTitle { get; set; }
    }
}
