namespace IpsCommonTypes.Types
{
    public class ResponseError
    {
        public int? StatusCode { get; set; }
        public string ReasonPhrase { get; set; }
        public string MethodType { get; set; }
    }
}
