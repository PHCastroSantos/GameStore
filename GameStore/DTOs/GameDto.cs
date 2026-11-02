using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.DTOs
{
    public class GameDto(
        int Id,
        string Title,
        string Genre,
        double Price,
        DateOnly ReleaseDate
    )
    {
        public int Id { get; set; } = Id;
        public string Title { get; set; } = Title;
        public string Genre { get; set; } = Genre;
        public double Price { get; set; } = Price;
        public DateOnly ReleaseDate { get; set; } = ReleaseDate;
    }
}