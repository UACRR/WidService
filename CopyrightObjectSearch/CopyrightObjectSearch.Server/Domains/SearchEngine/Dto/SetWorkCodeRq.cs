namespace CopyrightObjectSearch.Server
{
    public class SetWorkCodeRq
    {
        public required string WorkCode { get; set; }
        public int PartnerWorkId { get; set; }

        public SetWorkCodeRq()
        {
            WorkCode = "";
        }
    }
}
