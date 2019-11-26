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
        }

        public string Message { get; set; }
        public string InnerMessage { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
    }
}
