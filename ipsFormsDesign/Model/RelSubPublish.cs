using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelSubPublish : IRelSubPublish
    {
        public int CustIdPub { get; set; }
        public int CustIdSub { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        public virtual RightHolder CustIdPubNavigation { get; set; }
        public virtual RightHolder CustIdSubNavigation { get; set; }
    }
}

