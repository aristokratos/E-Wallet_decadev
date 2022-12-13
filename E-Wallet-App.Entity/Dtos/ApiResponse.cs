
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet_App.Entity.Dtos
{
    public class ApiResponse
    {
        public object Data { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }

        public ApiResponse(string message = null)
        {
            Succeeded = true;
            Message = message;
        }
        public static ApiResponse Success(object data)
        {
            return new ApiResponse { Data = data, Message = "success" };
        }
    }
}