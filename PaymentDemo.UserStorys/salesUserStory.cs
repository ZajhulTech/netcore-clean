using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PaymentDemo.Infra.DataBase;
using PaymentDemo.Interfaces.UserStorys;
using PaymentDemo.Models.Api;
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

        public async Task<Response<List<SalesDetailResponse>>> getSales()
        {
            List<SalesDetailResponse> data = new List<SalesDetailResponse>();
            Response<List<SalesDetailResponse>> result = new Response<List<SalesDetailResponse>>();

            var saleDetailsModelList = await _context.VwSaleDetails.ToListAsync().ConfigureAwait(false);

            foreach (var item in saleDetailsModelList)
            {

                data.Add(new SalesDetailResponse
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
            result.Data = data;
            result.AddStatusCode(200);
            return result;
        }

        public async Task<Response<List<ProductResponse>>> getProducts()
        {
            List<ProductResponse> data = new List<ProductResponse>();
            Response<List<ProductResponse>> result = new Response<List<ProductResponse>>();

            data = await _context.Products.Select(item => new ProductResponse
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedAt = item.CreatedAt
            }).ToListAsync().ConfigureAwait(false);

            result.Data = data;
            result.AddStatusCode(200);
            return result;
        }

        public async Task<Response<ProductResponse>> setProducts(productsResquest product  )
        {
       
            Response<ProductResponse> result = new Response<ProductResponse>();

            var Product = new Product{
                Price = product.Price,
                Name = product.Name,
                CreatedBy = "manager",
            };

            var data1 = await _context.Products.AddAsync(Product).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            ProductResponse data = new ProductResponse
            { 
                Name = Product.Name,
                Price = Product.Price,    
                Id    = Product.Id,
                CreatedAt = Product.CreatedAt
            
            };
            result.Data = data;
            result.AddStatusCode(201);
            return result;
        }



    }
}
