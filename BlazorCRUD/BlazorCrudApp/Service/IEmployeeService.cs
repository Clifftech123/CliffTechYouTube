using BlazorCrudApp.Domain;

namespace BlazorCrudApp.Service
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDetailsDto>> GetAllEmployeesAsync();
        Task<EmployeeDetailsDto> GetEmployeeByIdAsync(Guid id);
        Task CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto);
        Task UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto);
        Task DeleteEmployeeAsync(Guid id);
    }
}
