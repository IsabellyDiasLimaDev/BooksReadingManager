using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BookReadingManager.Domain.Enums;

namespace BookReadingManager.Domain.Entities
{
    public class Book
    {

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string publisher { get; set; } = string.Empty;
        public long pageCount { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0.0m;
        public BookFormat Format { get; set; }
        public ReadingStatus Status { get; set; }
        public string Notes { get; set; } = "";

    }
}
