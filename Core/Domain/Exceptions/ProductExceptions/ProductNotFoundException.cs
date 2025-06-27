namespace Domain.Exceptions.ProductExceptions
{
    public sealed class ProductNotFoundException(int id) : NotFoundException($"Product with id: {id} not found.")
    {
    }
}
