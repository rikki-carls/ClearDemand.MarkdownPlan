using System;
using System.Collections.Generic;

namespace ClearDemandCodeExcercise.Data.Model;

public partial class Product
{
    public int ProductId { get; set; }

    public string Sku { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Cost { get; set; }

    public decimal Price { get; set; }
    public bool Deleted { get; set; }

    public virtual ICollection<MarkdownPlan> MarkdownPlans { get; set; } = new List<MarkdownPlan>();

    public virtual ICollection<ProductStorage> ProductStorages { get; set; } = new List<ProductStorage>();
}
