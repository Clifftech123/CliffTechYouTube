using dotnet9_crash_course.src.Domain.Contract;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace dotnet9_crash_course.src.Infrastructure.Exceptions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, exception.Message);


            var errorResponse = new ErrorResponse
            {
                Message = exception.Message,
                StatusCode = exception is BadHttpRequestException ? (int)HttpStatusCode.BadRequest : (int)HttpStatusCode.InternalServerError,
                Title = exception is BadHttpRequestException ? exception.GetType().Name : "An error occurred"
            };

            httpContext.Response.StatusCode = errorResponse.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);

            return true;


        }
    }
}
