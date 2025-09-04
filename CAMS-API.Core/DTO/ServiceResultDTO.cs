namespace CAMS_API.Models.DTO
{
    public class ServiceResultDTO<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public static ServiceResultDTO<T> Ok(string message,T data) =>
            new()
            {
                Success = true,
                Message = message,
                Data = data
            };

        public static ServiceResultDTO<T> Fail(string message) =>
            new()
            {
                Success = false,
                Message = message
            };

        public static ServiceResultDTO<T> Fail(string message, T data) =>
            new()
            {
                Success = false,
                Message = message,
                Data = data
            };
    }
}
