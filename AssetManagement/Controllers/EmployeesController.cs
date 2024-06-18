namespace AssetManagement.Controllers;

using AssetManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
 // Assuming your models are in the AssetManagement.Models namespace
using System.Threading.Tasks;

    public class EmployeesController : Controller
    {
        public AssetProjectContext AssetprojContext { get; }

        public EmployeesController(AssetProjectContext assetprojContext)
        {
            AssetprojContext = assetprojContext;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await AssetprojContext.Employees.ToListAsync();
            return View(employees);
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

        [HttpGet]
        public async Task<IActionResult> View(string EmployeeId)
        {
            var employee = await AssetprojContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == EmployeeId);

            if (employee != null)
            {
                var viewModel = new UpdateEmployeeViewModel()
                {
                    EmployeeId = employee.EmployeeId,
                    EmployeeName = employee.EmployeeName,
                    PhoneNo = employee.PhoneNo,
                    Email = employee.Email,
                    Address = employee.Address,
                    Dob = employee.Dob,
                    Department = employee.Department,
                    Salary = employee.Salary
                };
                return await Task.Run(() => View("View", viewModel));
            }



            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateEmployeeViewModel model)
        {
            // Retrieve the employee from the database
            var employee = await AssetprojContext.Employees.FindAsync(model.EmployeeId);

            if (employee != null)
            {
                // Update employee properties
                employee.EmployeeName = model.EmployeeName;
                employee.PhoneNo = model.PhoneNo;
                employee.Email = model.Email;
                employee.Address = model.Address;
                employee.Dob = model.Dob;
                employee.Department = model.Department;
                employee.Salary = model.Salary;

                // Mark the entity as modified
                AssetprojContext.Entry(employee).State = EntityState.Modified;

                // Save changes to the database
                await AssetprojContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployeeViewModel model)
        {
            var employee = await AssetprojContext.Employees.FindAsync(model.EmployeeId);

            if (employee != null)
            {
                AssetprojContext.Employees.Remove(employee);
                await AssetprojContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
    }
