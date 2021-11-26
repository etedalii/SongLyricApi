using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongLyricEntities.DTOs
{
    public class GenreForCreationDto
    {
        [Required]
        public string GenreName { get; set; }
    }
}
