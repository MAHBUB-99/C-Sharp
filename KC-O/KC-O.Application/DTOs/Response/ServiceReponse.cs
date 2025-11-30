using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KC_O.Application.DTOs.Response
{
    public class ServiceResponse<T> : ServiceResponse
    {
        public T? Data { get; set; }

        public static ServiceResponse<T?> SuccessResponse(T data, string message)
        {
            return new ServiceResponse<T?>
            {
                Success = true,
                Data = data,
                Message = message
            };
        }

        public static ServiceResponse<T?> FailureResponse(string message)
        {
            return new ServiceResponse<T?>
            {
                Success = false,
                Message = message
            };
        }
    }
    public class ServiceResponse
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public Dictionary<string, object> Extra { get; set; } = new();
    }
}
