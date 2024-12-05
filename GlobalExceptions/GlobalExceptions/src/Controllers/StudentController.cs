using GlobalExceptions.src.Contracts;
using GlobalExceptions.src.Service;
using Microsoft.AspNetCore.Mvc;

namespace GlobalExceptions.src.Controllers
{
    /// <summary>
    /// Controller for managing student-related operations.
    /// </summary>
    [ApiController]
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
        /// Gets the list of all students.
        /// </summary>
        /// <returns>A list of students.</returns>
        [HttpGet("api/students")]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentService.GetStudents();
            return Ok(students);
        }

        /// <summary>
        /// Gets a student by the specified identifier.
        /// </summary>
        /// <param name="id">The student identifier.</param>
        /// <returns>The student with the specified identifier.</returns>
        [HttpGet("api/students/{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {

            var student = await _studentService.GetStudent(id);

            if (student == null)
            {
                throw new Exception($"Student with id: {id} not found");


            }
            return Ok(student);
        }

        /// <summary>
        /// Creates a new student.
        /// </summary>
        /// <param name="createStudent">The student creation details.</param>
        /// <returns>The created student.</returns>
        [HttpPost("api/students")]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudent createStudent)
        {
            var student = await _studentService.CreateStudent(createStudent);
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        /// <summary>
        /// Updates an existing student.
        /// </summary>
        /// <param name="id">The student identifier.</param>
        /// <param name="updateStudent">The student update details.</param>
        /// <returns>The updated student.</returns>
        [HttpPut("api/students/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] UpdateStudent updateStudent)
        {
            if (id != updateStudent.Id)
            {
                throw new Exception("The student ID in the URL does not match the student ID in the request body.");
            }
            var student = await _studentService.UpdateStudent(updateStudent);
            return Ok(student);
        }

        /// <summary>
        /// Deletes a student by the specified identifier.
        /// </summary>
        /// <param name="id">The student identifier.</param>
        /// <returns>The deleted student.</returns>
        [HttpDelete("api/students/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _studentService.DeleteStudent(id);
            return Ok(student);
        }
    }
}
