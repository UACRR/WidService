using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Data;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.Model
{
    public class RegisterModel : ViewModelBase
    {
        public int RegId { get; set; }
        public int? RmId { get; set; }
        public string Number { get; set; }
        public string FileName { get; set; }

        private int? _rgStatus;
        public int? RgStatus
        {
            get => _rgStatus;
            set
            {
                _rgStatus = value;
                var registerStatus = IpsGlobal.AnketaDictionaties?.registerStatus.FirstOrDefault(rec => rec.CodeI == value);
                RgStatusName = registerStatus?.Name;
            }
        }

        public string RgStatusName { get; set; }

        public int CountRows { get; set; }
        public decimal? RegAmount { get; set; }
        public decimal? RegRate { get; set; }
        public decimal? RegRoyalty { get; set; }

        private ipsFormsDesign.Model.Register _register;
        public ipsFormsDesign.Model.Register Register
        {
            get => _register;
            set
            {
                _register = value;
                ResetData();
            }
        }

        private void ResetData()
        {
            RegId = _register.RegId;
            RmId = _register.RmId;
            Number = _register.Number;
            FileName = _register.FileName;
            RgStatus = _register.RgStatus;
            CountRows = _register.CountRows;
            RegAmount = _register.RegAmount;
            RegRate = _register.RegRate;
            RegRoyalty = _register.RegRoyalty;
        }
    }
}
