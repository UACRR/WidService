using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MsSqlClrExt
{
    public static class ClrTranslit
    {
        [SqlFunction(DataAccess = DataAccessKind.None)]
        public static string ClrTranslitFromUkrToLat(string source )
        {
            return Translit.FromUkr(source);
        }
    }
}
