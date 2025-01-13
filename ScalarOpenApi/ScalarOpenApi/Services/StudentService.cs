using Microsoft.EntityFrameworkCore;
using ScalarOpenApi.Data;
using ScalarOpenApi.Domain.Contract;
using ScalarOpenApi.Domain.Models;

namespace ScalarOpenApi.Services
{
    public class StudentService : IStudent
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<StudentRespond>> CreateStudent(CreateStudent createStudent)
        {
            try
            {
                var student = new Student
                {
                    Id = Guid.NewGuid(),
                    Name = createStudent.Name,
                    Email = createStudent.Email,
                    Phone = createStudent.Phone,
                    IndexNumber = createStudent.IndexNumber,
                    CreatedAt = DateTime.UtcNow,
                    LastUpdatedAt = DateTime.UtcNow
                };

                _context.Students.Add(student);
                await _context.SaveChangesAsync();

                var response = new StudentRespond(
                    student.Id,
                    student.Name,
                    student.Email,
                    student.Phone,
                    student.IndexNumber,
                    student.CreatedAt,
                    student.LastUpdatedAt
                );

                return new ApiResponse<StudentRespond>(response)
                {
                    IsSuccess = true,
                    Message = "Student created successfully."
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<StudentRespond>(ex.Message)
                {
                    IsSuccess = false
                };
            }
        }

        public async Task<ApiResponse<StudentRespond>> DeleteStudent(Guid id)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);
                if (student == null)
                {
                    return new ApiResponse<StudentRespond>("Student not found.")
                    {
                        IsSuccess = false
                    };
                }

                _context.Students.Remove(student);
                await _context.SaveChangesAsync();

                return new ApiResponse<StudentRespond>((StudentRespond)null)
                {
                    IsSuccess = true,
                    Message = "Student deleted successfully."
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<StudentRespond>(ex.Message)
                {
                    IsSuccess = false
                };
            }
        }

        public async Task<ApiResponse<StudentRespond>> GetStudentById(Guid id)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);
                if (student == null)
                {
                    return new ApiResponse<StudentRespond>("Student not found.")
                    {
                        IsSuccess = false
                    };
                }

                var response = new StudentRespond(
                    student.Id,
                    student.Name,
                    student.Email,
                    student.Phone,
                    student.IndexNumber,
                    student.CreatedAt,
                    student.LastUpdatedAt
                );

                return new ApiResponse<StudentRespond>(response)
                {
                    IsSuccess = true,
                    Message = "Student retrieved successfully."
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<StudentRespond>(ex.Message)
                {
                    IsSuccess = false
                };
            }
        }

        public async Task<ApiResponse<IEnumerable<StudentRespond>>> GetStudents()
        {
            try
            {
                var students = await _context.Students.ToListAsync();
                var response = students.Select(student => new StudentRespond(
                    student.Id,
                    student.Name,
                    student.Email,
                    student.Phone,
                    student.IndexNumber,
                    student.CreatedAt,
                    student.LastUpdatedAt
                ));

                return new ApiResponse<IEnumerable<StudentRespond>>(response)
                {
                    IsSuccess = true,
                    Message = "Students retrieved successfully."
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<StudentRespond>>(ex.Message)
                {
                    IsSuccess = false
                };
            }
        }

        public async Task<ApiResponse<StudentRespond>> UpdateStudent(UpdateStudent updateStudent)
        {
            try
            {
                var student = await _context.Students.FindAsync(updateStudent.Id);
                if (student == null)
                {
                    return new ApiResponse<StudentRespond>("Student not found.")
                    {
                        IsSuccess = false
                    };
                }

                student.Name = updateStudent.Name;
                student.Email = updateStudent.Email;
                student.Phone = updateStudent.Phone;
                student.IndexNumber = updateStudent.IndexNumber;
                student.LastUpdatedAt = DateTime.UtcNow;

                _context.Students.Update(student);
                await _context.SaveChangesAsync();

                var response = new StudentRespond(
                    student.Id,
                    student.Name,
                    student.Email,
                    student.Phone,
                    student.IndexNumber,
                    student.CreatedAt,
                    student.LastUpdatedAt
                );

                return new ApiResponse<StudentRespond>(response)
                {
                    IsSuccess = true,
                    Message = "Student updated successfully."
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<StudentRespond>(ex.Message)
                {
                    IsSuccess = false
                };
            }
        }
    }
}
