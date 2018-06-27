using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ipsmedserviceapp.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ipsmedserviceapp.Model
{
    public partial class MediaServiceContext : DbContext
    {
        public MediaServiceContext(DbContextOptions<MediaServiceContext> options) : base(options)
        {
        }

        public void UpdateList<T>(ICollection<T> sors, ICollection<T> dest, Action<T> maxId, Func<T, T, bool> compId, string[] excludeField = null) where T : class, new()
        {
            // Видалення
            List<T> tempList = dest.Where(row => !sors.Any(item => compId(row, item))).ToList();
            tempList.ForEach(item => { Entry(item).State = EntityState.Deleted; dest.Remove(item); });
            // Змінюємо спільні записи
            tempList = sors.Where(row => dest.Any(item => compId(row, item))).ToList();
            tempList.ForEach(item => dest.First(row => compId(item, row)).SetFields(item));
            // Додаємо нові
            tempList = sors.Where(row => !dest.Any(item => compId(row, item))).ToList();
            tempList.ForEach(item => {
                T addItem = new T();
                addItem.SetFields(item, excludeField);
                dest.Add(addItem);
                maxId(addItem);
            });

        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sors"></param>
        /// <param name="dest"></param>
        /// <param name="maxId"></param>
        /// <param name="compId"></param>
        public void AppendList<T>(ICollection<T> sors, ICollection<T> dest, Action<T> maxId, Func<T, T, bool> compId, string[] excludeField = null) where T : class, new()
        {
            // Змінюємо спільні записи
            List<T> tempList = sors.Where(row => dest.Any(item => compId(row, item))).ToList();
            tempList.ForEach(item => dest.First(row => compId(item, row)).SetFields(item, excludeField));            
            // Додаємо нові
            tempList = sors.Where(row => !dest.Any(item => compId(row, item))).ToList();
            tempList.ForEach(item =>
            {
                T addItem = new T();
                addItem.SetFields(item, excludeField);
                dest.Add(addItem);
                maxId(addItem);
            });


        }


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
