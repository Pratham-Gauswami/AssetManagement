using AssetManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers
{
    public class EmployeesController : Controller
    {
        public AssetProjectContext AssetprojContext { get; }

        public EmployeesController(AssetProjectContext assetprojContext)
        {
            AssetprojContext = assetprojContext;
        }


        [HttpGet]
        public IActionResult AddEmp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmp(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            { 
                EmployeeId = addEmployeeRequest.EmployeeId,
                EmployeeName = addEmployeeRequest.EmployeeName,
                PhoneNo = addEmployeeRequest.PhoneNo,
                Email = addEmployeeRequest.Email,
                Address = addEmployeeRequest.Address,
                Dob = addEmployeeRequest.Dob,
                Department = addEmployeeRequest.Department,
                Salary = addEmployeeRequest.Salary

            };

            await AssetprojContext.Employees.AddAsync(employee);
            await AssetprojContext.SaveChangesAsync();
            return RedirectToAction("AddEmp");

        }
        


    }
}
