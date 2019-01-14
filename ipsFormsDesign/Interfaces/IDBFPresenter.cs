using ipsFormsDesign.Model;
using ipsmedserviceapp.Model.SQLViewsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.Interfaces
{
    public interface IDBFPresenter
    {
        /// <summary>
        /// Отримати список неприв'язаних платежів
        /// </summary>
        /// <returns></returns>
        List<ExternalPay> GetListUnlinkPays();

        /// <summary>
        /// Перевірити InputFile на дублі та на автоматичну прив'язку платежів до користувачів
        /// </summary>
        /// <param name="newFile"></param>
        /// <returns></returns>
        InputFile CheckInputFile(InputFile newFile);
        /// <summary>
        /// Збереження InputFile в БД
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        InputFile SaveInputFile(InputFile file);
        /// <summary>
        /// Збереження одного привязаного до Споживача платежа
        /// </summary>
        /// <param name="pay"></param>
        /// <returns></returns>
        ExternalPay SaveLinkedPay(ExternalPay pay);
        /// <summary>
        /// Збереження списка прив'язаних до Споживачів платежів
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        List<ExternalPay> SaveListPays(List<ExternalPay> list);
        /// <summary>
        /// Видалення непідтвердженого файлу
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        bool DeleteInputFile(InputFile file);
        /// <summary>
        /// Отримати список Споживачів, які можна прив'язати до платежа
        /// </summary>
        /// <returns></returns>
        List<vCustomer> getConsumers();
    }
}
