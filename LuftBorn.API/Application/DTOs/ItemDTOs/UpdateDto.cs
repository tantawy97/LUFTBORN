namespace Application.DTOs.ItemDTOs
{
    public record UpdateDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public double Quantity { get; set; }
    }
}
