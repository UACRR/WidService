using System;
using System.Collections.ObjectModel;
using System.Linq;
using ipsFormsDesign.Data;

namespace IPSViewComponentLibraryWPF.Modules.TransferOfRights.Model
{
    public class ObjectsRightOfRightholder
    {
        public bool IsSelected { get; set; }

        public int ObjId { get; set; }
        public int CRightId { get; set; }
        public string Name { get; set; }

        public string Category { get; set; }

        private int? _genreType;
        public int? GenreType
        {
            get => _genreType;
            set
            {
                _genreType = value;
                if (IpsGlobal.ObjectRightDictionaries != null)
                {
                    var genre = IpsGlobal.ObjectRightDictionaries.genreType.FirstOrDefault(rec => rec.CodeI == value);
                    GenreName = genre?.Name;
                }
            }
        }

        public string GenreName { get; set; }

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

        public double RateTotal { get; set; }
        public double RatePer { get; set; }
        public double RateMech { get; set; }
        public string Author { get; set; }
        public string Performer { get; set; }

        public ObservableCollection<CopyrightOfObject> CopyrightOfObjectList { get; set; }
    }
}
