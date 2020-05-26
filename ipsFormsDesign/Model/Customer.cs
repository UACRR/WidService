using ipsFormsDesign.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Customer : ICustomer
    {
        public Customer()
        {
            Account = new ObservableListSource<Account>();
            AgreementMaster = new ObservableListSource<AgreementMaster>();
            AnketaAddName = new ObservableListSource<AnketaAddName>();
            AnketaAddParam = new ObservableListSource<AnketaAddParam>();
            AnketaCompany = new ObservableListSource<AnketaCompany>();
            AnketaPerson = new ObservableListSource<AnketaPerson>();
            BankAccount = new ObservableListSource<BankAccount>();
            Employee = new ObservableListSource<Employee>();
            FileCustomer = new ObservableListSource<FileCustomer>();
            ReqAgreement = new ObservableListSource<ReqAgreement>();
            ReqCustomer = new ObservableListSource<ReqCustomer>();
            Request = new ObservableListSource<Request>();
            UserRole = new ObservableListSource<UserRole>();
        }

        public int CustId { get; set; }
        public int? CustType { get; set; }
        public int Status { get; set; }
        public int? AnkVersion { get; set; }
        public byte? AnkMy { get; set; }
        public byte? AnkPublish { get; set; }
        public byte? AnkTech { get; set; }
        public string UserId { get; set; }
        public int? LoadId { get; set; }
        public DateTime? DateCreate { get; set; }
        public string CreateLogin { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyLogin { get; set; }

        [JsonIgnore]
        public virtual CustomerType CustTypeNavigation { get; set; }
        [JsonIgnore]
        public virtual CustomerStatus StatusNavigation { get; set; }
        [JsonIgnore]
        public virtual AspNetUsers User { get; set; }
        public virtual AnketaExternal AnketaExternal { get; set; }
        public virtual Client Client { get; set; }
        public virtual Community Community { get; set; }
        public virtual Company Company { get; set; }
        [JsonIgnore]
        public virtual MyAnketa MyAnketa { get; set; }
        public virtual Partner Partner { get; set; }
        public virtual Person Person { get; set; }
        public virtual RightHolder RightHolder { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<Account> Account { get; set; }
        public virtual ObservableListSource<AgreementMaster> AgreementMaster { get; set; }
        public virtual ObservableListSource<AnketaAddName> AnketaAddName { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<AnketaAddParam> AnketaAddParam { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<AnketaCompany> AnketaCompany { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<AnketaPerson> AnketaPerson { get; set; }
        public virtual ObservableListSource<BankAccount> BankAccount { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<Employee> Employee { get; set; }
        public virtual ObservableListSource<FileCustomer> FileCustomer { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<ReqAgreement> ReqAgreement { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<ReqCustomer> ReqCustomer { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<Request> Request { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<UserRole> UserRole { get; set; }
    }
}



