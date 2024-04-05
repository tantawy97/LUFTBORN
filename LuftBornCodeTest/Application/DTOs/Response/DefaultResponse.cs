using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response
{
    public class DefaultResponse
    {
        public string Message { get; set; } = string.Empty;
        public bool Status { get; set; } = true;

        public static DefaultResponse ErrorResponse(string message = "An Error Has Occurred") => new() { Message = message, Status = false };
        public static DefaultResponse SuccessResponse(string message = "Success") => new() { Message = message };
    }
}
