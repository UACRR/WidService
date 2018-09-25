using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class BrRegister : IBrRegister
    {
        public BrRegister()
        {
            BrRegItem = new ObservableListSource<BrRegItem>();
            Distribution = new ObservableListSource<Distribution>();
        }

        public int regId { get; set; }
        public int? periodId { get; set; }
        public int? custId { get; set; }
        public DateTime? createDate { get; set; }
        public decimal? fullAmount { get; set; }
        public decimal? rAmount { get; set; }
        public int? status { get; set; }
        public string fileName { get; set; }
        public string userId { get; set; }

        public Client cust { get; set; }
        public PaidPeriod period { get; set; }
        public RegisterStatus statusNavigation { get; set; }
        public AspNetUsers user { get; set; }
        public ObservableListSource<BrRegItem> BrRegItem { get; set; }
        public ObservableListSource<Distribution> Distribution { get; set; }
    }
}

