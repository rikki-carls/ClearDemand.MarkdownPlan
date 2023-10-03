using ClearDemand.MarkdownPlan.Server.Repository;
using ClearDemand.MarkdownPlan.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ClearDemand.MarkdownPlan.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarkdownPlanController : ControllerBase
    {
       

        private readonly ILogger<ProductController> _logger;
        private IMarkdownPlanRepository markdownPlanRepository;

        public MarkdownPlanController(ILogger<ProductController> logger, IMarkdownPlanRepository markdownPlanRepository)
        {
            _logger = logger;
            this.markdownPlanRepository = markdownPlanRepository;
        }

        [HttpGet]
        public IEnumerable<Shared.MarkdownPlan> Get()
        {
            return markdownPlanRepository.GetMarkdownPlans();
        }
        [HttpPost]
        public void Save(Shared.MarkdownPlan markdownPlan)
        {
            markdownPlanRepository.SaveMarkdownPlan(markdownPlan);
        }

        [HttpPut]
        public void Update(Shared.MarkdownPlan markdownPlan)
        {
            markdownPlanRepository.UpdateMarkdownPlan(markdownPlan);
        }
        [HttpDelete]
        public Shared.MarkdownPlan Delete(int planId)
        {
            markdownPlanRepository.DeleteMarkdownPlan(planId);
            return new Shared.MarkdownPlan();
        }
    }
}