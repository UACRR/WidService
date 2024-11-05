using System.Security.Cryptography;

namespace CopyrightObjectSearch.Server
{
    public class LoginRsp
    {
        public required string  ErrorText { get; set; }
        public required int     Id        { get; set; }
        public required string  Name      { get; set; }
        public required string  Login     { get; set; }
        public required int[]   RoleIds   { get; set; }
    }
}
