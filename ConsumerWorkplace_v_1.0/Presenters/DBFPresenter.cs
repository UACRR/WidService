using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsmedserviceapp.Model.SQLViewsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerWorkplace_v_1._0.Presenters
{
    public class DBFPresenter : IDBFPresenter
    {
        private DbfService _service;

        public DBFPresenter()
        {
            _service = new DbfService();
        }

        /// <summary>
        /// Отримати список неприв'язаних платежів
        /// </summary>
        /// <returns></returns>
        public List<ExternalPay> GetListUnlinkPays()
        {
            return _service.GetUnlinkPays();
        }

        /// <summary>
        /// Перевірити InputFile на дублі та на автоматичну прив'язку платежів до користувачів
        /// </summary>
        /// <param name="newFile"></param>
        /// <returns></returns>
        public InputFile CheckInputFile( InputFile newFile )
        {
            var retFile = _service.CheckInputFile( newFile );
            newFile.FileId = retFile.FileId;
            newFile.CheckParamPays.Clear();

            foreach (var item in retFile.CheckParamPays)
                newFile.CheckParamPays.Add(item);

            return newFile;
        }
        /// <summary>
        /// Збереження InputFile в БД
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public InputFile SaveInputFile( InputFile file )
        {
            var retFile = _service.SaveInputFile(file);
            return retFile;
        }

        /// <summary>
        /// Збереження одного привязаного до Споживача платежа
        /// </summary>
        /// <param name="pay"></param>
        /// <returns></returns>
        public ExternalPay SaveLinkedPay( ExternalPay pay )
        {
            return _service.SaveLinkedPay( pay );
        }
        /// <summary>
        /// Збереження списка прив'язаних до Споживачів платежів
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<ExternalPay> SaveListPays( List<ExternalPay> list )
        {
            return _service.SaveListLinkedPays( list );
        }
        /// <summary>
        /// Видалення непідтвердженого файлу
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public bool DeleteInputFile(InputFile file)
        {
            return _service.DeleteInputFile(file);
        }
        /// <summary>
        /// Отримати список Споживачів у яких є договори
        /// </summary>
        /// <returns></returns>
        public List<vCustomer> getConsumers()
        {
            return _service.getListOfConsumers();
        }
    }
}
