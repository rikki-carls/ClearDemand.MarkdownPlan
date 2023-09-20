using AutoMapper;
using ClearDemandCodeExcercise.Data;
using ClearDemandCodeExcercise.Data.Model;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.EntityFrameworkCore;

namespace ClearDemand.MarkdownPlan.Server.Repository
{
    public interface IMarkdownPlanRepository {
        IEnumerable<Shared.MarkdownPlan> GetMarkdownPlans();
        void SaveMarkdownPlan(Shared.MarkdownPlan markdownPlan);
        void UpdateMarkdownPlan(Shared.MarkdownPlan markdownPlan);
        void DeleteMarkdownPlan(string markdownPlanId);
    }
    public class MarkdownPlanRepository : IMarkdownPlanRepository
    {
        private ProductTestContext dbContext;
        private IMapper mapper;
        public MarkdownPlanRepository(ProductTestContext context, IMapper mapper)
        {
            dbContext = context;
            this.mapper = mapper;

        }

        public IEnumerable<Shared.MarkdownPlan> GetMarkdownPlans()
        {

            var rtn = dbContext.MarkdownPlans
                .Include(x => x.MarkdownRules)
                .Include(x => x.Sales)
                .Include(x=>x.Product)
                .ThenInclude(x=>x.ProductStorages).ToArray();

            foreach(var row in rtn)
            {
                row.Sales = row.Sales.OrderBy(x => x.SaleDate).ToArray();
            }
            return mapper.Map<IEnumerable<Shared.MarkdownPlan>>(rtn);

        }

        public void SaveMarkdownPlan(Shared.MarkdownPlan markdownPlan)
        {
            var entity = mapper.Map<ClearDemandCodeExcercise.Data.Model.MarkdownPlan>(markdownPlan);
            dbContext.MarkdownPlans.Add(entity);
            dbContext.SaveChanges();
        }

        public void UpdateMarkdownPlan(Shared.MarkdownPlan markdownPlan)
        {
            var entity = dbContext.MarkdownPlans.FirstOrDefault(x=>x.MarkdownPlanId == markdownPlan.MarkdownPlanId);
            entity.StartDate = markdownPlan.StartDate;
            entity.EndDate = markdownPlan.EndDate;
            entity.Description = markdownPlan.Description;
            entity.ProductId = markdownPlan.ProductId;
            
            foreach(var rule in markdownPlan.MarkdownRules)
            {
                var ruleEntity = dbContext.MarkdownRules.FirstOrDefault(x=>x.MarkdownRuleId == rule.MarkdownRuleId);
                ruleEntity.PriceReductionPercent = rule.PriceReductionPercent;
                ruleEntity.EffectiveDate = rule.EffectiveDate;
            }
            dbContext.SaveChanges();
        }

        public void DeleteMarkdownPlan(string markdownPlanId)
        {
            var plan = dbContext.MarkdownPlans.Include(x=>x.MarkdownRules).FirstOrDefault(x => x.MarkdownPlanId == markdownPlanId);
            plan.Deleted = true;
            foreach(var rule in plan.MarkdownRules)
            {
                rule.Deleted = true;
            }
            dbContext.SaveChanges();

        }
    }
}
