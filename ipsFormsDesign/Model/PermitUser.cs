using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PermitUser : IPermitUser
    {
        public PermitUser()
        {
            PermitUserRole = new ObservableListSource<PermitUserRole>();
        }

        public int CodeI { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] PasswordHash { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public short? IsLock { get; set; }
        public string Comment { get; set; }
        public bool? IsTempPassword { get; set; }

        public virtual ObservableListSource<PermitUserRole> PermitUserRole { get; set; }
    }
}

