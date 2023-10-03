using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearDemand.MarkdownPlan.Shared
{
    public class ProductStorage
    {
        public int ProductStorageId { get; set; }

        public int ProductId { get; set; }

        public string Location { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
