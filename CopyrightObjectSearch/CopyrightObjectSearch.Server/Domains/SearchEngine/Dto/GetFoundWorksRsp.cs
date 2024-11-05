namespace CopyrightObjectSearch.Server
{
    public class GetFoundWorksRsp
    {
        public FoundNameAuthorsPerformers[] FoundNameAuthorsPerformers { get; set; }
        public string ErrorText { get; set; }

        public GetFoundWorksRsp() 
        {
            FoundNameAuthorsPerformers = [];
            ErrorText = "";
        }
    }
}
