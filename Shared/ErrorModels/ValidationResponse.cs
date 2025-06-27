namespace Shared.ErrorModels
{
    public class ValidationResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; } = "Validation Failed";

        public IEnumerable<ValidationError> Errors { get; set; } = [];
    }
}
