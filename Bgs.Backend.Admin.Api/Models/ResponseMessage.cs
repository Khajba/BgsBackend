using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bgs.Backend.Admin.Api.Models
{
    public class ResponseMessage
    {
        public bool IsSeccess { get; set; }
        public string ErrorMessage { get; set; }
        
    }
    public class ResponseMessage<TData> : ResponseMessage
    {
        public TData Data { get; set; }
    }
}
