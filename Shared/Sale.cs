﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearDemand.MarkdownPlan.Shared
{
    public class Sale
    {
        public int SaleId { get; set; }

        public int MarkdownPlanId { get; set; }

        public DateTime? SaleDate { get; set; }

        public int Quantity { get; set; }
        public decimal Cost { get; set; }

        public decimal AdjustedPrice { get; set; }

        public decimal Profit { get { return (AdjustedPrice - Cost) * Quantity; } }
        public decimal Margin { get { return (AdjustedPrice - Cost); } }
        public int InventoryLeft { get; set; }

    }
}
