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

        public int RegId { get; set; }
        public int RmId { get; set; }
        public string Number { get; set; }
        public int CountRows { get; set; }
        public int CustId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Durationticks { get; set; }
        public int? RgStatus { get; set; }
        public string FileName { get; set; }
        public string UserId { get; set; }
        public int? PeriodId { get; set; }
        public decimal? RegAmount { get; set; }
        public decimal? RegRate { get; set; }
        public decimal? RegRoyalty { get; set; }
        public decimal? MusicAmount { get; set; }
        public decimal? MusicRate { get; set; }
        public decimal? AuthAmount { get; set; }
        public decimal? AuthRate { get; set; }
        public decimal? PaidAmount { get; set; }
        public int? LicId { get; set; }
        public int? SchemaId { get; set; }
        public int? AlgorithmId { get; set; }

        public Client Cust { get; set; }
        public RegisterRatedList RegisterRatedList { get; set; }
        public RegisterStatus RgStatusNavigation { get; set; }
        public AspNetUsers User { get; set; }
        public ObservableListSource<BrRegItem> BrRegItem { get; set; }
        public ObservableListSource<Distribution> Distribution { get; set; }
        public ObservableListSource<RegisterItem> RegisterItem { get; set; }
    }
}

