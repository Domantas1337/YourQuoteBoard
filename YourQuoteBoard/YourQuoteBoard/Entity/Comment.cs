using Microsoft.CodeAnalysis.Elfie.Model.Tree;
using YourQuoteBoard.Enums;

namespace YourQuoteBoard.Entity
{
    public class Comment
    {
        public Guid CommentID { get; set; }
        public required string CommentText {  get; set; }
        public int NumberOfLikes { get; set; }
        public int NumberOfDislikes { get; set; }
        public DateTime PostedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public double GivenRating { get; set; }
        public Guid ItemId { get; set; }
        public ItemType ItemType { get; set; }  
        public required string ApplicationUserId { get; set; }

    }
}
