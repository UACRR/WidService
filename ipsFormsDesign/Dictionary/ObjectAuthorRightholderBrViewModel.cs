using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.Dictionary
{
    public class ObjectAuthorRightholderBrViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string InnerCode { get; set; }
        public string Country { get; set; }
        public Authors Author { get; set; }
        public CopyRight CopyRight { get; set; }
        public WorkRh WorkRh { get; set; }
        public LicAuthorBr LicAuthorBr { get; set; }

        private bool _isRightholder;
        public bool IsRightholder
        {
            get { return _isRightholder; }
            set
            {
                _isRightholder = value;
                OnPropertyChanged(nameof(IsRightholder));

                if (!_isRightholder)
                {
                    ClearRightholderData();
                }
            }
        }

        private void ClearRightholderData()
        {
            Author.CustId = null;
            CopyRight.RoleRate = null;
            WorkRh.WorkTypeRh = null;
            WorkRh.WorkTypeCl = null;
            LicAuthorBr.R030 = null;
            LicAuthorBr.PrepayType = null;
            LicAuthorBr.PrepaySum = null;
            Country = null;
            InnerCode = null;
        }

        public ObjectAuthorRightholderBrViewModel()
        {
            Author = new Authors();
            CopyRight = new CopyRight();
            LicAuthorBr = new LicAuthorBr();
            WorkRh = new WorkRh();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
