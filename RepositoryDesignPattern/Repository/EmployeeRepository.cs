using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.Entities;
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
            try
            {
                employees = _context.Employee.Select(x => new EmployeeViewModel() { EmployeeID = x.EmployeeID, Name = x.Name, Gender = x.Gender, Salary = x.Salary, Dept = x.Dept }).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception("db not connected");
            }
            return employees;

        }
        [HttpGet]
        public List<EmployeeViewModel> UpdateEmployee(int eid)
        {
            List<EmployeeViewModel> employe = new();
            try
            {
                employe = _context.Employee.Where(x => x.EmployeeID == eid).Select(x => new EmployeeViewModel() { EmployeeID = x.EmployeeID, Name = x.Name, Gender = x.Gender, Salary = x.Salary, Dept = x.Dept }).ToList();
            }
            catch (Exception ex) { 
            }
            return employe;

        }
        [HttpPost]
        public List<EmployeeViewModel> UpdateEmployee(EmployeeViewModel emp)
        {
            if (emp is null)
            {
                throw new ArgumentNullException(nameof(emp));
            }

            List<EmployeeViewModel> employe = new();
            Employee employee = new()
            {
                EmployeeID = emp.EmployeeID,
                Name = emp.Name,
                Gender = emp.Gender,
                Salary = emp.Salary,
                Dept = emp.Dept,
            };

            try
            {
                _context.UpdateRange(employee);
                _context.SaveChanges();
               
            }
            catch(Exception ex) { }
            
            return employe.ToList();
        }
        public List<EmployeeViewModel> CreateEmp(EmployeeViewModel emp)
        {
            List<EmployeeViewModel> employe = new();
            
            try
            {
                Employee employee = new()
                {
                    EmployeeID = emp.EmployeeID,
                    Name = emp.Name,
                    Gender = emp.Gender,
                    Salary = emp.Salary,
                    Dept = emp.Dept,
                };
                _context.Add(employee);

                _context.SaveChanges();
            }
            catch (Exception ex) { }
            return employe.ToList();
        }

    

          public EmployeeViewModel DeleteData(int EmployeeID)
          {
            EmployeeViewModel employee = new();
            Employee er = _context.Employee.FirstOrDefault(x=>x.EmployeeID==EmployeeID);
            try
            {
                _context.Employee.Remove(er);
                _context.SaveChanges();
            }
            catch { }
            return employee;
        }



    }
}
    
