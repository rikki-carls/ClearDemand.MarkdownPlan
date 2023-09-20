using ClearDemand.MarkdownPlan.Server.Repository;
using ClearDemand.MarkdownPlan.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ClearDemand.MarkdownPlan.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesDataController : ControllerBase
    {
       

        private readonly ILogger<ProductController> _logger;
        private ISalesDataRepository salesDataRepository;

        public SalesDataController(ILogger<ProductController> logger, ISalesDataRepository salesDataRepository)
        {
            _logger = logger;
            this.salesDataRepository = salesDataRepository;
        }

        
        [HttpPost]
        public void Save(Shared.Sale[] sales)
        {
            salesDataRepository.SaveSales(sales);
        }
    }
}