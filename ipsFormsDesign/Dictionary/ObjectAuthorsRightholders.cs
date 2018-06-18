using System;
using System.Collections.Generic;
using System.Text;

namespace ipsFormsDesign.Dictionary
{
    public class ObjectAuthorsRightholders
    {
        public int AuthId { get; set; }
        public int ObjId { get; set; }
        public int RoleCode { get; set; }
        public string AuthorName { get; set; }
        public int CopyrightStatus { get; set; }
        //public int StatusZayavky { get; set; } // сформована заявка чи ні
        public int CommunityId { get; set; }
        public decimal Rate { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
