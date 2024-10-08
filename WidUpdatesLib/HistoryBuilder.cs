using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace WidUpdatesLib
{
    public class HistoryBuilder
    {
        public static void BuildHistory(SqlCommand cmd, DateTime fileTime)
        {
            EntityInfo.GetEntityInfoList().ForEach(info =>
            {
                var wsInfo = info.widServiceEntityInfoEntry;
                if (wsInfo != null)
                {
                    Logger.WriteLine($"{wsInfo.tableName}: updating history");
                    cmd.CommandText = CreateCommandText(info);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@entityName", info.name);
                    cmd.Parameters.AddWithValue("@fileTime", fileTime);
                    cmd.ExecuteNonQuery();
                }
            });
        }

        private static string CreateCommandText(EntityInfo.EntityInfoEntry info)
        {
            var tableName = "";
            var colList = "";
            var colListT2 = "";
            var filter = "";
            var wsInfo = info.widServiceEntityInfoEntry;
            tableName = wsInfo.tableName;
            for (int i = 2; i < wsInfo.entityPropInfoList.Count - 4; i++)
            {
                var pi = wsInfo.entityPropInfoList[i];
                colList += $", {pi.propertyInfo.Name}";
                colListT2 += $", t2.{pi.propertyInfo.Name}";
                if(!string.IsNullOrEmpty(filter))
                {
                    filter += " or ";
                }
                filter += $"t2.{pi.propertyInfo.Name} <> t3.{pi.propertyInfo.Name}";
            }

            return BuildCommandText(tableName, colList, colListT2, filter);
        }

        private static string BuildCommandText(string tableName , string colList, string colListT2, string filter)
        {
            return
  $@"declare @minDate datetime = datefromparts(1900, 01, 01)
  declare @maxDate datetime = datefromparts(9999, 12, 31)

  drop table if exists #recordsToAddToHistory;

  select t2.Id, t2.Wic{colListT2}
  into #recordsToAddToHistory
  from SocWidUpdates..WrkAffectedRecords t1
    join SocWid..{tableName} t2 on t1.Wic = t2.Wic
    left join SocWid..{tableName}Hist t3 on t2.Id = t3.Id
  where t1.EntityName = @entityName
    and t3.Id is null

insert #recordsToAddToHistory(Id, Wic{colList})
select t2.Id, t2.Wic{colListT2}
from SocWidUpdates..WrkAffectedRecords t1
    join SocWid..{tableName} t2 on t1.Wic = t2.Wic
    join SocWid..{tableName}Hist t3 on t2.Id = t3.Id
where t1.EntityName = @entityName
    and t3.ValidTo = @maxDate
    and({filter})

update t2
set t2.ValidTo = @fileTime
from #recordsToAddToHistory t1
    join SocWid..{tableName}Hist t2 on t1.Id = t2.Id
where t2.ValidTo = @maxDate

insert SocWid..{tableName}Hist(Id, ValidFrom, ValidTo, Wic{colList})
select Id, @fileTime, @maxDate, Wic{colList}
from #recordsToAddToHistory

update t2
set t2.ValidTo = @fileTime
from SocWidUpdates..WrkAffectedRecords t1
    join SocWid..{tableName}Hist t2 on t1.Wic = t2.Wic
    left join SocWid..{tableName} t3 on t2.Id = t3.Id
where t1.EntityName = @entityName
    and t3.Id is null
    and t2.ValidTo = @maxDate

drop table if exists #recordsToAddToHistory;

delete SocWidUpdates..WrkAffectedRecords where EntityName = @entityName";
        }
    }
}
