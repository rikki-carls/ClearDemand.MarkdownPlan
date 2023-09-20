using System;
using System.Collections.Generic;

namespace ClearDemandCodeExcercise.Data.Model;

public partial class MarkdownPlan
{
    public string MarkdownPlanId { get; set; }

    public string? Description { get; set; }

    public string ProductId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public bool Deleted { get; set; }

    public virtual ICollection<MarkdownRule> MarkdownRules { get; set; } = new List<MarkdownRule>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual Product Product { get; set; } = null!;
}
