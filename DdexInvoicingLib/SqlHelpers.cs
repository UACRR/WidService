using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingLib
{
    public static class SqlHelpers
    {
        public static object GetSingleValue(string connectionString, string sqlQuery, params object[] paramValues)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                return GetSingleValue(conn, sqlQuery, paramValues);
            }
        }
        public static object GetSingleValue(SqlConnection conn, string sqlQuery, params object[] paramValues)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sqlQuery;
                for (int i = 0; i < paramValues.Length; i++)
                {
                    cmd.Parameters.AddWithValue($"@p{i}", paramValues[i]);
                }
                return cmd.ExecuteScalar();
            }
        }

        public static void UpdateValues(string connectionString, string sqlQuery, params object[] paramValues)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                UpdateValues(conn, sqlQuery, paramValues);
            }
        }
        public static void UpdateValues(SqlConnection conn, string sqlQuery, params object[] paramValues)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sqlQuery;
                for (int i = 0; i < paramValues.Length; i++)
                {
                    cmd.Parameters.AddWithValue($"@p{i}", paramValues[i]);
                }
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertRecord(string connectionString, string sqlQuery, params object[] paramValues)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                InsertRecord(conn, sqlQuery, paramValues);
            }
        }
        public static void InsertRecord(SqlConnection conn, string sqlQuery, params object[] paramValues)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sqlQuery;
                for (int i = 0; i < paramValues.Length; i++)
                {
                    cmd.Parameters.AddWithValue($"@p{i}", paramValues[i]);
                }
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteRecords(string connectionString, string sqlQuery, params object[] paramValues)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                DeleteRecords(conn, sqlQuery, paramValues);
            }
        }
        public static void DeleteRecords(SqlConnection conn, string sqlQuery, params object[] paramValues)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sqlQuery;
                for (int i = 0; i < paramValues.Length; i++)
                {
                    cmd.Parameters.AddWithValue($"@p{i}", paramValues[i]);
                }
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteByPortions(string connectionString, string tableName, string whereClause, params object[] paramValues)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                DeleteByPortions(conn, tableName, whereClause, paramValues);
            }
        }
        public static void DeleteByPortions(SqlConnection conn, string tableName, string whereClause, params object[] paramValues)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                const int delta = 100000;
                int totalCountDeleted = 0;
                Logger.WriteLine($"Видалення записів з таблиці {tableName}");
                cmd.CommandText = $"delete top ({delta}) from {tableName} where {whereClause}; select @@ROWCOUNT;";
                for (int i = 0; i < paramValues.Length; i++)
                {
                    cmd.Parameters.AddWithValue($"@p{i}", paramValues[i]);
                }
                while (true)
                {
                    int countDeleted = (int)cmd.ExecuteScalar();
                    if (countDeleted == 0)
                        return;
                    totalCountDeleted += countDeleted;
                    Logger.WriteLine($"Видалено {totalCountDeleted} записів");
                }

            }
        }

    }
}
