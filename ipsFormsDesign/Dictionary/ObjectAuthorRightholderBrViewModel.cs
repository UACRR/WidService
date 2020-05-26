using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Diagrams.Core;

namespace ipsFormsDesign.Dictionary
{
    public class ObjectAuthorRightholderBrViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObjectAuthorRightholderBrViewModel()
        {
            Author = new Authors();
            CopyRight = new CopyRight();
            LicAuthorBr = new List<LicAuthorBr>();
            WorkRh = new WorkRh();
        }

        public string InnerCode { get; set; }
        public string Country { get; set; }
        public Authors Author { get; set; }
        public CopyRight CopyRight { get; set; }
        public WorkRh WorkRh { get; set; }
        public ICollection<LicAuthorBr> LicAuthorBr { get; set; }

        private bool _isRightholder;
        public bool IsRightholder
        {
            get => _isRightholder;
            set
            {
                _isRightholder = value;

                if (!_isRightholder)
                {
                    ClearRightholderData();
                }

                OnPropertyChanged(nameof(IsRightholder));
            }
        }

        private void ClearRightholderData()
        {
            Author.CustId = null;
            CopyRight.RoleRate = null;
            WorkRh.WorkTypeRh = null;
            WorkRh.WorkTypeCl = null;
            Country = null;
            InnerCode = null;

            LicAuthorBr?.ForEach((item) =>
            {
                item.R030 = null;
                item.PrepayType = null;
                item.PrepaySum = null;
            });
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
