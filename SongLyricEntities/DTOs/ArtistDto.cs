using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongLyricEntities.DTOs
{
    public class ArtistDto
    {
        public int Id { get; set; }
        public string ArtistName { get; set; }
        public DateTime ActiveFrom { get; set; }
    }
}
