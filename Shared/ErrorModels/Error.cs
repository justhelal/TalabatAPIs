namespace Shared.ErrorModels
{
    public record Error()
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
