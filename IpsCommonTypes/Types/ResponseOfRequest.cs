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

        private ResponseOfRequest(Exception e)
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
        public bool HasException => Exception != null;

        public static ResponseOfRequest Success()
        {
            return new ResponseOfRequest
            {
                IsSuccess = true,
            };
        }

        public static ResponseOfRequest Success(string message)
        {
            return new ResponseOfRequest
            {
                IsSuccess = true,
                Message = message,
            };
        }

        public static ResponseOfRequest NotSuccess()
        {
            return new ResponseOfRequest
            {
                IsSuccess = false,
            };
        }

        public static ResponseOfRequest NotSuccess(string message)
        {
            return new ResponseOfRequest
            {
                IsSuccess = false,
                Message = message,
            };
        }

        public static ResponseOfRequest NotSuccess(Exception exception)
        {
            return new ResponseOfRequest(exception);
        }
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

        public static ResponseOfRequest<T> Success(T data)
        {
            return new ResponseOfRequest<T>
            {
                IsSuccess = true,
                Data = data,
            };
        }

        public static ResponseOfRequest<T> Success(T data, string message)
        {
            return new ResponseOfRequest<T>
            {
                IsSuccess = true,
                Data = data,
                Message = message,
            };
        }

        public new static ResponseOfRequest<T> NotSuccess()
        {
            return new ResponseOfRequest<T>
            {
                IsSuccess = false,
            };
        }

        public new static ResponseOfRequest<T> NotSuccess(string message)
        {
            return new ResponseOfRequest<T>
            {
                IsSuccess = false,
                Message = message,
            };
        }
    }
}
