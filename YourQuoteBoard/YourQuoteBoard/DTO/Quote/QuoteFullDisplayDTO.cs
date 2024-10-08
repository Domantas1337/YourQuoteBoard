﻿using YourQuoteBoard.DTO.Tag;

namespace YourQuoteBoard.DTO.Quote
{
    public class QuoteFullDisplayDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public string BookTitle { get; set; }
        public Guid BookId { get; set; }
        public double? AverageRating { get; set; }
        public int? NumberOfRatings { get; set; }
        public ICollection<TagDisplayDTO> Tags { get; set; }
    }
}
