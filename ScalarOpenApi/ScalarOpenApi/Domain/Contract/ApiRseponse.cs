namespace ScalarOpenApi.Domain.Contract
{

    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public ApiResponse(T data)
        {
            Data = data;
            IsSuccess = true;
            Message = string.Empty;
        }

        public ApiResponse(string message)
        {
            Data = default;
            IsSuccess = false;
            Message = message;
        }
    }
}
