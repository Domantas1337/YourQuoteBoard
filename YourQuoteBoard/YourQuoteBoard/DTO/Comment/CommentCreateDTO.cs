using YourQuoteBoard.Enums;

namespace YourQuoteBoard.DTO.Comment
{
    public class CommentCreateDTO
    {
        public required string CommentText { get; set; }
        public double GivenRating { get; set; }
        public Guid ItemId { get; set; }
        public ItemType ItemType { get; set; }
    }
}
