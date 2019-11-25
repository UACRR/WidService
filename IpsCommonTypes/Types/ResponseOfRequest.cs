namespace IpsCommonTypes.Types
{
    public class ResponseOfRequest
    {
        public ResponseOfRequest()
        {
            
        }

        public ResponseOfRequest(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public string InnerMessage { get; set; }
        public int StatusCode { get; set; }
    }
}
