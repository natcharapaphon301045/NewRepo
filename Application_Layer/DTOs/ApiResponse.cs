namespace Week5.Application_Layer.DTOs
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }

        // ✅ Constructor หลัก
        public ApiResponse(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        // ✅ Constructor ที่รับ `data` เพียงตัวเดียว
        public ApiResponse(T data)
        {
            Success = true;
            Message = "Success";
            Data = data;
        }

        // ✅ Constructor ที่รับ `message` เพียงตัวเดียว
        public ApiResponse(string message)
        {
            Success = false;
            Message = message;
            Data = default(T)!;
        }
    }
}
