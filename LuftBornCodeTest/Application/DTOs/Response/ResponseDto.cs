namespace Application.DTOs.Response
{
    public class ResponseDto<T> : DefaultResponse
    {
        public T? Data { get; set; }
        public int Count { get; set; }

        public ResponseDto(T result, string message, int count, bool status = true)
        {
            Message = message;
            Status = status;
            Data = result;
            Count = count;
        }
        public static ResponseDto<T> SuccessResponse(T result, int count = 0, string message = "Success") => new(result, message, count);
        public static ResponseDto<T> ErrorResponse(T result, int count = 0, string message = "An Error Has Occurred") => new(result, message, count, false);

    }
}
