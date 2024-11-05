using System.Security.Cryptography;

namespace CopyrightObjectSearch.Server
{
    public class LoginRq
    {
        public required string Login    { get; set; }
        public required string Password { get; set; }
    }
}
