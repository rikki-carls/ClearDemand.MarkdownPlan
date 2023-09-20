using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearDemand.MarkdownPlan.Shared
{
    public class MarkdownPlan
    {
        public string MarkdownPlanId { get; set; }

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ICollection<MarkdownRule> MarkdownRules { get; set; } = new List<MarkdownRule>();
        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

        public string ProductId { get; set; }

        public bool Deleted { get; set; }

        public Product Product { get; set; }

        public bool IsEdit { get; set; }
    }
}
