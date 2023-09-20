﻿using System;
using System.Collections.Generic;

namespace ClearDemandCodeExcercise.Data.Model;

public partial class MarkdownRule
{
    public string MarkdownRuleId { get; set; }

    public string MarkdownPlanId { get; set; }

    public DateTime EffectiveDate { get; set; }

    public int PriceReductionPercent { get; set; }
    public bool Deleted { get; set; }

    public virtual MarkdownPlan MarkdownPlan { get; set; } = null!;
}
