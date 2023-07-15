using Microsoft.EntityFrameworkCore;

namespace RepositoryDesignPattern.Models
{
    public class EmployeeDbContext
    {
        private DbContextOptions<EmployeeDBContext> options;

        public EmployeeDbContext(DbContextOptions<EmployeeDBContext> options)
        {
            this.options = options;
        }
    }
}