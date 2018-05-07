using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Definition;
using ipsFormsDesign.Interfaces;
using ipsmedserviceapp.Model;
using WebAPIConnector;

namespace ipsAnketaRightHolder
{
    public partial class AnketaCompanyView : Telerik.WinControls.UI.RadForm//, IFormCompany
    {
        
        private Customer _data;
        private AnketaCompany _curAnketa;

        public AnketaCompanyView()
        {
            InitializeComponent();
        }

        public IAnketaCompany AnketaCompany { get => _curAnketa; }

        public int CustId { get => _data.CustId; set => _data.CustId = value; }
        public int? CustType { get => _data.CustType; set => _data.CustType = value; }
        public int Status { get => _data.Status; set => _data.Status = value; }
        public int? AnkVersion { get => _data.AnkVersion; set => _data.AnkVersion = value; }
        public byte? AnkMy { get => _data.AnkMy; set => _data.AnkMy = value; }
        public byte? AnkPublish { get => _data.AnkPublish; set => _data.AnkPublish = value; }
        public byte? AnkTech { get => _data.AnkTech; set => _data.AnkTech = value; }

        public event EventHandler FieldsValueChanged;

        public void SetData(Customer data)
        {
            _data = data;
            _curAnketa = _data.AnketaCompany.Where(row => row.Version == _data.AnkVersion).SingleOrDefault();
            if (_curAnketa == null)
            {
                _curAnketa = new AnketaCompany { Version = _data.AnkVersion ?? 1 };
                _data.AnketaCompany.Add(_curAnketa);
                _data.AnkVersion = _curAnketa.Version;
            }
        }
    }
}
