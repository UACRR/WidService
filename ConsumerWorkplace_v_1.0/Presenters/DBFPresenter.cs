using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
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

        public List<ExternalPay> GetListUnlinkPays()
        {
            return _service.GetUnlinkPays();
        }

        public InputFile CheckInputFile( InputFile newFile )
        {
            var retFile = _service.CheckInputFile( newFile );
            newFile.FileId = retFile.FileId;
            newFile.CheckParamPays.Clear();

            foreach (var item in retFile.CheckParamPays)
                newFile.CheckParamPays.Add(item);

            return newFile;
        }

        public InputFile SaveInputFile( InputFile file )
        {
            var retFile = _service.SaveInputFile(file);
            return retFile;
        }


        public ExternalPay SaveLinkedPay( ExternalPay pay )
        {
            return _service.SaveLinkedPay( pay );
        }

        public List<ExternalPay> SaveListPays( List<ExternalPay> list )
        {
            return _service.SaveListLinkedPays( list );
        }

    }
}
