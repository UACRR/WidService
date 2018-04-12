namespace ipsmedserviceapp.Model
{
    public partial class MediaServiceContext : DbContext
    {

        /// <summary>
        /// Raw Запрос данных из базы данных
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<List<Dictionary<string, object>>> getViewData(string sqlCommand, SqlParameter[] param)
        {
            List<Dictionary<string, object>> vActiveOrders = null;

            var connection = this.Database.GetDbConnection();

            try
            {
                await connection.OpenAsync();
                using (var comm = connection.CreateCommand())
                {
                    comm.CommandText = sqlCommand;
                    if (param != null && param.Length > 0)
                    {
                        comm.Parameters.AddRange(param);
                    }

                    var reader = await comm.ExecuteReaderAsync();
                    vActiveOrders = reader.Cast<DbDataRecord>().Select(rec =>
                    {
                        Dictionary<string, object> item = new Dictionary<string, object>();
                        for (int i = 0; i < rec.FieldCount; i++)
                        {
                            object value = null;
                            if (!rec.IsDBNull(i))
                            {
                                value = rec.GetValue(i);
                            }
                            item.Add(rec.GetName(i), value);
                        }
                        return item;
                    }).ToList();
                }
            }
            finally
            {
                connection.Close();
            }

            return vActiveOrders;
        }
    }
}
