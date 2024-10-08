
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace WidUpdatesLib.UpdRecs.DerivedUpdRecs
{
    public class UpdRecDel: UpdRecTran
    {
        public UpdRecDel(SqlCommand cmd, List<string> tranLines, DateTime fileTime) : base(cmd, tranLines, fileTime)
        {
        }

        public override void Apply()
        {
            //throw new Exception("Not implemented");
        }
    }
}
