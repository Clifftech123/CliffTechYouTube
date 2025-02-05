using BlazorCrudApp.Data;
using BlazorCrudApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudApp.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<EmployeeDetailsDto>> GetAllEmployeesAsync()
        {
            return await _appDbContext.Employees
                .Select(e => new EmployeeDetailsDto
                {
                    Id = e.Id,
                    EmployeName = e.EmployeName,
                    Gender = e.Gender,
                    City = e.City,
                    CreatedAt = e.CreatedAt,
                    LastUpdatedAt = e.LastUpdatedAt
                })
                .ToListAsync();
        }

        public async Task<EmployeeDetailsDto> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _appDbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new KeyNotFoundException("Employee not found");
            }

            return new EmployeeDetailsDto
            {
                Id = employee.Id,
                EmployeName = employee.EmployeName,
                Gender = employee.Gender,
                City = employee.City,
                CreatedAt = employee.CreatedAt,
                LastUpdatedAt = employee.LastUpdatedAt
            };
        }

        public async Task CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto)
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                EmployeName = createEmployeeDto.EmployeName,
                Gender = createEmployeeDto.Gender,
                City = createEmployeeDto.City,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow
            };

            _appDbContext.Employees.Add(employee);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = await _appDbContext.Employees.FindAsync(updateEmployeeDto.Id);
            if (employee == null)
            {
                throw new KeyNotFoundException("Employee not found");
            }

            employee.EmployeName = updateEmployeeDto.EmployeName;
            employee.Gender = updateEmployeeDto.Gender;
            employee.City = updateEmployeeDto.City;
            employee.LastUpdatedAt = DateTime.UtcNow;

            _appDbContext.Employees.Update(employee);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(Guid id)
        {
            var employee = await _appDbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new KeyNotFoundException("Employee not found");
            }

            _appDbContext.Employees.Remove(employee);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
