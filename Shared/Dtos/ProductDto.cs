﻿namespace Shared.Dtos
{
    public record ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string PictureUrl { get; set; } = string.Empty;
        public string TypeName { get; set; } = string.Empty;
        public string BrandName { get; set; } = string.Empty;
    }
}