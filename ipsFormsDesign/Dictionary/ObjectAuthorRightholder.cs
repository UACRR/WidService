using System;

namespace ipsFormsDesign.Dictionary
{
    public class ObjectAuthorRightholder : EditableObjectBase
    {
        public int AuthId { get; set; }
        public int ObjId { get; set; }
        public int RoleCode { get; set; }
        public string AuthorName { get; set; }
        public int? CustId { get; set; }
        public int? CopyrightStatus { get; set; }
        public int? StatusZayavky { get; set; }
        public string CommunityName { get; set; }
        public decimal? Rate { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }

        private int? _folkType;
        public int? FolkType
        {
            get { return _folkType; }
            set
            {
                if (_folkType != value)
                {
                    _folkType = value;

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
                    
                    if (!_isRightholder)
                    {
                        ClearRightholderData();
                    }
                }
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
    }
}
