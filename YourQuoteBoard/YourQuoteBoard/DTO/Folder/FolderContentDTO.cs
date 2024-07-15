namespace YourQuoteBoard.DTO.Folder
{
    public class FolderContentDTO
    {
        public required string Name { get; set; }
        public List<QuoteDisplayDTO> Quotes { get; set; } = new List<QuoteDisplayDTO>();
    }
}
