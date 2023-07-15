using Microsoft.AspNetCore.Mvc;
using RepositoryDesignPattern.Models;
using RepositoryDesignPattern.Repository;
using System.Diagnostics;

namespace RepositoryDesignPattern.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmpRepository _empRepository;
        private object _context;

        public HomeController(ILogger<HomeController> logger, IEmpRepository empRepository)
        {
            _logger = logger;
            _empRepository = empRepository;
        }

        public IActionResult Index()
        {
            var model = _empRepository.GetAllEmployees();
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var model= _empRepository.UpdateEmployee(id);
            return View(model);
           
        }
/*
        [HttpPost]
        public ActionResult Save(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("AddEmployees", "Employee");
            }

            if (employee.EmployeeId == 0)
                this._dbContext.Employee.Add(employee);

            else
            {
                var employeesDb = this._dbContext.Employee.FirstOrDefault(x => x.EmployeeId == employee.EmployeeId);
                employeesDb.EmployeeName = employee.EmployeeName;
                employeesDb.EmployeeDesignation = employee.EmployeeDesignation;
                employeesDb.EmployeeAddress = employee.EmployeeAddress;
                employeesDb.EmployeePassport = employee.EmployeePassport;
                employeesDb.EmployeePhone = employee.EmployeePhone;
                employeesDb.EmployeeGender = employee.EmployeeGender;
                employeesDb.City = employee.City;
                employeesDb.Project = employee.Project;
                employeesDb.CompanyName = employee.CompanyName;
                employeesDb.PinCode = employee.PinCode;
                employeesDb.DepartmentId = employee.DepartmentId;
            }

            this._dbContext.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        *//*public IActionResult Edit(int id)
        {
            var getemp = _empRepository.GetById();
            return View();
        }*/

    }
}
