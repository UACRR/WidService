namespace IpsCommonTypes.Types
{
    public class RequestError
    {
        public string ControllerName { get; set; }
        public string CallMethodName { get; set; }
        public string SystemTypeName { get; set; }
        public string ObjectName { get; set;}
        public string ExceptionName { get; set; }
        public string ExceptionString { get; set; }
    }
}
