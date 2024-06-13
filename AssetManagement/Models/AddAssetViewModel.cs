namespace AssetManagement.Models
{
    public class AddAssetViewModel
    {
        public string AssetId { get; set; } = null!;

        public string AssetName { get; set; } = null!;

        public string ModelNo { get; set; } = null!;

        public string SerialNo { get; set; } = null!;

        public string MakeCompany { get; set; } = null!;

        public int Value { get; set; }

        public string Status { get; set; } = null!;
    }
}
