using Application.Configuration;
using Application.DTOs.Response;
using Newtonsoft.Json;

namespace LuftBornCodeTest.Extensions.ExceptionFilter
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            DefaultResponse errorResponse;
            int statusCode;
            string message;

            if (exception is NotFoundException)
            {
                statusCode = StatusCodes.Status404NotFound;
                message = exception.Message;
            }
            else if (exception is ForbiddenException)
            {
                statusCode = StatusCodes.Status403Forbidden;
                message = exception.Message;
            }
            else if (exception is BadRequestException)
            {
                statusCode = StatusCodes.Status400BadRequest;
                message = exception.Message;
            }
            else
            {
                statusCode = StatusCodes.Status500InternalServerError;
                message = "An error occurred while processing your request.";
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var response = new { error = message };
            errorResponse = DefaultResponse.ErrorResponse(message);

            return context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
        }
    }
}