using System;
using System.Collections.Generic;

namespace AssetManagement.Models;

public partial class Asset
{
    public string AssetId { get; set; } = null!;

    public string AssetName { get; set; } = null!;

    public string ModelNo { get; set; } = null!;

    public string SerialNo { get; set; } = null!;

    public string MakeCompany { get; set; } = null!;

    public int Value { get; set; }

    public string Status { get; set; } = null!;
}
