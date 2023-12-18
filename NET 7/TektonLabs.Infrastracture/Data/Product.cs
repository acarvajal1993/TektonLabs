using System;
using System.Collections.Generic;

namespace TektonLabs.Infrastracture.Data;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public bool Status { get; set; }

    public int Stock { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }
}
