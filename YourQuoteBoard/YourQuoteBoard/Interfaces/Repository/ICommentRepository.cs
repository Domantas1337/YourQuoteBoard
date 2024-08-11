using Microsoft.CodeAnalysis.Elfie.Model.Tree;
using YourQuoteBoard.DTO.Comment;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Enums;

namespace YourQuoteBoard.Interfaces.Repository
{
    public interface ICommentRepository
    {
        public Task PostCommentAsync(Comment comment);
        public Task<List<CommentDisplayDTO>> GetAllCommentsForAnItemAsync(Guid itemId, ItemType itemType);
    }
}
