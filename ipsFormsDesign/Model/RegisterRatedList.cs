using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RegisterRatedList : IRegisterRatedList
    {
        public RegisterRatedList()
        {
            Distribution = new ObservableListSource<Distribution>();
            Register = new ObservableListSource<Register>();
        }

        public int PeriodId { get; set; }
        public int RmId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Royalty { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UserId { get; set; }
        public int? Status { get; set; }
        public int? CntReport { get; set; }
        public decimal? PaidAmount { get; set; }

        public PaidPeriod Period { get; set; }
        public RegisterListStatus StatusNavigation { get; set; }
        public ObservableListSource<Distribution> Distribution { get; set; }
        public ObservableListSource<Register> Register { get; set; }
    }
}

