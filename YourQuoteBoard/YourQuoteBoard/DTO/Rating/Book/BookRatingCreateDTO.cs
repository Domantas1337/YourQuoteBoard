using YourQuoteBoard.DTO.Rating.Interfaces;

namespace YourQuoteBoard.DTO.Rating.Book
{
    public class BookRatingCreateDTO : IRatingCreateDTO
    {
        public double Rating { get; set; }
        public Guid ItemId { get; set; }
    }
}
