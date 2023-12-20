using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace TektonLabs.Core.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public bool Status { get; set; }

    public int Stock { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public void Update(string name, bool status, int stock, string description, decimal price)
    {
        this.Name = name;
        this.Status = status;
        this.Stock = stock;
        this.Description = description;
        this.Price = price;
    }
}
