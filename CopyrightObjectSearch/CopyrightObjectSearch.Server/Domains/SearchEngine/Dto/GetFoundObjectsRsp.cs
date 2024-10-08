namespace CopyrightObjectSearch.Server
{
    public class GetFoundObjectsRsp
    {
        public FoundNameAuthorsPerformers[] FoundNameAuthorsPerformers { get; set; }
        public string ErrorText { get; set; }

        public GetFoundObjectsRsp() 
        {
            FoundNameAuthorsPerformers = [];
            ErrorText = "";
        }
    }
}
