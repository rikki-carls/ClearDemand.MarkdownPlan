using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearDemand.MarkdownPlan.Shared
{
    public class ProductStorage
    {
        public string ProductStorageId { get; set; } = null!;

        public string ProductId { get; set; } = null!;

        public string Location { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
