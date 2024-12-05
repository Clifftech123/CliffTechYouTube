using GlobalExceptions.src.Contracts;

namespace GlobalExceptions.src.Service
{
    public interface IStudentService
    {
        public Task<IEnumerable<StudentDto>> GetStudents();
        public Task<StudentDto> GetStudent(int id);
        public Task<StudentDto> CreateStudent(CreateStudent createStudent);
        public Task<StudentDto> UpdateStudent(UpdateStudent updateStudent);
        public Task<StudentDto> DeleteStudent(int id);

    }
}
