using Microsoft.AspNetCore.Connections;
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
        private readonly EmployeeDBContext _dbContext;
        public HomeController(ILogger<HomeController> logger, IEmpRepository empRepository,EmployeeDBContext dbContext)
        {
            _logger = logger;
            _empRepository = empRepository;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<EmployeeViewModel> model = new List<EmployeeViewModel>();
            try
            {
                var IsEstablish=_dbContext.Database.CanConnect();
                if (IsEstablish)
                {
                    Console.WriteLine("Database connection is established.");
                     model = _empRepository.GetAllEmployees();
                    return View(model);
                }
                else
                {
                    throw new ConnectionAbortedException("Database connection failed");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database connection failed: " + ex.Message);
                return View(model);
            }
         
        }
        public IActionResult Edit(int eid)
        {
            var model = _empRepository.UpdateEmployee(eid);
            return View(model);

        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel emp)
        {
            var model = _empRepository.UpdateEmployee(emp);
            return Json(model) ;
        }
        
        public IActionResult CreateEmp()
        {  
            return View();
        }
        [HttpPost]
        public IActionResult CreateEmp(EmployeeViewModel emp)
        {
            var model=_empRepository.CreateEmp(emp);
            return Json(model);
        }
        [HttpGet]
        public IActionResult Delete(int eid)
        {
            var model = _empRepository.DeleteData(eid);
            return Json(model);
        }

    }
}
