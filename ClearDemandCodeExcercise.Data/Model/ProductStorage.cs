using System;
using System.Collections.Generic;

namespace ClearDemandCodeExcercise.Data.Model;

public partial class ProductStorage
{
    public string ProductStorageId { get; set; }

    public string ProductId { get; set; }

    public string Location { get; set; } = null!;

    public int Quantity { get; set; }
    public bool Deleted { get; set; }

    public virtual Product Product { get; set; } = null!;
}
