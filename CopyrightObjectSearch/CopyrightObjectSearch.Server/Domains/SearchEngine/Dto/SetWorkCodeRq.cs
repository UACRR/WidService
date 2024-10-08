namespace CopyrightObjectSearch.Server
{
    public class SetWorkCodeRq
    {
        public required string WorkCode { get; set; }
        public int ExternalObjectId { get; set; }

        public SetWorkCodeRq()
        {
            WorkCode = "";
        }
    }
}
