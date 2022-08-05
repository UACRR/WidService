namespace IpsCommonTypes.Types
{
    /// <summary>
    ///  Помилка, яка виникає при роботі метода контролера.
    /// </summary>
    /// <remarks>Коли виникають: exceptions, збереження змін в БД</remarks>
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
