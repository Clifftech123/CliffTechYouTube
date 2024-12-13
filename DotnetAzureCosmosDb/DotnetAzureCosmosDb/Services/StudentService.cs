using DotnetAzureCosmosDb.Contracts;
using DotnetAzureCosmosDb.Models;
using Microsoft.Azure.Cosmos;
using System.Net;

namespace DotnetAzureCosmosDb.Services
{
    /// <summary>
    /// Service for managing student entities in Azure Cosmos DB.
    /// </summary>
    public class StudentService : IStudentService
    {
        private readonly Container _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentService"/> class.
        /// </summary>
        /// <param name="cosmosClient">The Cosmos client.</param>
        /// <param name="databaseName">The name of the database.</param>
        /// <param name="containerName">The name of the container.</param>
        public StudentService(CosmosClient cosmosClient, string databaseName, string containerName)
        {
            _container = cosmosClient.GetContainer(databaseName, containerName);
        }

        /// <summary>
        /// Adds a new student asynchronously.
        /// </summary>
        /// <param name="student">The student to add.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the result of the operation.</returns>
        public async Task<ApiResponse> AddStudentAsync(CreateStudentDto student)
        {
            var studentEntity = new Student
            {
                Id = Guid.NewGuid().ToString(),
                Name = student.Name,
                Email = student.Email,
                Age = student.Age,
            };

            var response = await _container.CreateItemAsync(studentEntity, new PartitionKey(studentEntity.Id));

            return new ApiResponse
            {
                IsSuccess = response.Equals(HttpStatusCode.NoContent),
                Message = response.StatusCode.ToString(),
                Result = studentEntity
            };
        }

        /// <summary>
        /// Gets all students asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the list of students.</returns>
        public async Task<ApiResponse> GetAllStudentsAsync(string query)
        {
            var queryIterator = _container.GetItemQueryIterator<Student>(new QueryDefinition(query));
            var students = new List<Student>();
            while (queryIterator.HasMoreResults)
            {
                var response = await queryIterator.ReadNextAsync();
                students.AddRange(response.Resource);
            }
            return new ApiResponse
            {
                IsSuccess = true,
                Message = "Students fetched successfully",
                Result = students
            };
        }

        /// <summary>
        /// Gets a student by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the student.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the student.</returns>
        public async Task<ApiResponse> GetStudentByIdAsync(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<Student>(id, new PartitionKey(id));
                return new ApiResponse
                {
                    IsSuccess = true,
                    Message = "Student fetched successfully",
                    Result = response.Resource
                };
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Result = null
                };
            }
        }

        /// <summary>
        /// Updates a student asynchronously.
        /// </summary>
        /// <param name="id">The ID of the student to update.</param>
        /// <param name="student">The updated student data.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the result of the operation.</returns>
        public async Task<ApiResponse> UpdateStudentAsync(string id, UpdateStudentDto student)
        {
            try
            {
                var patchOperations = new List<PatchOperation>();

                if (!string.IsNullOrWhiteSpace(student.Name))
                {
                    patchOperations.Add(PatchOperation.Replace("/name", student.Name.Trim()));
                }

                if (!string.IsNullOrWhiteSpace(student.Email))
                {
                    patchOperations.Add(PatchOperation.Replace("/email", student.Email.Trim()));
                }

                if (student.Age != 0)
                {
                    patchOperations.Add(PatchOperation.Replace("/age", student.Age));
                }

                var response = await _container.PatchItemAsync<Student>(id, new PartitionKey(id), patchOperations);

                return new ApiResponse
                {
                    IsSuccess = response.Equals(HttpStatusCode.NoContent),
                    Message = response.StatusCode.ToString(),
                    Result = response.Resource
                };
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Result = null
                };
            }
        }

        /// <summary>
        /// Deletes a student asynchronously.
        /// </summary>
        /// <param name="id">The ID of the student to delete.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the result of the operation.</returns>
        public async Task<ApiResponse> DeleteStudentAsync(string id)
        {
            try
            {
                var response = await _container.DeleteItemAsync<Student>(id, new PartitionKey(id));
                return new ApiResponse
                {
                    IsSuccess = response.Equals(HttpStatusCode.NoContent),
                    Message = response.StatusCode.ToString(),
                    Result = null
                };
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Result = null
                };
            }
        }
    }
}
