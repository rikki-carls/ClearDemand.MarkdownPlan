﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearDemandCodeExcercise.Data.Model
{
    public partial class Sale
    {
        public string SaleId { get; set; } = null!;

        public string MarkdownPlanId { get; set; } = null!;

        public DateTime? SaleDate { get; set; }

        public int Quantity { get; set; }
        public decimal Cost { get; set; }

        public decimal AdjustedPrice { get; set; }

        public virtual MarkdownPlan MarkdownPlan { get; set; } = null!;
    }
}
