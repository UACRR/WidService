using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GetLnUsr;
using System.Globalization;
using Microsoft.SqlServer.Server;

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
        
        return CultureInfo.CurrentCulture.Name;
        ;
    }

}
