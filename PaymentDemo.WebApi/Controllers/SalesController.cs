using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentDemo.Interfaces.UserStorys;
using PaymentDemo.Models.requests;

namespace PaymentDemo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController(IsalesUserStory isalesUserStory ) : ControllerBase
    {
        private readonly IsalesUserStory _isalesUserStory = isalesUserStory;


        [HttpGet]
        public async Task<IActionResult> getSales()
        {

            var response = await _isalesUserStory.getSales().ConfigureAwait(false);
           
            return Ok(response);
        }

        [HttpGet("Products")]
        public async Task<IActionResult> getProducts()
        {

            var response = await _isalesUserStory.getProducts().ConfigureAwait(false);

            return Ok(response);
        }

        [HttpPost("Products")]
        public async Task<IActionResult> setProducts(productsResquest request)
        {

            var response = await _isalesUserStory.setProducts(request).ConfigureAwait(false);

            return Created("",response);
        }


    }
}
