using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Data;

namespace IPSViewComponentLibraryWPF.Modules.TransferOfRights.Model
{
    public class CopyrightOfObject
    {
        public int ObjId { get; set; }
        public string Name { get; set; }
        public int CRightId { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double RatePer { get; set; }
        public double RateMech { get; set; }

        private int _roleCode;
        public int RoleCode
        {
            get => _roleCode;
            set
            {
                _roleCode = value;
                if (IpsGlobal.ObjectRightDictionaries != null)
                {
                    var role = IpsGlobal.ObjectRightDictionaries.creativeRoleType.FirstOrDefault(rec => rec.CodeI == value);
                    RoleName = role?.Name;
                }
            }
        }

        public string RoleName { get; set; }

        private int _status;
        public int Status
        {
            get => _status;
            set
            {
                _status = value;
                if (IpsGlobal.ObjectRightDictionaries != null)
                {
                    // TODO: include dictionary  CRightStatus
                    //var status = IpsGlobal.ObjectRightDictionaries.CRightStatus
                }
                StatusName = value == 0 ? "Не підтверджено" : value == 1 ? "Підтверджено" : string.Empty;
            }
        }

        public string StatusName { get; set; }
    }
}
