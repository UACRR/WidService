using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using IpsCommonTypes.IntermediaryTypes;
using IpsCommonTypes.Types;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.UrlMatches;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Microsoft.Win32.SafeHandles;
using MediaTypeHeaderValue = Microsoft.Net.Http.Headers.MediaTypeHeaderValue;

namespace ipsmedserviceapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportReportToFileController : ControllerBase
    {
        private readonly MediaServiceContext _dbContext;

        public ExportReportToFileController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// список можливих користувацьких реєстрів
        /// </summary>
        /// <returns></returns>
        [HttpGet("customRegisterTypes")]
        public IActionResult GetCustomRegisterTypes()
        {
            Dictionary<int, string> customRegisterTypes = new Dictionary<int, string>();

            string query = "select * from PrtReestrType";

            using (SqlConnection sqlConnection = (SqlConnection)_dbContext.Database.GetDbConnection())
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.CommandTimeout = 30;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);

                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    customRegisterTypes.Add((int)dataRow.ItemArray[0], (string)dataRow.ItemArray[1]);
                }
            }

            return Ok(customRegisterTypes);
        }

        /// <summary>
        /// реєстр по DDEX
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cultureName"></param>
        /// <returns></returns>
        [HttpGet("DDEXRegister/{id}/{cultureName}")]
        public async Task<IActionResult> ExportDDEXRegisterById(int id, string cultureName)
        {
            try
            {
                CultureInfo cultureInfo = new CultureInfo(cultureName);

                string query = "exec p_Tsk_11_Prt_DDEX @id";

                SqlParameter parameter = new SqlParameter("@id", id);

                return await RunExport(query, cultureInfo, parameter);
            }
            catch (Exception e)
            {
                return BadRequest(ResponseOfRequest.NotSuccess(e));
            }
        }

        /// <summary>
        /// реєстр будь-якого звіту
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cultureName"></param>
        /// <returns></returns>
        [HttpGet("DefaultRegister/{id}/{cultureName}")]
        public async Task<IActionResult> ExportDefaultRegisterById(int id, string cultureName)
        {
            try
            {
                CultureInfo cultureInfo = new CultureInfo(cultureName);

                string query = "exec p_Tsk_11_Prt_TurnRegister @id";

                SqlParameter parameter = new SqlParameter("@id", id);

                return await RunExport(query, cultureInfo, parameter);
            }
            catch (Exception e)
            {
                return BadRequest(ResponseOfRequest.NotSuccess(e));
            }
        }

        [HttpPost("OperationDataByPeriod/{cultureName}")]
        public async Task<IActionResult> ExportOperationDataByPeriodDates([FromBody] OperationDataByPeriodResource resource, string cultureName)
        {
            try
            {
                CultureInfo cultureInfo = new CultureInfo(cultureName);

                string query = "exec p_Tsk_11_Prt_TurnPeriod @dateBegin, @dateEnd";

                SqlParameter[] sqlParameters = {
                    new SqlParameter("@dateBegin", resource.DateBegin),
                    new SqlParameter("@dateEnd", resource.DateEnd),
                };

                return await RunExport(query, cultureInfo, sqlParameters);
            }
            catch (Exception e)
            {
                return BadRequest(ResponseOfRequest.NotSuccess(e));
            }
        }

        [HttpGet("RegisterByCustomType/{type}/{cultureName}")]
        public async Task<IActionResult> GetRegisterByCustomType(int type, string cultureName)
        {
            SqlConnection sqlConnection = (SqlConnection) _dbContext.Database.GetDbConnection();

            sqlConnection.Open();
            
            SqlParameter parameter = new SqlParameter("@id", type);

            string internalQuery = "select comment from PrtReestrType where codeI = @id";
            SqlCommand sqlCommand = new SqlCommand(internalQuery, sqlConnection);
            sqlCommand.CommandTimeout = 600;
            sqlCommand.Parameters.Add(parameter);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            string dbInstanceName = dataSet.Tables[0].Rows[0].ItemArray[0].ToString();

            sqlConnection.Close();


            CultureInfo cultureInfo = new CultureInfo(cultureName);

            string query = $"exec {dbInstanceName} ";

            return await RunExport(query, cultureInfo);
        }

        private async Task<FileContentResult> RunExport(string query, CultureInfo cultureInfo, params SqlParameter[] sqlParameters)
        {
            DataTable table;

            using (SqlConnection sqlConnection = (SqlConnection)_dbContext.Database.GetDbConnection())
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.CommandTimeout = 600;
                if (sqlParameters != null)
                {
                    foreach (SqlParameter sqlParameter in sqlParameters)
                    {
                        sqlCommand.Parameters.Add(sqlParameter);
                    }
                }

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);

                table = dataSet.Tables[0];
            }

            FileContentResult fileContentResult = await GetFileContentResult(table, cultureInfo);
            return fileContentResult;
        }

        private static async Task<FileContentResult> GetFileContentResult(DataTable table, CultureInfo cultureInfo)
        {
            string tempFileName = string.Empty;

            try
            {
                string content = ConvertDataTableToCSV(table, cultureInfo);

                tempFileName = Path.GetTempFileName();
                using (StreamWriter streamWriter = new StreamWriter(System.IO.File.OpenWrite(tempFileName), Encoding.UTF8))
                {
                    await streamWriter.WriteAsync(content);
                    await streamWriter.FlushAsync();
                    streamWriter.Close();
                }

                byte[] bytes = await System.IO.File.ReadAllBytesAsync(tempFileName);

                MediaTypeHeaderValue mediaTypeHeaderValue = new MediaTypeHeaderValue(new StringSegment("application/octet-stream"));
                
                return new FileContentResult(bytes, mediaTypeHeaderValue);
            }
            finally
            {
                var fileInfo = new FileInfo(tempFileName);
                if (fileInfo.Exists)
                    fileInfo.Delete();
            }
        }

        private static string ConvertDataTableToCSV(DataTable table, CultureInfo cultureInfo)
        {
            string listSeparator = cultureInfo.TextInfo.ListSeparator;
            string decimalSeparator = cultureInfo.NumberFormat.NumberDecimalSeparator;

            StringBuilder stringBuilder = new StringBuilder();

            string[] tableColumns = table.Columns
                .Cast<DataColumn>()
                .Select(rec => rec.ColumnName)
                .ToArray();

            stringBuilder.AppendLine(string.Join(listSeparator, tableColumns));

            string[] array = new string[table.Columns.Count];
            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    if (row.ItemArray[i] is decimal)
                    {
                        array[i] = row.ItemArray[i].ToString().Replace(".", decimalSeparator);
                    }
                    else if (row.ItemArray[i] is DateTime date)
                    {
                        array[i] = date.ToString("d", cultureInfo);
                    }
                    else
                    {
                        array[i] = row.ItemArray[i].ToString();
                    }
                }

                //string[] fields = row.ItemArray.Select(rec => rec.ToString().Replace(".", decimalSeparator)).ToArray();
                stringBuilder.AppendLine(string.Join(listSeparator, array) + listSeparator);
            }

            return stringBuilder.ToString();
        }
    }
}
