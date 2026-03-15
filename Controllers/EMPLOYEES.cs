using Git_MVC_PRO.Models;
using Git_MVC_PRO.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Git_MVC_PRO.Controllers
{
    public class EMPLOYEES : Controller
    {
        private readonly IEmployeesService _Emp;

        public EMPLOYEES(IEmployeesService employees)
        {
            _Emp = employees;

        }
        public async Task<IActionResult> Index()
        {
            var employees = await _Emp.GetAll();
          
            return View(employees);
        }


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

            ViewBag.Departments = new SelectList(departments, "DepartmentsId", "Name", employees.DepartmentsId,employees.name);

            return View(employees);
        }



    }
}