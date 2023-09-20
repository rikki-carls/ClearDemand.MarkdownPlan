using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearDemand.MarkdownPlan.Shared
{
    public class MarkdownRule
    {
        public string MarkdownRuleId { get; set; }

        public string MarkdownPlanId { get; set; }

        public DateTime EffectiveDate { get; set; }

        public int PriceReductionPercent { get; set; }

    }
}
