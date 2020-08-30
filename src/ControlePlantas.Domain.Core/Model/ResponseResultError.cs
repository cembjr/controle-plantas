using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControlePlantas.Domain.Core.Model
{
    public class ResponseResultError
    {
        public ResponseResultError(bool success, string message, object errors)
        {
            Success = success;
            Message = message;
            Errors = errors;

        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Errors { get; set; }

    }
}
