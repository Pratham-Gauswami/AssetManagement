namespace AssetManagement.Models
{
    public class AddEmployeeViewModel
    {
        public string EmployeeId { get; set; } = null!;

        public string EmployeeName { get; set; } = null!;

        public string PhoneNo { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Address { get; set; } = null!;

        public DateTime Dob { get; set; }

        public string Department { get; set; } = null!;

        public int Salary { get; set; }
    }
}
