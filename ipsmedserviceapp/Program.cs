using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ipsmedserviceapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
#if DEBUG
                .UseHttpSys(options =>
                {
                    options.MaxRequestBodySize = 252428800;
                    options.Authentication.Schemes = Microsoft.AspNetCore.Server.HttpSys.AuthenticationSchemes.NTLM | Microsoft.AspNetCore.Server.HttpSys.AuthenticationSchemes.Negotiate;
                    options.Authentication.AllowAnonymous = false;
                })
#endif
                .Build();
    }
}
