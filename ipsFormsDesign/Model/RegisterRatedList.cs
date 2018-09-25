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

        public int periodId { get; set; }
        public int rmId { get; set; }
        public decimal? amount { get; set; }
        public decimal? royalty { get; set; }
        public DateTime? createDate { get; set; }
        public string userId { get; set; }
        public int? status { get; set; }
        public int? cntReport { get; set; }
        public decimal? paidAmount { get; set; }

        public PaidPeriod period { get; set; }
        public RegisterListStatus statusNavigation { get; set; }
        public ObservableListSource<Distribution> Distribution { get; set; }
        public ObservableListSource<Register> Register { get; set; }
    }
}

