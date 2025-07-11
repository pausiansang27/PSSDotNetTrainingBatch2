﻿using System;
using System.Collections.Generic;

namespace PSSDotNetTrainingBatch2.Project2.Database.AppDbContextModels;

public partial class TblProduct
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool DeleteFlag { get; set; }
}
