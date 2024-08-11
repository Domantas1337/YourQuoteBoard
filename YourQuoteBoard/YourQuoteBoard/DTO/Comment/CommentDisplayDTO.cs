namespace YourQuoteBoard.DTO.Comment
{
    public class CommentDisplayDTO
    {
        public required string CommentText { get; set; }
        public int NumberOfLikes { get; set; }
        public int NumberOfDislikes { get; set; }
        public DateTime PostedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public double GivenRating { get; set; }
        public required string PosterUsername { get; set; }
    }
}
