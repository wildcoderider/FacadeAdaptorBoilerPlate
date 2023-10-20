namespace TurismoApi.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public ErrorResponse? Error { get; set; }
    }

    public class ErrorResponse
    {
        public int ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
}

