using Microsoft.AspNetCore.Mvc;
using Shopping.API.Data;
using Shopping.API.Models;
using MongoDB.Driver;

namespace Shopping.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> logger_;
        private readonly ProductContext productContext_;

        public ProductController(ILogger<ProductController> logger, ProductContext productContext) 
        {
            logger_ = logger;
            productContext_ = productContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            var products = await productContext_.Products.FindAsync(_ => true);
            return products.ToList();
        }
    }
}
