namespace IpsCommonTypes.Types
{
    public class ResponseOfRequest
    {
        public string ResponseMessage { get; set; }
        public string InnerMessage { get; set; }
        public int StatusCode { get; set; }
    }
}
