using YourQuoteBoard.Enums;

namespace YourQuoteBoard.DTO.Tag
{
    public class TagCreateDTO
    {
        public required string Name { get; set; }
        public required TagType Discriminator { get; set; }
    }
}
