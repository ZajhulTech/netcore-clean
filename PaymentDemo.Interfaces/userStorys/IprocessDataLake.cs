using PaymentDemo.Models.requests;

namespace PaymentDemo.Interfaces.UserStorys
{
    public interface IprocessDataLake
    {
        Task<string> GetHeading();
        Task<List<productsResquest>> getProductsAsync();
    }
}