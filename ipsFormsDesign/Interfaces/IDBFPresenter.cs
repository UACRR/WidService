using ipsFormsDesign.Model;
using System.Collections.Generic;

namespace ipsFormsDesign.Interfaces
{
    public interface IDBFPresenter
    {
        /// <summary>
        /// Отримати список неприв'язаних платежів з серверу
        /// </summary>
        /// <returns>Список неприв'язаних пплатежів</returns>
        List<ExternalPay> GetListUnlinkPays();

        /// <summary>
        /// Завантаження файлу на сервер, перевірка на дублі та повернення результату
        /// </summary>
        /// <param name="newFile">Файл для завантаження</param>
        /// <returns>Завантажений файл</returns>
        InputFile CheckInputFile(InputFile newFile);

        /// <summary>
        /// Збереження перевіреного файлу (підтвердження перевірки)
        /// </summary>
        /// <param name="file">Файл для збереження</param>
        /// <returns>Збережений файл</returns>
        InputFile SaveInputFile(InputFile file);

        /// <summary>
        /// Зберегти прив'язку платежа до клієнта
        /// </summary>
        /// <param name="pay">Платіж для прив'язки до клієнта</param>
        /// <returns>Прив'язаний платіж до клієнта</returns>
        ExternalPay SaveLinkedPay(ExternalPay pay);

        List<ExternalPay> SaveListPays(List<ExternalPay> list);
    }
}
