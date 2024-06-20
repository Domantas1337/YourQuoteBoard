namespace YourQuoteBoard.DTO.Book
{
    public class BookDisplayDTO
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public IFormFile CoverImage { get; set; }
    }
}
