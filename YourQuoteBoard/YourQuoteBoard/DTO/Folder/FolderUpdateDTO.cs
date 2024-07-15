using YourQuoteBoard.Entity;

namespace YourQuoteBoard.DTO.Folder
{
    public class FolderUpdateDTO
    {
        public Guid FolderId { get; set; }
        public required string Name { get; set; }
        public List<QuoteDisplayDTO> Quotes { get; set; } = new List<QuoteDisplayDTO>();
    }
}
