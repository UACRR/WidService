using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace WidServiceLib
{
    public class Helpers
    {
        public static readonly DateTime msSqlMinDate = new DateTime(1900, 1, 1);
        public static readonly DateTime msSqlMaxDate = new DateTime(9999, 12, 31);
    }
}
