using IpsCommonTypes.Enums;
using System;

namespace IpsCommonTypes.Types
{
    public class ExecSqlResponce<T> where T: class
    {
        public ExecSqlResponceStatus StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

    }
}
