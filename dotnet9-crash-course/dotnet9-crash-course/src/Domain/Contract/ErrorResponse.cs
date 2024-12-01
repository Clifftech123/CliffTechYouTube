namespace dotnet9_crash_course.src.Domain.Contract
{
    public class ErrorResponse
    {
        public string Title { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }

    }
}
