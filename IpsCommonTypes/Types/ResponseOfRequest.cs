using System;

namespace IpsCommonTypes.Types
{
    public class ResponseOfRequest
    {
        public ResponseOfRequest()
        {
            
        }

        /// <summary>
        /// Success response. IsSuccess = true
        /// </summary>
        /// <param name="successMessage"></param>
        public ResponseOfRequest(string successMessage)
        {
            Message = successMessage;
            IsSuccess = true;
        }

        /// <summary>
        /// Error response. IsSuccess = false
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="e"></param>
        public ResponseOfRequest(string errorMessage, Exception e)
        {
            Message = errorMessage;
            InnerMessage = e.ToString();
            StatusCode = e.HResult;
            Exception = e;
        }

        public ResponseOfRequest(Exception e)
        {
            Message = e.Message;
            InnerMessage = e.ToString();
            StatusCode = e.HResult;
            Exception = e;
        }

        public string Message { get; set; }
        public string InnerMessage { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public Exception Exception { get; set; }
    }

    public class ResponseOfRequest<T> : ResponseOfRequest
    {
        public ResponseOfRequest() { }

        public ResponseOfRequest(T data)
        {
            IsSuccess = true;
            Data = data;
        }

        public ResponseOfRequest(Exception exception)
        {
            IsSuccess = false;
            Exception = exception;
        }

        public T Data { get; set; }
    }
}
