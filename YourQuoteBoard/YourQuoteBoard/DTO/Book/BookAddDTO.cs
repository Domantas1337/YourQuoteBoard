namespace YourQuoteBoard.DTO.Book
{
    public class BookAddDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public IFormFile CoverImage { get; set; }
    }
}
