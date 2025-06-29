using System;
using System.Collections.Generic;

namespace PSSDotNetTrainingBatch2.Database.AppDbContextModels;

public partial class TblStudent
{
    public int StudentId { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }
}
