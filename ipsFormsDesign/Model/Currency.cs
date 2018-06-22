using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Currency : ICurrency
    {
        public Currency()
        {
            Account = new ObservableListSource<Account>();
        }

        public string R030 { get; set; }
        public string A3 { get; set; }
        public string CountryCode { get; set; }
        public string R030NameEn { get; set; }
        public string R030NameRu { get; set; }
        public string R030NameUk { get; set; }
        public int? NOmin { get; set; }
        public string NAim { get; set; }
        public short? PrWork { get; set; }
        public short? PrNc { get; set; }
        public int? OrderBy { get; set; }

        public ObservableListSource<Account> Account { get; set; }
    }
}

