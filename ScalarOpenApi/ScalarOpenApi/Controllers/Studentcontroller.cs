using Microsoft.AspNetCore.Mvc;
using ScalarOpenApi.Domain.Contract;
using ScalarOpenApi.Services;

namespace ScalarOpenApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _studentService;

        public StudentController(IStudent studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var result = await _studentService.GetStudents();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(Guid id)
        {
            var result = await _studentService.GetStudentById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudent createStudent)
        {
            var result = await _studentService.CreateStudent(createStudent);
            if (result.IsSuccess)
            {
                return CreatedAtAction(nameof(GetStudentById), new { id = result.Data.Id }, result);
            }
            return BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(Guid id, [FromBody] UpdateStudent updateStudent)
        {
            if (id != updateStudent.Id)
            {
                return BadRequest(new ApiResponse<StudentRespond>("ID mismatch"));
            }

            var result = await _studentService.UpdateStudent(updateStudent);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var result = await _studentService.DeleteStudent(id);
            if (result.IsSuccess)
            {
                return NoContent();
            }
            return NotFound(result);
        }
    }
}
