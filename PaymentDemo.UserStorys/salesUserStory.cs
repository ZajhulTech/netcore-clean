using Microsoft.EntityFrameworkCore;
using PaymentDemo.Infra.DataBase;
using PaymentDemo.Interfaces.UserStorys;
using PaymentDemo.Models.DataBase;
using PaymentDemo.Models.requests;
using PaymentDemo.Models.response;

namespace PaymentDemo.UserStorys
{
    public class salesUserStory : IsalesUserStory
    {

        public string Name { get; set; }

        public string Description { get; set; }

        private readonly AppDbContext _context;

        public salesUserStory(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<SalesDetailResponse>> getSales()
        {

            List<SalesDetailResponse> result = new List<SalesDetailResponse>();

            var data = await _context.VwSaleDetails.ToListAsync().ConfigureAwait(false);

            foreach (var item in data)
            {

                result.Add(new SalesDetailResponse
                {
                    Amount = item.Amount,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    Description = item.Description,
                    Date = item.Date,
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    SaleDetailId = item.SaleDetailId,
                    SaleId = item.SaleId,
                    Subtotal = item.Subtotal,
                    UnitPrice = item.UnitPrice
                });
            }

            return result;
        }

        public async Task<List<ProductResponse>> getProducts()
        {

            var data = await _context.Products.Select(item => new ProductResponse
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedAt = item.CreatedAt
            }).ToListAsync().ConfigureAwait(false);


            return data;
        }

        public async Task<ProductResponse> setProducts(productsResquest product  )
        {

            var Product = new Product{
                Price = product.Price,
                Name = product.Name,
                CreatedBy = "manager",
            };

            var data = await _context.Products.AddAsync(Product).ConfigureAwait(false);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            ProductResponse result = new ProductResponse
            { 
                Name = Product.Name,
                Price = Product.Price,    
                Id    = Product.Id,
                CreatedAt = Product.CreatedAt
            
            };

            return result;
        }



    }
}
