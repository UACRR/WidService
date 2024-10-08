using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidExport
{
    public class WidSubmGroupPreProcService
    {
        public class Name
        {
            public int Id { get; set; }
            public string LocalName { get; set; }
            public string WidName { get; set; }
            public bool IsConfirmed { get; set; }
            public bool IsMain { get; set; }
            public bool IsDuplicate { get; set; }
        }

        public class ObjName
        {
            public int ObjId { get; set; }
            public List<Name> Names { get; set; }
        }

        public void ProcessNames(SqlCommand cmd, int groupId, bool forPerformer)
        {
            var workNames = new List<ObjName>();

            var tableName = forPerformer ? "WidSubmGroupWorkPerformer" : "WidSubmGroupWorkName";
            var colIsMain = forPerformer ? "" : "IsMain,";
            var corderIsMain = forPerformer ? "" : ", IsMain desc";

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $@"
                    select Id, ObjId, LocalName, WidName, {colIsMain} IsDuplicate 
                    from {tableName} 
                    where WidSubmGroupId = @WidSubmGroupId and IsConfirmed = 0
                    order by ObjId{corderIsMain}
                ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@WidSubmGroupId", groupId);
            using (var r = cmd.ExecuteReader())
            {
                var objId = 0;
                ObjName objName = null;
                while (r.Read())
                {
                    var newObjId = r.GetInt32(1);
                    if (objId != newObjId)
                    {
                        objName = new ObjName
                        {
                            ObjId = newObjId,
                            Names = new List<Name>(),
                        };
                        workNames.Add(objName);
                        objId = newObjId;
                    }
                    objName.Names.Add(new Name
                    {
                        Id = r.GetInt32(0),
                        LocalName = r.GetString(2).Trim(),
                        WidName = r.GetString(3),
                        IsConfirmed = false,
                        IsMain = forPerformer ? true : r.GetBoolean(4),
                        IsDuplicate = false, // r.GetBoolean(0),
                    });
                }
            }

            workNames.ForEach(workName =>
            {
                workName.Names.ForEach(name =>
                {
                    name.WidName = Translit.FromUkr(name.LocalName).ToUpper();
                    name.WidName = name.WidName.Substring(0, Math.Min(name.WidName.Length, forPerformer ? 35 : 60));
                });
                for (var i = 0; i < workName.Names.Count; i++)
                {
                    for(var j = i + 1; j < workName.Names.Count; j++)
                    {
                        if(workName.Names[i].WidName.Equals(workName.Names[j].WidName))
                        {
                            workName.Names[j].IsDuplicate = true;
                        }
                    }
                }
            });

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $@"
                    update {tableName}
                    set 
                          WidName = @WidName
                        , IsConfirmed = 1
                        , IsDuplicate = @IsDuplicate
                    where Id = @Id
                ";

            workNames.ForEach(workName =>
            {
                workName.Names.ForEach(name =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@WidName", name.WidName);
                    cmd.Parameters.AddWithValue("@IsDuplicate", name.IsDuplicate);
                    cmd.Parameters.AddWithValue("@Id", name.Id);
                    cmd.ExecuteNonQuery();
                });
            });
        }

        public void ProcessWorkNames(SqlCommand cmd, int objId, bool forPerformer)
        {
            var objName = new ObjName
            {
                ObjId = objId,
                Names = new List<Name>(),
            };

            var tableName = forPerformer ? "WidSubmGroupWorkPerformer" : "WidSubmGroupWorkName";
            var colIsMain = forPerformer ? "" : "IsMain,";
            var corderIsMain = forPerformer ? "" : ", IsMain desc";

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $@"
                    select Id, ObjId, LocalName, WidName, IsConfirmed, {colIsMain} IsDuplicate 
                    from {tableName} 
                    where ObjId = @ObjId
                    order by ObjId{corderIsMain}
                ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ObjId", objId);
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    objName.Names.Add(new Name
                    {
                        Id = r.GetInt32(0),
                        LocalName = r.GetString(2).Trim(),
                        WidName = r.GetString(3),
                        IsConfirmed = r.IsDBNull(4) ? false : r.GetBoolean(4),
                        IsMain = forPerformer ? true : r.GetBoolean(5),
                        IsDuplicate = false, // r.GetBoolean(0),
                    });
                }
            }

            objName.Names.ForEach(name =>
            {
                name.WidName = Translit.FromUkr(name.LocalName).ToUpper();
                name.WidName = name.WidName.Substring(0, Math.Min(name.WidName.Length, forPerformer ? 35 : 60));
            });

            for (var i = 0; i < objName.Names.Count; i++)
            {
                if (!objName.Names[i].IsConfirmed)
                {
                    for (var j = i + 1; j < objName.Names.Count; j++)
                    {
                        if (objName.Names[i].WidName.Equals(objName.Names[j].WidName))
                        {
                            objName.Names[j].IsDuplicate = true;
                        }
                    }
                }
            }

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $@"
                    update {tableName}
                    set 
                          WidName = @WidName
                        , IsConfirmed = 1
                        , IsDuplicate = @IsDuplicate
                    where Id = @Id
                ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ObjId", objId);
            objName.Names.ForEach(name =>
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@WidName", name.WidName);
                cmd.Parameters.AddWithValue("@IsDuplicate", name.IsDuplicate);
                cmd.Parameters.AddWithValue("@Id", name.Id);
                cmd.ExecuteNonQuery();
            });
        }
    }
}
