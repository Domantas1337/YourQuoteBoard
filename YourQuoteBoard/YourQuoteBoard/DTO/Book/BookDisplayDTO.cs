﻿using YourQuoteBoard.DTO.Tag;

namespace YourQuoteBoard.DTO.Book
{
    public class BookDisplayDTO
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string CoverImagePath { get; set; }
        public double? AverageRating { get; set; }
        public int? NumberOfRatings { get; set; }
        public ICollection<TagDisplayDTO> Tags { get; set; } = [];
    }
}
