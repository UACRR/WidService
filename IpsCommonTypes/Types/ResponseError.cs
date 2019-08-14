namespace IpsCommonTypes.Types
{
    /// <summary>
    /// Помилка яка виникає при реквесті або після нього (відповідь IsSuccessful = false)
    /// </summary>
    public class ResponseError
    {
        public int? StatusCode { get; set; }
        public string ReasonPhrase { get; set; }
        public string MethodType { get; set; }
    }
}
