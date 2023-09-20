using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearDemand.MarkdownPlan.Shared
{
    public class Product
    {
        public string ProductId { get; set; }

        public string Sku { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Cost { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public bool Deleted { get; set; }

        public virtual ICollection<ProductStorage> ProductStorages { get; set; } = new List<ProductStorage>();

        public bool IsEdit { get; set; }
    }
}
