// obiloveapi.Application/DTOs/ApiResponse.cs
using System.Collections.Generic;

namespace obiloveapi.Application.DTOs
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; } = true;
        public T Data { get; set; }
        public Dictionary<string, string[]> Errors { get; set; }
    }
}
