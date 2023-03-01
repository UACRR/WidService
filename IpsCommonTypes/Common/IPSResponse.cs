using System;

namespace IpsCommonTypes.Common
{
    public class IPSResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public Exception Exception { get; set; }
        public string ErrorMessage { get; set; }
    }
}
