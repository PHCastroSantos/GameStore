using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.DTOs
{
    public class CreateGameDto
    (
        string Title, 
        string Genre, 
        double Price, 
        DateOnly ReleaseDate
        )
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
        public DateOnly ReleaseDate { get; set; }
    }   
}