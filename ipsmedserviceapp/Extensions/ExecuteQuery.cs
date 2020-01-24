using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ipsmedserviceapp.Extensions
{
    public static class ExecuteQuery
    {
        public static List<object[]> GetDataFromSqlServer(DatabaseFacade facade, string query)
        {
            DataTable table;
            using (SqlConnection sqlConnection = (SqlConnection)facade.GetDbConnection())
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);

                table = dataSet.Tables[0];
            }

            var list = new List<object[]>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                var row = table.Rows[i].ItemArray;
                list.Add(row);
            }

            return list;
        }

        public static DataTable GetDataFromSqlServer(SqlConnection sqlConnection, string query)
        {
            if (sqlConnection.State != ConnectionState.Open) 
                sqlConnection.Open();
            
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            var table = dataSet.Tables[0];

            return table;
        }
    }
}
