using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.Entities;
using System.Data.Sql;


namespace RepositoryDesignPattern.Models
{
    public class EmployeeDBContext: DbContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base(options) { }
        public DbSet<Employee>? Employee { get; set; }
    
    }

}
