using ClearDemand.MarkdownPlan.Server.Repository;
using ClearDemand.MarkdownPlan.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ClearDemand.MarkdownPlan.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
       

        private readonly ILogger<ProductController> _logger;
        private IProductRepository productRepository;

        public ProductController(ILogger<ProductController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            this.productRepository = productRepository;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productRepository.GetProducts();
        }

        [HttpGet("/{productId}")]
        public Product Get(int productId)
        {
            var rtn = productRepository.GetProduct(productId);
            return productRepository.GetProduct(productId);
        }

        [HttpPost]
        public void Post(Product product)
        {
            productRepository.AddProduct(product);
        }

        [HttpPut]
        public void Update(Shared.Product product)
        {
            productRepository.UpdateProduct(product);
        }
        [HttpDelete("/{productId}")]
        public Product Delete(int productId)
        {
            productRepository.DeleteProduct(productId);
            return new Product();
        }
    }
}