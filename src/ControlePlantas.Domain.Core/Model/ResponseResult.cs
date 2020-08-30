using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePlantas.Domain.Core.Model
{
    public class ResponseResult
    {
        public ResponseResult(bool success, object data = null, string message = "", IDictionary<string, object> errors = null)
        {
            Success = success;
            Data = data;
            Message = message;
            Errors = errors;
        }
        public ResponseResult(bool success, string message, string error)
        {
            Success = success;
            Message = message;
            Errors = new Dictionary<string, object>();
            Errors.Add("Erro", error);
        }

        public ResponseResult(bool success, string error)
        {
            Success = success;
            Errors = new Dictionary<string,object>();
            Errors.Add("Erro", error);
        }

        public bool Success { get; }
        public object Data { get; }
        public string Message { get; }
        public IDictionary<string, object> Errors { get; }

    }

}
