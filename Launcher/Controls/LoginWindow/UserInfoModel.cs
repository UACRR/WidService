using System.Security;

namespace Launcher.Controls.LoginWindow
{
    public class UserInfoModel
    {
        public string UserName { get; set; }
        public string UserLogin { get; set; }
        public string UserRole { get; set; }
        public SecureString Password { get; set; }
    }
}
