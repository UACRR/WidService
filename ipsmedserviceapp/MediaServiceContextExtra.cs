using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ipsmedserviceapp.Controllers;
using ipsmedserviceapp.Model.SQLViewsData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ipsmedserviceapp.Model
{
    public partial class MediaServiceContext : DbContext
    {
        // mapped to vTsk_1_ListRightHolder01
        public DbQuery<RightholderMainView> RightholderMainView { get; set; }
        public DbQuery<vCustomer> vCustomer { get; set; }
        public DbQuery<FtTsk1ListRightHolder01> FtTsk1ListRightHolder01 { get; set; }

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
        ///  Сінхронізація двух списків з визовом createNew для кожного нового елемента
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sors">SorsList</param>
        /// <param name="dest">DestList</param>
        /// <param name="syncItem">визовом createNew для кожного нового елемента(bool, sorsItem, DestItem)
        /// bool - true - Додається новий елемент
        /// bool - false - Модифікується існуючий елемент
        /// 
        /// </param>
        /// <param name="compId"></param>
        /// <param name="excludeField"></param>
        public void UpdateListExtra<T>(ICollection<T> sors, ICollection<T> dest, Action<bool, T,T> syncItem, Func<T, T, bool> compId, string[] excludeField = null) where T : class, new()
        {
            // Видалення
            List<T> tempList = dest.Where(row => !sors.Any(item => compId(row, item))).ToList();
            tempList.ForEach(item => { Entry(item).State = EntityState.Deleted; dest.Remove(item); });
            // Змінюємо спільні записи
            tempList = sors.Where(row => dest.Any(item => compId(row, item))).ToList();
            tempList.ForEach(item => {
                var destItem = dest.First(row => compId(item, row));
                destItem.SetFields( item );
                syncItem(false, item, destItem);
            });
            // Додаємо нові
            tempList = sors.Where(row => !dest.Any(item => compId(row, item))).ToList();
            tempList.ForEach(item => {
                T addItem = new T();
                addItem.SetFields(item, excludeField);
                dest.Add(addItem);
                syncItem( true, item,  addItem);
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
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sors"></param>
        /// <param name="dest"></param>
        /// <param name="syncItem">Action Виконується для кожного елементу
        /// bool true - додавання нового елементу
        ///      false - модифікація поточного елементу
        /// другий параметр - SorsItem     
        /// третій параметр - DestItem     
        /// </param>
        /// <param name="compId"></param>
        public void AppendListExtra<T>(ICollection<T> sors, ICollection<T> dest, Action<bool,T,T> syncItem, Func<T, T, bool> compId, string[] excludeField = null) where T : class, new()
        {
            // Змінюємо спільні записи
            List<T> tempList = sors.Where(row => dest.Any(item => compId(row, item))).ToList();
            tempList.ForEach(sorsItem => {
                var destItem = dest.First(row => compId(sorsItem, row));
                destItem.SetFields(sorsItem, excludeField);
                syncItem(false, sorsItem, destItem);
            });
            // Додаємо нові
            tempList = sors.Where(row => !dest.Any(item => compId(row, item))).ToList();
            tempList.ForEach(item =>
            {
                T addItem = new T();
                addItem.SetFields(item, excludeField);
                dest.Add(addItem);
                syncItem(true, item, addItem);
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
        public void AppendList<T>(ICollection<T> sors, ICollection<T> dest, Action<T,T> copyBody, Func<T, T, bool> compId, string[] excludeField = null) where T : class, new()
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
                copyBody(item, addItem);
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
                        foreach (var p in param)
                        {
                            if (p.Value == null)
                                p.Value = DBNull.Value;

                            comm.Parameters.Add(p);
                        }
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
