using System;
using System.Collections.Generic;

namespace PSSDotNetTrainingBatch2.Database.AppDbContextModels;

public partial class TblProduct
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public bool DeleteFlag { get; set; }
}
