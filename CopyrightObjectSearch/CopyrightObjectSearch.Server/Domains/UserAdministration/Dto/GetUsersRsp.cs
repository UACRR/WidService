namespace CopyrightObjectSearch.Server
{
    public class GetUsersRsp
    {
        public class UserDto
        {
            public required int    Id      { get; set; }
            public required string Name    { get; set; }
            public required string Login   { get; set; }
            public required int[]  RoleIds { get; set; }
        }
        public required UserDto[] Users { get; set; }
    }
}
