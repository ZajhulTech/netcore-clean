using System;
using System.Collections.Generic;

namespace PaymentDemo.Models.DataBase;

public partial class Sale
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime Date { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
}
