using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ApiResponse(int statusCode,string message=null)
        {
            StatusCode = statusCode;
            Message = message?? LoadDefaultMessage(statusCode);
        }

        private static string LoadDefaultMessage(int statusCode)
        {
            return statusCode switch{
                400=>"A bad request, you have made",
                401=>"Authoeized, you are not",
                404=>"Resourse found, it was not",
                500 => "Errors are the path to the dark side. Errors lead to anger. Anger leads to hate.  Hate leads to career change.",
                _ => null
            };
        }
    }
}