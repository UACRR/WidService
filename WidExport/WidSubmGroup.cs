using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidExport
{
    public class WidSubmGroup
    {
        public int Id { get; set; }
        public int SeqNr { get; set; }
        public string Name { get; set; }
        public WidSubmGroupStatus Status { get; set; }
        public char GroupType { get; set; }

        public static WidSubmGroup FromDb(int groupId)
        {
            WidSubmGroup retVal = null;
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spWidSubmGroupSelect";
                cmd.Parameters.AddWithValue("@groupId", groupId);
                using (var r = cmd.ExecuteReader())
                {
                    r.Read();
                    retVal = new WidSubmGroup
                    {
                        Id = r.GetInt32(0),
                        SeqNr = r.GetInt32(1),
                        Name = r.GetString(2),
                        Status = (WidSubmGroupStatus)r.GetInt32(3),
                        GroupType = Convert.ToChar(r.GetValue(4)),
                    };
                }
            });
            return retVal;
        }
    }
}
