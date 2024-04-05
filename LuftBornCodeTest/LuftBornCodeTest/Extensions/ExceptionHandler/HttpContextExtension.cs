using Application.DTOs.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LuftBornCodeTest.Extensions.ExceptionFilter
{
    public static class HttpContextExtension
    {
        public static BadRequestObjectResult HandleInvalidRequest(this ActionContext context)
        {
            var message = context
                            .ModelState
                            .Where(e => e.Value?.ValidationState == ModelValidationState.Invalid)
                            .FirstOrDefault()
                            .Value
                            ?.Errors
                            .Select(x => x.ErrorMessage)
                            .FirstOrDefault();

            return new BadRequestObjectResult(DefaultResponse.ErrorResponse(message ?? "validation error occurred"));
        }
    }
}
