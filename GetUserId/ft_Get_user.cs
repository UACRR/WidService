using System;
using System.Data.SqlTypes;
using ReportsLibrary;

public partial class UserDefinedFunctions
{
    

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
