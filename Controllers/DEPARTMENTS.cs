using Git_MVC_PRO.Models;
using Git_MVC_PRO.Service;
using Microsoft.AspNetCore.Mvc;

namespace Git_MVC_PRO.Controllers
{
    public class DEPARTMENTS : Controller
    {
        private readonly IDepartService _service;

        public DEPARTMENTS(IDepartService service) 
        
        { 
         _service=service;
        
        }
        public  async Task<IActionResult> Index()
        {
            var data = await _service.GetDepartmentsService();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            var data = await _service.GetBYId(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Departments departments)
        {
            var data = await _service.AddDepartmentsService(departments);
            TempData["message"] = "Create data Successfully";
            return RedirectToAction("Index");
            
            
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _service.GetBYId(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Departments departments)
        {
            var data = await _service.UpdateDepartmentsService(departments);
            TempData["message"] = "Update data Successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetBYId(id);
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _service.GetBYId(id);
            return View(data);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> Deletes(int Id)
        {
            
            var data = await _service.DeleteDepartmentsService(Id);
            if(data==null)
            {
                return RedirectToAction("Index","Departments Not Found");

            }
            TempData["message"] = "Delete data Successfully";
            return RedirectToAction("Index");

        }
    }
}
