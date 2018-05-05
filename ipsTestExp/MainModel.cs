using ipsFormsDesign.Definition;
using ipsFormsDesign.Interfaces;
using ipsmedserviceapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsTestExp
{
    class MainModel : IModelCompany
    {
        public IAnketaCompany AnketaCompany => throw new NotImplementedException();

        public int CustId {get;set;}
        public int? CustType {get;set;}
        public int Status {get;set;}
        public int? AnkVersion {get;set;}
        public byte? AnkMy {get;set;}
        public byte? AnkPublish {get;set;}
        public byte? AnkTech {get;set;}

        public void FieldChanging(object sender, EventArgs e)
        {
            string NameProperty = sender.GetType().GetProperty("Name").GetValue(sender).ToString();
            string Text = sender.GetType().GetProperty("Text").GetValue(sender).ToString();
        }

        private Customer _data;
        private AnketaCompany _anketa;
        public void SetData(Customer data)
        {
            _data = data;
            _anketa = _data.AnketaCompany.Where(item => item.Version == _data.AnkVersion).SingleOrDefault();
        }
    }
}
