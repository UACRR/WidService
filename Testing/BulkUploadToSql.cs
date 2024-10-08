using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Testing
{
    public class BulkUploadToSql
    {
        public string TableName { get; set; }
        public int CommitBatchSize { get; set; } = 10000;
        public SqlConnection conn { get; set; }
        public DataTable dtColInfo { get; set; }
        public SqlTransaction tran { get; set; }

        private DataTable dt;
        private SqlBulkCopy bulkCopy;

        public SqlBulkCopyOptions options = SqlBulkCopyOptions.TableLock
                        | SqlBulkCopyOptions.FireTriggers
                        //| SqlBulkCopyOptions.UseInternalTransaction
                        //| SqlBulkCopyOptions.KeepIdentity
                        | SqlBulkCopyOptions.CheckConstraints;

        public void Init()
        {
            if (bulkCopy == null)
                bulkCopy = new SqlBulkCopy(
                    conn,
                    options,
                    tran
                );

            if (dtColInfo == null)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Transaction = tran;
                cmd.CommandText = @"select COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH
                        from INFORMATION_SCHEMA.COLUMNS
                        where TABLE_NAME = @TableName
                        order by ORDINAL_POSITION";
                cmd.Parameters.Add(new SqlParameter("@TableName", TableName));
                cmd.Connection = conn;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    try
                    {
                        dtColInfo = new DataTable();
                        da.Fill(dtColInfo);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }

            if (dt == null)
            {

                dt = new DataTable();
                for (int i = 0; i < dtColInfo.Rows.Count; i++)
                {
                    DataRow colInfo = dtColInfo.Rows[i];
                    string colType = colInfo[1].ToString();
                    dt.Columns.Add((string)colInfo[0], colType.Equals("int") ? typeof(int)
                        : colType.Equals("date") ? typeof(DateTime)
                        : colType.Equals("decimal") ? typeof(decimal)
                        : typeof(string));
                }
            }
        }

        private static string Left(string source, int length)
        {
            return source.Length <= length ? source : source.Substring(0, length);
        }

        public void AddData(List<object> data)
        {
            Init();

            try
            {
                DataRow row = dt.NewRow();
                bool hasErrors = false;
                int colIndex = 0;
                foreach (var propValue in data)
                {
                    DataRow colInfo = dtColInfo.Rows[colIndex];
                    string colType = colInfo[1].ToString();
                    int colSize = colInfo[2] == DBNull.Value ? 0 : (int)colInfo[2];
                    if (colType.Equals("varchar", StringComparison.OrdinalIgnoreCase) || colType.Equals("nvarchar", StringComparison.OrdinalIgnoreCase))
                        row[colIndex] = Left(propValue.ToString(), colSize);
                    else
                        row[colIndex] = propValue;
                    colIndex++;
                }

                if (hasErrors)
                    return;

                dt.Rows.Add(row);
            }
            catch(Exception ex)
            {
                throw;
            }

            if (dt.Rows.Count == CommitBatchSize)
            {
                Flush();
            }

        }

        public void Flush()
        {
            if (dt == null) // no rows inserted
                return;
            BulkInsert(dt);

            dt.Rows.Clear();
        }

        private void BulkInsert(DataTable dt)
        {
            try
            {
                //SqlBulkCopy bulkCopy = new SqlBulkCopy(
                    //conn,
                    //SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.FireTriggers | SqlBulkCopyOptions.UseInternalTransaction,
                    //null
                //);
                bulkCopy.BulkCopyTimeout = 0;

                bulkCopy.DestinationTableName = TableName;
                bulkCopy.WriteToServer(dt);
            }
            catch(Exception ex)
            {
                DataRow row = dt.Rows[0];
                int i = 0;
                foreach (var item in row.ItemArray)
                {
                    DataRow rowColInfo = dtColInfo.Rows[i];
                    Console.WriteLine($"{rowColInfo.ItemArray[0]}({rowColInfo.ItemArray[1]}) = {item}");
                    i++;
                }
                throw;
            }
        }

    }
}
