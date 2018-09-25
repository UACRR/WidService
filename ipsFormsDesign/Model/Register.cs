using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Register : IRegister
    {
        public Register()
        {
            BrRegItem = new ObservableListSource<BrRegItem>();
            Distribution = new ObservableListSource<Distribution>();
            RegisterItem = new ObservableListSource<RegisterItem>();
        }

        public int regId { get; set; }
        public int rmId { get; set; }
        public string number { get; set; }
        public int countRows { get; set; }
        public int custId { get; set; }
        public DateTime? createDate { get; set; }
        public int durationticks { get; set; }
        public int? rgStatus { get; set; }
        public string fileName { get; set; }
        public string userId { get; set; }
        public int? periodId { get; set; }
        public decimal? regAmount { get; set; }
        public decimal? regRate { get; set; }
        public decimal? regRoyalty { get; set; }
        public decimal? musicAmount { get; set; }
        public decimal? musicRate { get; set; }
        public decimal? authAmount { get; set; }
        public decimal? authRate { get; set; }
        public decimal? paidAmount { get; set; }
        public int licId { get; set; }
        public int? schemaId { get; set; }
        public int? algorithmId { get; set; }

        public AlgorithmType algorithm { get; set; }
        public Client cust { get; set; }
        public RegisterStatus rgStatusNavigation { get; set; }
        public RegisterRatedList rm { get; set; }
        public AspNetUsers user { get; set; }
        public ObservableListSource<BrRegItem> BrRegItem { get; set; }
        public ObservableListSource<Distribution> Distribution { get; set; }
        public ObservableListSource<RegisterItem> RegisterItem { get; set; }
    }
}

