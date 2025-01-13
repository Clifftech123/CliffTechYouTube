using ScalarOpenApi.Domain.Contract;

namespace ScalarOpenApi.Services
{
    public interface IStudent
    {
        Task<ApiResponse<IEnumerable<StudentRespond>>> GetStudents();
        Task<ApiResponse<StudentRespond>> GetStudentById(Guid id);
        Task<ApiResponse<StudentRespond>> CreateStudent(CreateStudent createStudent);
        Task<ApiResponse<StudentRespond>> UpdateStudent(UpdateStudent updateStudent);
        Task<ApiResponse<StudentRespond>> DeleteStudent(Guid id);
    }
}
