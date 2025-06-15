using QueryableIEnumerableAPI.Model;

namespace QueryableIEnumerableAPI.Constract;

public interface IEmployeeService
{
    Task< EmployeeResponseDTO> CreateEmployee(CreateRequsetEmployeeDTO employee);
    Task<List<Employee>> GetHighPaidEmployeesUsingIEnumerable(double salaryThreshold);
     Task<List<Employee>> GetEmployeesUsingIQueryable();
     Task<List<Employee>> GetEmployeesUsingIEnumerable();
    
    Task<List<Employee>> GetHighPaidEmployeesUsingIQueryable(double salaryThreshold);
    
    Task<List<Employee>> SearchEmployeesByNameUsingIEnumerable(string searchTerm);
    Task<List<Employee>> SearchEmployeesByNameUsingIQueryable(string searchTerm);
}