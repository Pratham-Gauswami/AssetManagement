using System;
using System.Collections.Generic;

namespace AssetManagement.Models;

public partial class EmployeeHavingAsset
{
    public int EmployeeId { get; set; }

    public string AssetId { get; set; } = null!;

    public string AssetName { get; set; } = null!;

    public string MakeCompany { get; set; } = null!;

    public int Value { get; set; }
}
