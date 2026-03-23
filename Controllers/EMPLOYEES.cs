using Git_MVC_PRO.Models;
using Git_MVC_PRO.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Git_MVC_PRO.Controllers
{
    [Authorize]
    public class EMPLOYEES : Controller
    {
        private readonly IEmployeesService _Emp;
        private readonly ILogger<EMPLOYEES> _Logging;

        public EMPLOYEES(IEmployeesService employees,ILogger<EMPLOYEES> logger)
        {
            _Emp = employees;
            _Logging = logger;

        }

        //nilesh
        //public async Task<IActionResult> Index()
        //{
        //    var employees = await _Emp.GetAll();

        //    return View(employees);





        public async Task<IActionResult> Index(string searchString)
        {
            var departments = await _Emp.GetAll();


            if (!string.IsNullOrEmpty(searchString))
            {
                departments = departments
                    .Where(d => d.departments != null && d.departments.Name.ToLower().Contains(searchString.ToLower()) ||
                    (d.name != null && d.name.ToLower().Contains(searchString)) ||
                     (d.lastname != null && d.lastname.ToLower().Contains(searchString)))
                    .ToList();
            }


            ViewBag.SearchString = searchString;
            _Logging.LogInformation("User all Data show "+searchString);
            return View(departments);
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var departments = await _Emp.GetDepartment();

            if (departments == null)
                departments = new List<Departments>();

            ViewBag.Departments = new SelectList(departments, "DepartmentsId", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employees employees)
        {
            if (!ModelState.IsValid)
            {
                await _Emp.Post(employees);

                TempData["message"] = "Employee created successfully";

                return RedirectToAction("Index");
            }


            var departments = await _Emp.GetDepartment();

            if (departments == null)
                departments = new List<Departments>();

            ViewBag.Departments = new SelectList(departments, "DepartmentsId", "Name", employees.DepartmentsId, employees.name);

            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _Emp.GetByID(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> Deletes(int id)
        {
            var data = await _Emp.Delete(id);
            if (data == null)
            {
                return RedirectToAction("Index");

            }
            TempData["message"] = "Delete data Successfully";
            _Logging.LogInformation("current data"+ DateTime.Now.ToLocalTime());
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _Emp.GetByID(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employees employees)
        {
            var data = await _Emp.Edit(employees);
            TempData["message"] = "Employees Update Successfully";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var data = await _Emp.GetByID(id);
            return View(data);
        }
         


    }
}