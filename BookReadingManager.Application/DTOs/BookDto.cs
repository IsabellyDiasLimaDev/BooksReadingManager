﻿

namespace BookReadingManager.Application.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public long PageCount { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Format { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}
