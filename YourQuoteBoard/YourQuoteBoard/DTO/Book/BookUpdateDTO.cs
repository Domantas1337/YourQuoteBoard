namespace YourQuoteBoard.DTO.Book
{
    public class BookUpdateDTO
    {
        public required Guid BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public ICollection<Guid> TagIds { get; set; } = new HashSet<Guid>();
        public IFormFile? CoverImage { get; set; }
    }
}
