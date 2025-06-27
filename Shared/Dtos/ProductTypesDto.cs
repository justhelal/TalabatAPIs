namespace Shared.Dtos
{
    public record ProductTypesDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
