using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WidTestConsole
{
    public class SocWidAdminImporter
    {
        private delegate void RunCmd(SqlCommand cmd);

        private const string _connectString = @"Persist Security Info=False;Trusted_Connection=yes;Initial Catalog = SocWidAdmin; Server=localhost";
        private string _rootFolder;

        public SocWidAdminImporter(string rootFolder)
        {
            _rootFolder = rootFolder;
        }
        public void ImportFromFiles()
        {
            RunSql(cmd =>
            {
                cmd.CommandText = @"
                    delete from WidTasks
                    delete from WidTaskObjects
                    delete from WidTaskSubjects
                    delete from WidUpdatePeriods
                ";
                cmd.ExecuteNonQuery();
            });
            ImportWidUpdatePeriods();
            ImportWidTaskSubjects();
            ImportWidTaskObjects();
            ImportWidTasks();
        }

        private void RunSql(RunCmd runCmd)
        {
            using (var conn = new SqlConnection(_connectString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    try
                    {
                        runCmd(cmd);
                    }
                    catch (Exception ex)
                    {
                        //tran.Rollback();
                    }
                }
            }

        }

        private void ImportWidUpdatePeriods()
        {
            var lines = File.ReadLines(Path.Combine(_rootFolder, "WidUpdatePeriods.txt"));
            RunSql(cmd =>
            {
                cmd.CommandText = "set identity_insert WidUpdatePeriods on";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"
                insert into WidUpdatePeriods (
                      Id
                    , WidTaskStatusId
                    , WidDumpTs
                    , NewWidDumpTs
                    , WidDumpFilesTotalSize
                    , NewWidDumpFilesTotalSize
                    , IpiDumpTs
                    , NewIpiDumpTs
                    , StartedAt
                    , EndedAt
                    , CreatedAt
                    , UpdatedAt
                )
                values (
                      @Id
                    , @WidTaskStatusId
                    , @WidDumpTs
                    , @NewWidDumpTs
                    , @WidDumpFilesTotalSize
                    , @NewWidDumpFilesTotalSize
                    , @IpiDumpTs
                    , @NewIpiDumpTs
                    , @StartedAt
                    , @EndedAt
                    , @CreatedAt
                    , @UpdatedAt
                )
            ";
                lines.ToList().ForEach(line =>
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var fields = line.Split("\t");
                        cmd.Parameters.Clear();
                        int i = 0;
                        cmd.Parameters.AddWithValue("@Id", GetInt(fields, i++));
                        cmd.Parameters.AddWithValue("@WidTaskStatusId", GetInt(fields, i++));
                        cmd.Parameters.AddWithValue("@WidDumpTs", GetDat(fields, i++));
                        cmd.Parameters.AddWithValue("@NewWidDumpTs", GetDat(fields, i++));
                        cmd.Parameters.AddWithValue("@WidDumpFilesTotalSize", GetInt(fields, i++));
                        cmd.Parameters.AddWithValue("@NewWidDumpFilesTotalSize", GetInt(fields, i++));
                        cmd.Parameters.AddWithValue("@IpiDumpTs", GetDat(fields, i++));
                        cmd.Parameters.AddWithValue("@NewIpiDumpTs", GetDat(fields, i++));
                        cmd.Parameters.AddWithValue("@StartedAt", GetDat(fields, i++));
                        cmd.Parameters.AddWithValue("@EndedAt", GetDat(fields, i++));
                        cmd.Parameters.AddWithValue("@CreatedAt", GetDat(fields, i++));
                        cmd.Parameters.AddWithValue("@UpdatedAt", GetDat(fields, i++));
                        cmd.ExecuteNonQuery();
                    }
                });
                cmd.CommandText = "set identity_insert WidUpdatePeriods off";
                cmd.ExecuteNonQuery();
            });
        }
        private void ImportWidTaskSubjects()
        {
            var lines = File.ReadLines(Path.Combine(_rootFolder, "WidTaskSubjects.txt"));
            RunSql(cmd =>
            {
                cmd.CommandText = "set identity_insert WidTaskSubjects on";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"
                    insert into WidTaskSubjects (
                          Id
                        , WidUpdatePeriodId
                        , WidTaskSubjectTypeId
                        , WidTaskStatusId
                        , Db
                        , TasksDate
                        , StartedAt
                        , EndedAt
                        , CreatedAt
                        , UpdatedAt
                    )
                    values (
                          @Id
                        , @WidUpdatePeriodId
                        , @WidTaskSubjectTypeId
                        , @WidTaskStatusId
                        , @Db
                        , @TasksDate
                        , @StartedAt
                        , @EndedAt
                        , @CreatedAt
                        , @UpdatedAt
                    )
                ";
                lines.ToList().ForEach(line =>
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var fields = line.Split("\t");
                        cmd.Parameters.Clear();
                        int i = 0;
                        cmd.Parameters.AddWithValue("@Id"                   , GetInt(fields, i++)  );
                        cmd.Parameters.AddWithValue("@WidUpdatePeriodId"    , GetInt(fields, i++)  );
                        cmd.Parameters.AddWithValue("@WidTaskSubjectTypeId" , GetInt(fields, i++)  );
                        cmd.Parameters.AddWithValue("@WidTaskStatusId"      , GetInt(fields, i++)  );
                        cmd.Parameters.AddWithValue("@Db"                   , GetStr(fields, i++)  );
                        cmd.Parameters.AddWithValue("@TasksDate"            , GetDat(fields, i++)  );
                        cmd.Parameters.AddWithValue("@StartedAt"            , GetDat(fields, i++)  );
                        cmd.Parameters.AddWithValue("@EndedAt"              , GetDat(fields, i++)  );
                        cmd.Parameters.AddWithValue("@CreatedAt"            , GetDat(fields, i++)  );
                        cmd.Parameters.AddWithValue("@UpdatedAt"            , GetDat(fields, i++)  );
                        cmd.ExecuteNonQuery();
                    }
                });
                cmd.CommandText = "set identity_insert WidTaskSubjects off";
                cmd.ExecuteNonQuery();
            });
        }
        private void ImportWidTaskObjects()
        {
            var lines = File.ReadLines(Path.Combine(_rootFolder, "WidTaskObjects.txt"));
            RunSql(cmd =>
            {
                cmd.CommandText = "set identity_insert WidTaskObjects on";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"
                    insert into WidTaskObjects (
                          Id
                        , WidTaskSubjectId
                        , WidTaskStatusId
                        , ObjectInfo
                        , ObjectFileTs
                        , StartedAt
                        , EndedAt
                        , CreatedAt
                        , UpdatedAt
                    )
                    values (
                          @Id
                        , @WidTaskSubjectId
                        , @WidTaskStatusId
                        , @ObjectInfo
                        , @ObjectFileTs
                        , @StartedAt
                        , @EndedAt
                        , @CreatedAt
                        , @UpdatedAt
                    )
                ";
                lines.ToList().ForEach(line =>
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var fields = line.Split("\t");
                        cmd.Parameters.Clear();
                        int i = 0;
                        cmd.Parameters.AddWithValue("@Id", GetInt(fields, i++));
                        cmd.Parameters.AddWithValue("@WidTaskSubjectId", GetInt(fields, i++));
                        cmd.Parameters.AddWithValue("@WidTaskStatusId", GetInt(fields, i++));
                        cmd.Parameters.AddWithValue("@ObjectInfo", GetStr(fields, i++));
                        cmd.Parameters.AddWithValue("@ObjectFileTs", GetDat(fields, i++));
                        cmd.Parameters.AddWithValue("@StartedAt", GetDat(fields, i++));
                        cmd.Parameters.AddWithValue("@EndedAt", GetDat(fields, i++));
                        cmd.Parameters.AddWithValue("@CreatedAt", GetDat(fields, i++));
                        cmd.Parameters.AddWithValue("@UpdatedAt", GetDat(fields, i++));
                        cmd.ExecuteNonQuery();
                    }
                });
                cmd.CommandText = "set identity_insert WidTaskObjects off";
                cmd.ExecuteNonQuery();
            });
        }
        private void ImportWidTasks()
        {
            var lines = File.ReadLines(Path.Combine(_rootFolder, "WidTasks.txt"));
            RunSql(cmd =>
            {
                cmd.CommandText = "set identity_insert WidTasks on";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"
                    insert into WidTasks (
                          Id
                        , WidTaskObjectId
                        , WidTaskTypeId
                        , WidTaskStatusId
                        , PrevWidTaskId
                        , NextWidTaskId
                        , PercentDone
                        , LastTransLineIdx
                        , ErrMsg
                        , ScheduledAt
                        , StartedAt
                        , EndedAt
                        , CreatedAt
                        , UpdatedAt
                        , WidConfigurationEntityId
                    )
                    values (
                          @Id
                        , @WidTaskObjectId
                        , @WidTaskTypeId
                        , @WidTaskStatusId
                        , @PrevWidTaskId
                        , @NextWidTaskId
                        , @PercentDone
                        , @LastTransLineIdx
                        , @ErrMsg
                        , @ScheduledAt
                        , @StartedAt
                        , @EndedAt
                        , @CreatedAt
                        , @UpdatedAt
                        , @WidConfigurationEntityId
)
                ";
                lines.ToList().ForEach(line =>
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var fields = line.Split("\t");
                        cmd.Parameters.Clear();
                        int i = 0;
                        cmd.Parameters.AddWithValue("@Id", GetInt(fields, i++));
                        cmd.Parameters.AddWithValue("@WidTaskObjectId", GetInt(fields, i++));
                        cmd.Parameters.AddWithValue("@WidTaskTypeId", GetInt(fields, i++));
                        cmd.Parameters.AddWithValue("@WidTaskStatusId", GetInt(fields, i++));
                        cmd.Parameters.AddWithValue("@PrevWidTaskId", GetInt(fields, i++));
                        cmd.Parameters.AddWithValue("@NextWidTaskId", GetInt(fields, i++));
                        cmd.Parameters.AddWithValue("@PercentDone", GetDec(fields, i++));
                        cmd.Parameters.AddWithValue("@LastTransLineIdx", GetInt(fields, i++));
                        cmd.Parameters.AddWithValue("@ErrMsg", GetStr(fields, i++));
                        cmd.Parameters.AddWithValue("@ScheduledAt", GetDat(fields, i++));
                        cmd.Parameters.AddWithValue("@StartedAt", GetDat(fields, i++));
                        cmd.Parameters.AddWithValue("@EndedAt", GetDat(fields, i++));
                        cmd.Parameters.AddWithValue("@CreatedAt", GetDat(fields, i++));
                        cmd.Parameters.AddWithValue("@UpdatedAt", GetDat(fields, i++));
                        cmd.Parameters.AddWithValue("@WidConfigurationEntityId", GetInt(fields, i++));
                        cmd.ExecuteNonQuery();
                    }
                });
                cmd.CommandText = "set identity_insert WidTasks off";
                cmd.ExecuteNonQuery();
            });
        }
        private object GetInt(string[] fields, int index)
        {
            if (fields[index].Equals("NULL", StringComparison.OrdinalIgnoreCase))
                return DBNull.Value;
            else
                return long.Parse(fields[index]);
        }

        private object GetDec(string[] fields, int index)
        {
            if (fields[index].Equals("NULL", StringComparison.OrdinalIgnoreCase))
                return DBNull.Value;
            else
                return decimal.Parse(fields[index]);
        }

        private object GetStr(string[] fields, int index)
        {
            if (fields[index].Equals("NULL", StringComparison.OrdinalIgnoreCase))
                return DBNull.Value;
            else
                return fields[index];
        }

        private object GetDat(string[] fields, int index)
        {
            if (fields[index].Equals("NULL", StringComparison.OrdinalIgnoreCase))
                return DBNull.Value;
            else
                return DateTime.Parse(fields[index]);
        }
    }
}
