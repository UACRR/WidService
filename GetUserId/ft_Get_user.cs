using System;
using System.Data.SqlTypes;
//using ReportsLibrary;

public partial class UserDefinedFunctions
{
    public static class language
    {
        public static String Currenlanguage { get; set; }
    }


    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlString Ft_GeUserName()
    {
        
        return Environment.UserName;

    }
    
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlString Ft_GeCulture()
    {
         

        return language.Currenlanguage;

    }
    

}
