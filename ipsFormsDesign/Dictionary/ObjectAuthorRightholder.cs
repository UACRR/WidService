using System;
using System.Collections.Generic;
using System.Text;

namespace ipsFormsDesign.Dictionary
{
    public class ObjectAuthorRightholder
    {
        public int AuthId { get; set; }
        public int ObjId { get; set; }
        public int RoleCode { get; set; }
        public int? FolkType { get; set; }
        public string AuthorName { get; set; }
        public bool IsRightholder { get; set; }
        public int CustId { get; set; }
        public int CopyrightStatus { get; set; }
        public int StatusZayavky { get; set; }
        public string CommunityName { get; set; }
        public decimal Rate { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
