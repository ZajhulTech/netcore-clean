using PaymentDemo.Models.Api;
using PaymentDemo.Models.requests;
using PaymentDemo.Models.response;

namespace PaymentDemo.Interfaces.UserStorys
{
    public interface IsalesUserStory
    {
        string Description { get; set; }
        string Name { get; set; }

        Task<Response<List<ProductResponse>>> getProducts();
        Task<Response<List<SalesDetailResponse>>> getSales();
        Task<Response<ProductResponse>> setProducts(productsResquest product);
    }
}