﻿namespace YourQuoteBoard.DTO.Rating.Book
{
    public class BookRatingCreateDTO
    {
        public double OverallRating { get; set; }
        public Guid BookId { get; set; }
    }
}
