using AutoMapper;
using ClearDemandCodeExcercise.Data;
using ClearDemandCodeExcercise.Data.Model;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto;

namespace ClearDemand.MarkdownPlan.Server.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Shared.Product> GetProducts();
        Shared.Product GetProduct(int productId);
        void UpdateProduct(Shared.Product product);
        void AddProduct(Shared.Product product);
        void DeleteProduct(int productId);
    }
    public class ProductRepository : IProductRepository
    {
        private ProductTestContext dbContext;
        private IMapper mapper;
        public ProductRepository(ProductTestContext context, IMapper mapper)
        {
            dbContext = context;
            this.mapper = mapper;

        }

        public IEnumerable<Shared.Product> GetProducts()
        {
            var rtn = dbContext.Products
                .Include(x => x.ProductStorages)
                .ToArray();

            return mapper.Map<IEnumerable<Shared.Product>>(rtn);
        }

        public Shared.Product GetProduct(int productId)
        {
            var rtn = dbContext.Products
                .Include(x => x.ProductStorages)
                .Where(x=>x.ProductId == productId).FirstOrDefault();
            var rtn2 = mapper.Map<Shared.Product>(rtn);
            return mapper.Map<Shared.Product>(rtn);
        }

        public void UpdateProduct(Shared.Product product)
        {
            var prod = dbContext.Products.FirstOrDefault(x=>x.ProductId == product.ProductId);
            prod.Sku = product.Sku;
            prod.Cost = product.Cost;
            prod.Price = product.Price;
            foreach(var loc in product.ProductStorages)
            {
                var locEntity = dbContext.ProductStorages.FirstOrDefault(x => x.ProductStorageId == loc.ProductStorageId);
                locEntity.Location = loc.Location;
                locEntity.Quantity = loc.Quantity;
            }
            dbContext.SaveChanges();
        }

        public void AddProduct(Shared.Product product)
        {
            var entity = mapper.Map<Product>(product);
            
            foreach(var loc in product.ProductStorages)
            {
                loc.ProductId = entity.ProductId;
            }
            dbContext.Products.Add(entity);
            dbContext.SaveChanges();
        }

        public void DeleteProduct(int productId) 
        {
            var prod = dbContext.Products.Include(x=>x.ProductStorages).Where(x => x.ProductId == productId).FirstOrDefault();
            prod.Deleted = true;
            foreach(var loc in prod.ProductStorages)
            {
                loc.Deleted = true;
            }
            dbContext.SaveChanges();
        }

    }
}
