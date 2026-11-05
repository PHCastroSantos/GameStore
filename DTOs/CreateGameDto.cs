using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GameStore.DTOs
{
    public class CreateGameDto
    (
        [Required][StringLength(50)] string Title, 
        [Required][StringLength(20)] string Genre, 
        [Range(1,300)] double Price, 
        DateOnly ReleaseDate
        )
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
        public DateOnly ReleaseDate { get; set; }
    }   
}