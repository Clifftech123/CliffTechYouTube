using Microsoft.EntityFrameworkCore;
using QueryableIEnumerableAPI.Constract;
using QueryableIEnumerableAPI.Data;
using QueryableIEnumerableAPI.Model;

namespace QueryableIEnumerableAPI.Service;

public class EmployeeService : IEmployeeService
{
    private readonly AppDbContext _appDbContext;

    public EmployeeService (AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<EmployeeResponseDTO> CreateEmployee(CreateRequsetEmployeeDTO employee)
    {
        var createEmloyee = new Employee
        {
            Id = Guid.NewGuid(),
            Name = employee.Name,
            Email = employee.Email,
            Salary = employee.Salary
        };
        await _appDbContext.Employees.AddAsync(createEmloyee);
        await  _appDbContext.SaveChangesAsync();

        return new EmployeeResponseDTO
        {
            Id = createEmloyee.Id,
            Name = createEmloyee.Name,
            Email = createEmloyee.Email,
            Salary = createEmloyee.Salary,
        };
    }

    public async Task<List<Employee>> GetEmployeesUsingIEnumerable()
    {
      var employees = await _appDbContext.Employees.ToListAsync();
      return employees.AsEnumerable().ToList();
    }

    public async Task<List<Employee>> GetEmployeesUsingIQueryable()
    {
        return await _appDbContext.Employees.AsQueryable().ToListAsync();
    }

    public async Task<List<Employee>> GetHighPaidEmployeesUsingIEnumerable(double salaryThreshold)
    {
        
        //IEnumerable approach - filters in memory 
      var allEmployees = await _appDbContext.Employees.ToListAsync();
      return  allEmployees.AsEnumerable()
          .Where(e=>e.Salary > salaryThreshold)
          .OrderByDescending(e => e.Salary)
          .ToList();
    }

    public async Task<List<Employee>> GetHighPaidEmployeesUsingIQueryable(double salaryThreshold)
    {
        // IQueryable approach - translates to SQL
        return await _appDbContext.Employees
            .AsQueryable()
            .Where(e => e.Salary > salaryThreshold)
            .OrderByDescending(e => e.Salary)
            .ToListAsync();
        
    }

    public async  Task<List<Employee>> SearchEmployeesByNameUsingIEnumerable(string searchTerm)
    {
        // IQueryable approach - translates to SQL
        var allEmployees = await _appDbContext.Employees.ToListAsync();
        return allEmployees.AsEnumerable()
            .Where(e => e.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            .OrderBy(e=>e.Name)
            .ToList();
        
        
    }

    public async Task<List<Employee>> SearchEmployeesByNameUsingIQueryable(string searchTerm)
    {
        return await _appDbContext.Employees
            .AsQueryable()
            .Where(e => EF.Functions.Like(e.Name, $"%{searchTerm}%"))
            .OrderBy(e => e.Name)
            .ToListAsync();
    }
    }
