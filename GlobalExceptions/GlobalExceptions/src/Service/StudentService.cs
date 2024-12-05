using AutoMapper;
using GlobalExceptions.src.Context;
using GlobalExceptions.src.Contracts;
using GlobalExceptions.src.Modles;
using Microsoft.EntityFrameworkCore;

namespace GlobalExceptions.src.Service
{
    /// <summary>
    /// Service class for managing student operations.
    /// </summary>
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly StudentDbContext _context;
        private readonly ILogger<StudentService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentService"/> class.
        /// </summary>
        /// <param name="mapper">The mapper instance for object mapping.</param>
        /// <param name="context">The database context for student operations.</param>
        /// <param name="logger">The logger instance for logging operations.</param>
        public StudentService(IMapper mapper, StudentDbContext context, ILogger<StudentService> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Creates a new student.
        /// </summary>
        /// <param name="createStudent">The student creation data.</param>
        /// <returns>The created student data transfer object.</returns>
        public async Task<StudentDto> CreateStudent(CreateStudent createStudent)
        {
            var student = _mapper.Map<Student>(createStudent);
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

            return _mapper.Map<StudentDto>(student);
        }

        /// <summary>
        /// Gets a student by ID.
        /// </summary>
        /// <param name="id">The student ID.</param>
        /// <returns>The student data transfer object.</returns>
        /// <exception cref="Exception">Thrown when the student is not found.</exception>
        public async Task<StudentDto> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                _logger.LogError($"Student with id: {id} not found");
                throw new Exception($"Student with id: {id} not found");
            }

            _logger.LogInformation($"Student with id: {id} found");
            return _mapper.Map<StudentDto>(student);
        }

        /// <summary>
        /// Gets all students.
        /// </summary>
        /// <returns>A collection of student data transfer objects.</returns>
        public async Task<IEnumerable<StudentDto>> GetStudents()
        {
            var students = await _context.Students.ToListAsync();

            if (students == null || !students.Any())
            {
                _logger.LogError("No students found");
                return Enumerable.Empty<StudentDto>();
            }

            _logger.LogInformation("Students found");
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }

        /// <summary>
        /// Updates an existing student.
        /// </summary>
        /// <param name="updateStudent">The student update data.</param>
        /// <returns>The updated student data transfer object.</returns>
        /// <exception cref="Exception">Thrown when the student is not found.</exception>
        public async Task<StudentDto> UpdateStudent(UpdateStudent updateStudent)
        {
            var student = await _context.Students.FindAsync(updateStudent.Id);
            if (student == null)
            {
                _logger.LogError($"Student with id: {updateStudent.Id} not found");
                throw new Exception($"Student with id: {updateStudent.Id} not found");
            }
            student.Name = updateStudent.Name;
            student.Biography = updateStudent.Biography;
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return _mapper.Map<StudentDto>(student);
        }

        /// <summary>
        /// Deletes a student by ID.
        /// </summary>
        /// <param name="id">The student ID.</param>
        /// <returns>The deleted student data transfer object.</returns>
        /// <exception cref="Exception">Thrown when the student is not found.</exception>
        public async Task<StudentDto> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                _logger.LogError($"Student with id: {id} not found");
                throw new Exception($"Student with id: {id} not found");
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return _mapper.Map<StudentDto>(student);
        }
    }
}
