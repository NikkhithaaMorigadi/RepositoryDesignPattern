using RepositoryDesignPattern.Models;

namespace RepositoryDesignPattern.Repository
{
    public interface IEmpRepository
    {
        List<EmployeeViewModel> GetAllEmployees();
       /* void InsertEmployee(EmployeeRepository employee);
        void DeleteEmployee(int EmployeeID);*/
        List<EmployeeViewModel> UpdateEmployee(int EmployeeID);

        /*EmployeeViewModel GetById(int EmployeeID);


        EmployeeViewModel InsertData(EmployeeViewModel employee);
        EmployeeViewModel UpdateData(EmployeeViewModel employee);
        
       EmployeeViewModel DeleteData(int EmployeeID);*/

    }
}
/*IEnumerable<Book> GetBooks();
Book GetBookByID(int bookId);
void InsertBook(Book book);
void DeleteBook(int bookID);
void UpdateBook(Book book);
void Save();*/