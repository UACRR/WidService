using ipsFormsDesign.Interfaces;
using System;
using System.ComponentModel;

namespace ipsFormsDesign.Dictionary
{
    public class ObjectAuthorRightholder : EditableObjectBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public int AuthId { get; set; }
        public int ObjId { get; set; }
        public int RoleCode { get; set; }
        public string AuthorName { get; set; }
        public int? CustId { get; set; }
        public int? CRightId { get; set; }
        public int? CopyrightStatus { get; set; }
        public int? StatusZayavky { get; set; }
        public string CommunityName { get; set; }

        private decimal? _rate;
        public decimal? Rate
        {
            get { return _rate; }
            set
            {
                _rate = value;
                OnPropertyChanged(nameof(Rate));
            }
        }

        private DateTime? _beginDate;
        public DateTime? BeginDate
        {
            get { return _beginDate; }
            set
            {
                _beginDate = value;
                OnPropertyChanged(nameof(BeginDate));
            }
        }

        private DateTime? _endDate;
        public DateTime? EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        private int? _folkType;
        public int? FolkType
        {
            get { return _folkType; }
            set
            {
                if (_folkType != value)
                {
                    _folkType = value;
                    OnPropertyChanged(nameof(FolkType));

                    if (_folkType == 1 && !IsRightholder)
                    {
                        ClearRightholderData();
                    }
                    else if (_folkType == 2)
                    {
                        ClearRightholderData();
                    }
                    else if (_folkType == 3)
                    {
                        AuthorName = "Народне";
                        ClearRightholderData();
                    }
                }
            }
        }

        private bool _isRightholder;
        public bool IsRightholder
        {
            get { return _isRightholder; }
            set
            {
                if (_isRightholder != value)
                {
                    _isRightholder = value;
                    OnPropertyChanged(nameof(IsRightholder));

                    if (!_isRightholder)
                    {
                        ClearRightholderData();
                    }
                    else
                    {
                        BeginDate = DateTime.Now;
                        EndDate = new DateTime(3000,1,1);
                    }
                }
            }
        }

        public ObjectAuthorRightholder()
        {
            _folkType = 1;
        }

        public ObjectAuthorRightholder(RightholderMainView defaultRightholder) : this()
        {
            if (defaultRightholder != null)
            {
                IsRightholder = true;
                AuthorName = defaultRightholder.Name;
                CustId = defaultRightholder.CustId;
                CommunityName = defaultRightholder.Community_Name;
            }
        }

        private void ClearRightholderData()
        {
            IsRightholder = false;
            CustId = null;
            CopyrightStatus = null;
            StatusZayavky = null;
            CommunityName = "";
            Rate = null;
            BeginDate = null;
            EndDate = null;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
