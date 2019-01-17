namespace ipsmedserviceapp.Controllers.Resources
{
    public class LoginResultResource : ResultRequestBase
    {
        public static LoginResultResource EmailNotConfirmed
        {
            get => new LoginResultResource
            { 
                Succeeded = true,
                EmailConfirmed = false,
                ErrorMessage = "Email not confirmed.",
            };
        }

        public static LoginResultResource Succeess
        {
            get => new LoginResultResource
            { 
                Succeeded = true,
                EmailConfirmed = true,
            };
        }

        public static LoginResultResource UserNamePasswordInvalid
        {
            get => new LoginResultResource
            { 
                Succeeded = false,
                EmailConfirmed = false,
                ErrorMessage = "Username or password is invalid.",
            };
        }

        public bool EmailConfirmed { get; set; }
        public string Token { get; set; }
    }
}
