namespace Application.DTOs.ItemDTOs
{
    public record AddDto
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public double Quantity { get; set; }
    }
}
