using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ObjectRight
    {
        public ObjectRight()
        {
            Account = new HashSet<Account>();
            LicenseBigR = new HashSet<LicenseBigR>();
            PortalObjectRights = new HashSet<PortalObjectRights>();
            RegisterItem = new HashSet<RegisterItem>();
            RelObjGenre = new HashSet<RelObjGenre>();
            Request = new HashSet<Request>();
            SeekObject = new HashSet<SeekObject>();
        }

        public int CategoryCode { get; set; }
        public int ObjId { get; set; }
        public int? ReqId { get; set; }
        public int? ObjType { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Performer { get; set; }
        public int? Status { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyLogin { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ObjImg { get; set; }
        public int? Loadid { get; set; }

        public ObjectType ObjectType { get; set; }
        public ObjectStatus StatusNavigation { get; set; }
        public MediaTrack MediaTrack { get; set; }
        public ICollection<Account> Account { get; set; }
        public ICollection<LicenseBigR> LicenseBigR { get; set; }
        public ICollection<PortalObjectRights> PortalObjectRights { get; set; }
        public ICollection<RegisterItem> RegisterItem { get; set; }
        public ICollection<RelObjGenre> RelObjGenre { get; set; }
        public ICollection<Request> Request { get; set; }
        public ICollection<SeekObject> SeekObject { get; set; }
    }
}
