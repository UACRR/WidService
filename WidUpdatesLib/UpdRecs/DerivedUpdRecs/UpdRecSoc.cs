
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WidUpdatesLib.UpdRecs.DerivedUpdRecs
{
    public class UpdRecSoc: UpdRecTran
    {
        public UpdRecSoc(SqlCommand cmd, List<string> tranLines, DateTime fileTime) : base(cmd, tranLines, fileTime)
        {
        }

        public override void Apply()
        {
            base.Apply();
        }
    }
}
