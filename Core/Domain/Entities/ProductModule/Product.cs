namespace Domain.Entities.ProductModule
{
    public class Product: BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string PictureUrl { get; set; } = string.Empty;

        // Navigation Properties
        public ProductType ProductType { get; set; }
        public int TypeId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public int BrandId { get; set; }

    }
}
