using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace ipsmedserviceapp.Auth
{
  public class TokenAuthOption
  {
    private static string secret_key = "MediaService_Kiyv_Ukraine_security_key_!_20180102";
    public static string Audience { get; } = "IpsAudience";
    public static string Issuer { get; } = "IpsIssuer";
    public static SymmetricSecurityKey Key { get; } = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret_key));
   
    public static SigningCredentials SigningCredentials { get; } = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

    public static TimeSpan ExpiresSpan { get; } = TimeSpan.FromHours(48);
    public static string TokenType { get; } = "Bearer";
  }
}
