namespace Application.BussinessLogic.Items.DTOs
{
    public record ItemDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public double Quantity { get; set; }
    }
}
