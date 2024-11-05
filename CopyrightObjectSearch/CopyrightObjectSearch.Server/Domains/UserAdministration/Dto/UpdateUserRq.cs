namespace CopyrightObjectSearch.Server
{
    public class UpdateUserRq
    {
        public required int    Id        { get; set; }
        public required string Name      { get; set; }
        public required string Login     { get; set; }
        public required int[]  RoleIds   { get; set; }
    }
}
