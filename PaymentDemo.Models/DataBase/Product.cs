using System;
using System.Collections.Generic;

namespace PaymentDemo.Models.DataBase;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
}
