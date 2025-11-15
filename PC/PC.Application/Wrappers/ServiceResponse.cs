using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.Application.Wrappers
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public int StatusCode { get; set; } = 200;
        public List<string>? Errors { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public ServiceResponse(T data, int statusCode = 200)
        {
            Data = data;
            Success = true;
            StatusCode = statusCode;
        }

        public ServiceResponse(List<string>? errors = null, int statusCode = 400)
        {
            Success = false;
            StatusCode = statusCode;
            Errors = errors ?? new List<string>();
        }

        public ServiceResponse()
        {
            Success = true;
            StatusCode = 200;
        }
    }
}
