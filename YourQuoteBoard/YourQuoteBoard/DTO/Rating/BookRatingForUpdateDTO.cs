﻿namespace YourQuoteBoard.DTO.Rating
{
    public class BookRatingForUpdateDTO
    {
        public Guid BookRatingId { get; set; }
        public double PreviousRating { get; set; }
        public double NewRating { get; set; }
        public Guid BookId { get; set; }
    }
}
