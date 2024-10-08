
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace WidUpdatesLib.UpdRecs.DerivedUpdRecs
{
    public class UpdRecCon: UpdRecTran
    {
        public UpdRecCon(SqlCommand cmd, List<string> tranLines, DateTime fileTime) : base(cmd, tranLines, fileTime)
        {
        }

        public override void Apply()
        {
            //base.Apply();
        }
    }
}
