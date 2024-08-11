using YourQuoteBoard.DTO.Comment;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Enums;

namespace YourQuoteBoard.Interfaces.Service
{
    public interface ICommentService
    {
        public Task PostCommentAsync(string userId, CommentCreateDTO comment);
        public Task<List<CommentDisplayDTO>> GetAllCommentsForAnItemAsync(Guid itemId, ItemType itemType);

    }
}
