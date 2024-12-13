namespace DotnetAzureCosmosDb.Contracts
{
    public interface IStudentService
    {
        Task<ApiResponse> AddStudentAsync(CreateStudentDto student);
        Task<ApiResponse> GetStudentByIdAsync(string id);
        Task<ApiResponse> GetAllStudentsAsync(string qurey);
        Task<ApiResponse> UpdateStudentAsync(string id, UpdateStudentDto student);
        Task<ApiResponse> DeleteStudentAsync(string id);
    }
}
