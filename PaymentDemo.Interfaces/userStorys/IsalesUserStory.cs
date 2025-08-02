using PaymentDemo.Models.requests;
using PaymentDemo.Models.response;

namespace PaymentDemo.Interfaces.UserStorys
{
    public interface IsalesUserStory
    {
        string Description { get; set; }
        string Name { get; set; }

        Task<List<ProductResponse>> getProducts();
        Task<List<SalesDetailResponse>> getSales();
        Task<ProductResponse> setProducts(productsResquest product);
    }
}