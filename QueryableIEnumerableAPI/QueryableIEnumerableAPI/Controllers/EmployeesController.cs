using Microsoft.AspNetCore.Mvc;
using QueryableIEnumerableAPI.Constract;

namespace QueryableIEnumerableAPI.Controllers;


    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRequsetEmployeeDTO employee)
        {
            var result = await _employeeService.CreateEmployee(employee);
            return Ok(result);
        }

        [HttpGet("enumerable")]
        public async Task<IActionResult> GetAllEnumerable()
        {
            var result = await _employeeService.GetEmployeesUsingIEnumerable();
            return Ok(result);
        }

        [HttpGet("queryable")]
        public async Task<IActionResult> GetAllQueryable()
        {
            var result = await _employeeService.GetEmployeesUsingIQueryable();
            return Ok(result);
        }

        [HttpGet("enumerable/high-paid/{threshold}")]
        public async Task<IActionResult> GetHighPaidEnumerable(double threshold)
        {
            var result = await _employeeService.GetHighPaidEmployeesUsingIEnumerable(threshold);
            return Ok(result);
        }

        [HttpGet("queryable/high-paid/{threshold}")]
        public async Task<IActionResult> GetHighPaidQueryable(double threshold)
        {
            var result = await _employeeService.GetHighPaidEmployeesUsingIQueryable(threshold);
            return Ok(result);
        }

        [HttpGet("enumerable/search/{name}")]
        public async Task<IActionResult> SearchEnumerable(string name)
        {
            var result = await _employeeService.SearchEmployeesByNameUsingIEnumerable(name);
            return Ok(result);
        }

        [HttpGet("queryable/search/{name}")]
        public async Task<IActionResult> SearchQueryable(string name)
        {
            var result = await _employeeService.SearchEmployeesByNameUsingIQueryable(name);
            return Ok(result);
        }

    }
