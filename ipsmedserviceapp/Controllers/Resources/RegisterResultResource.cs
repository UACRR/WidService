namespace ipsmedserviceapp.Controllers.Resources
{
    public class RegisterResultResource : ResultRequestBase
    {
        public static RegisterResultResource EmailExist {
            get => new RegisterResultResource
            { 
                Succeeded = false,
                EmailExisted = true,
                ErrorMessage = "Email is already exists.",
            };
        }

        public bool EmailExisted { get; set; }
    }
}
