using System;
using System.Collections.Generic;

namespace AssetManagement.Models;

public partial class EmployeeHavingAsset
{
    public string EmployeeId { get; set; } = null!;

    public string AssetId { get; set; } = null!;

    public string AssetName { get; set; } = null!;

    public string MakeCompany { get; set; } = null!;

    public int Value { get; set; }

    public DateTime DateOfAssign { get; set; }

    public DateTime DateOfReq { get; set; }
}
