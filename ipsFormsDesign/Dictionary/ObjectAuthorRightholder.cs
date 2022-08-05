using ipsFormsDesign.Interfaces;
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace ipsFormsDesign.Dictionary
{
    public class ObjectAuthorRightholder : EditableObjectBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public int AuthId { get; set; }
        public int ObjId { get; set; }
        public int RoleCode { get; set; }
        public string AuthorName { get; set; } = string.Empty;

        public int? CustId { get; set; }
        public int? CRightId { get; set; }
        public int CopyrightStatus { get; set; }
        public string CommunityName { get; set; }
        public DateTime? ValidUntilCommunityDate { get; set; }

        private decimal _rate;
        public decimal Rate
        {
            get => _rate;
            set
            {
                _rate = value;
                OnPropertyChanged(nameof(Rate));
            }
        }

        private decimal _rateMech;

        public decimal RateMech
        {
            get => _rateMech;
            set
            {
                _rateMech = value;
                OnPropertyChanged(nameof(RateMech));
            }
        }

        private DateTime? _beginDate;
        public DateTime? BeginDate
        {
            get => _beginDate;
            set
            {
                _beginDate = value;
                OnPropertyChanged(nameof(BeginDate));
            }
        }

        private DateTime? _endDate;
        public DateTime? EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        private int? _folkType;
        public int? FolkType
        {
            get => _folkType;
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
                        ClearRightholderData();
                        AuthorName = "Народне";
                    }
                }
            }
        }

        private bool _isRightholder;
        public bool IsRightholder
        {
            get => _isRightholder;
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
                        OldAuthorName = AuthorName;
                        AuthorName = "";
                        BeginDate = DateTime.Now;
                        EndDate = new DateTime(3000,1,1);
                    }
                }
            }
        }

        public string OldAuthorName { get; private set; }

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
            }
        }

        private void ClearRightholderData()
        {
            IsRightholder = false;
            CustId = null;
            CopyrightStatus = 0;
            Rate = 0m;
            BeginDate = null;
            EndDate = null;
            AuthorName = string.Empty;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
