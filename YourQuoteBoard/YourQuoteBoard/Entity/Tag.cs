using YourQuoteBoard.Enums;

namespace YourQuoteBoard.Entity
{
    public class Tag
    {
        public Guid TagId { get; set; }
        public required string Name { get; set; }
        public required bool IsDefault { get; set; }
        public required TagType Discriminator { get; set; }

    }
}
