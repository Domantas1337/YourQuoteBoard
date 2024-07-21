namespace YourQuoteBoard.DTO.Rating.Interfaces
{
    public interface IRatingCreateDTO
    {
        public double Rating { get; set; }
        public Guid ItemId { get; set; }
    }
}
