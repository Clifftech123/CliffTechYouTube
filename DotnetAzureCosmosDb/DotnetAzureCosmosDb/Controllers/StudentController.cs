using DotnetAzureCosmosDb.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAzureCosmosDb.Controllers
{
    /// <summary>
    /// Controller for managing student entities.
    /// </summary>
    [ApiController]
    [Route("api/")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentController"/> class.
        /// </summary>
        /// <param name="studentService">The student service.</param>
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// Adds a new student asynchronously.
        /// </summary>
        /// <param name="student">The student to add.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
        [HttpPost("student")]
        public async Task<IActionResult> AddStudentAsync([FromBody] CreateStudentDto student)
        {
            var response = await _studentService.AddStudentAsync(student);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        /// <summary>
        /// Gets all students asynchronously.
        /// </summary>
        /// <returns>An <see cref="IActionResult"/> containing the list of students.</returns>
        [HttpGet("students")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync("SELECT * FROM c");
            return Ok(students);
        }

        /// <summary>
        /// Gets a student by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the student.</param>
        /// <returns>An <see cref="IActionResult"/> containing the student.</returns>
        [HttpGet("student/{id}")]
        public async Task<IActionResult> GetStudentByIdAsync(string id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            return Ok(student);
        }

        /// <summary>
        /// Updates a student asynchronously.
        /// </summary>
        /// <param name="id">The ID of the student to update.</param>
        /// <param name="student">The updated student data.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
        [HttpPut("student")]
        public async Task<IActionResult> UpdateStudentAsync(string id, [FromBody] UpdateStudentDto student)
        {
            var response = await _studentService.UpdateStudentAsync(id, student);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        /// <summary>
        /// Deletes a student asynchronously.
        /// </summary>
        /// <param name="id">The ID of the student to delete.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
        [HttpDelete("student/{id}")]
        public async Task<IActionResult> DeleteStudentAsync(string id)
        {
            var response = await _studentService.DeleteStudentAsync(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
