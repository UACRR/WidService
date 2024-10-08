namespace CopyrightObjectSearch.Server
{
    public class AddUserRsp
    {
        public required string ErrorCode { get; set; }
        public required int    Id        { get; set; }
        public required string Name      { get; set; }
        public required string Login     { get; set; }
        public required int[]  RoleIds   { get; set; }
    }
}
