using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    [SqlFunction]
    public static SqlString ToUpperString(SqlString s)
    {
        return new SqlString(s.ToString().ToUpper());

    }

    [SqlFunction]
    public static SqlString ToLowerString(SqlString s)
    {
        return new SqlString(s.ToString().ToLower());
    }

    [SqlFunction]
    public static SqlDouble CircleSquare(SqlDouble radius)
    {
        return Math.PI * radius * radius;
    }
}
