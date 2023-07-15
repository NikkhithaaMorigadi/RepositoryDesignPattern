using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using RepositoryDesignPattern.Models;

namespace RepositoryDesignPattern.Repository
{
    public class EmployeeRepository : IEmpRepository
    {
        private readonly EmployeeDBContext _context;

        public EmployeeRepository(EmployeeDBContext context)
        {
            _context = context;
        }
        public List<EmployeeViewModel> GetAllEmployees()
        {
            List<EmployeeViewModel> employees = new();

            employees = _context.Employee.Select(x => new EmployeeViewModel() { EmployeeID = x.EmployeeID, Name = x.Name, Gender = x.Gender, Salary = x.Salary, Dept = x.Dept }).ToList();

            return employees;

        }
        public List<EmployeeViewModel> UpdateEmployee(int id)
        {
            List<EmployeeViewModel> employe = new();
            try
            {
               employe = _context.Employee.Where(x => x.EmployeeID == id).Select(x => new EmployeeViewModel() { EmployeeID = x.EmployeeID, Name = x.Name, Gender = x.Gender, Salary = x.Salary, Dept = x.Dept }).ToList();
            }
            catch (Exception ex) { }
            return employe;

        }
        [HttpPost]
        public List<EmployeeViewModel> UpdateEmployee(EmployeeViewModel employe)
        {
            //update student in DB using EntityFramework in real-life application

            //update list by removing old student and adding updated student for demo purpose
            var employee = _context.Employee.Where(s => s.EmployeeID == employe.EmployeeID).FirstOrDefault();
            _context.Employee.Remove(employe);
            _context.Employee.Add(employee);

            return RedirectToAction("Index");
        }
    }
    /*   
     [HttpGet]
     public ActionResult Edit(int id)
     {
         var data = _context.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
         return View(data);
     }
     [HttpPost]
     public ActionResult Edit(Employee Model)
     {
         var data = _context.Employees.Where(x => x.EmployeeId == Model.EmployeeId).FirstOrDefault();
         if (data != null)
         {
             data.EmployeeCity = Model.EmployeeCity;
             data.EmployeeName = Model.EmployeeName;
             data.EmployeeSalary = Model.EmployeeSalary;
             _context.SaveChanges();
         }

         return RedirectToAction("index");
     }
     public List<EmployeeViewModel> UpdateData(int EmpID)
         {
            *//* List<EmployeeViewModel> employeeViewModel = new ();
             employeeViewModel = _context.Employee.FirstOrDefault(x => x.EmployeeID == EmployeeID).Select(x => new EmployeeViewModel() { });
                 return employeeViewModel;*//*
             List<EmployeeViewModel> options = new();
            var employees = _context.Employee.FirstOrDefault(e => e.EmployeeID == EmpID);
             var
             return options;
         }
    *//* public EmployeeViewModel GetById(int EmployeeID)
                  {
                      List<EmployeeViewModel> options = new();
                      options = _context.Employees.Where(x => EmployeeID == x.EmployeeID).Select(x => new EmployeeViewModel() { EmployeeID = x.EmployeeID, Name = x.Name, Gender = x.Gender, Salary = x.Salary, Dept = x.Dept }).ToList();

                      return Json(options);
                  }
                  public EmployeeViewModel InsertData(EmployeeViewModel employee)
                  {
                      _context.Employees.Add(employee);
                      return employee;
                  }
                  public EmployeeViewModel UpdateData(EmployeeViewModel employee)
                  {
                      _context.Entry(employee).State = EntityState.Modified;
                      return employee;
                  }*/
    /*  public EmployeeViewModel DeleteData(int EmployeeID)
      {
          EmployeeViewModel employee = _context.Employees.Find(EmployeeID);
          _context.Employees.Remove(employee);
          return employee;

      }*/



}
    
