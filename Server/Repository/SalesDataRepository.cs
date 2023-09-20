using AutoMapper;
using ClearDemandCodeExcercise.Data;
using ClearDemandCodeExcercise.Data.Model;

namespace ClearDemand.MarkdownPlan.Server.Repository
{
    public interface ISalesDataRepository
    {
        void SaveSales(Shared.Sale[] sales);
    }
    public class SalesDataRepository : ISalesDataRepository
    {
        private ProductTestContext dbContext;
        private IMapper mapper;
        public SalesDataRepository(ProductTestContext context, IMapper mapper)
        {
            dbContext = context;
            this.mapper = mapper;

        }

        public void SaveSales(Shared.Sale[] sales)
        {
            foreach (var s in sales)
            {
                var existing = dbContext.Sales.Where(x => x.SaleId == s.SaleId).FirstOrDefault();
                if(existing != null) { 
                    dbContext.Sales.Remove(existing);
                }

            }
            dbContext.Sales.AddRange(mapper.Map<Sale[]>(sales));
            dbContext.SaveChanges();
        }
    }
}
