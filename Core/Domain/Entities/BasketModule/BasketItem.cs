namespace Domain.Entities.BasketModule
{
    public class BasketItem
    {
        public string Id { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string PictureUrl { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
