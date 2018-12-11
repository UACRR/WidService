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

        [JsonIgnore]
        public CustomerType CustTypeNavigation { get; set; }
        [JsonIgnore]
        public CustomerStatus StatusNavigation { get; set; }
        public AnketaExternal AnketaExternal { get; set; }
        public Client Client { get; set; }
        public Community Community { get; set; }
        public Company Company { get; set; }
        [JsonIgnore]
        public MyAnketa MyAnketa { get; set; }
        public Partner Partner { get; set; }
        public Person Person { get; set; }
        public RightHolder RightHolder { get; set; }
        [JsonIgnore]
        public ObservableListSource<Account> Account { get; set; }
        public ObservableListSource<AgreementMaster> AgreementMaster { get; set; }
        public ObservableListSource<AnketaAddName> AnketaAddName { get; set; }
        [JsonIgnore]
        public ObservableListSource<AnketaAddParam> AnketaAddParam { get; set; }
        [JsonIgnore]
        public ObservableListSource<AnketaCompany> AnketaCompany { get; set; }
        [JsonIgnore]
        public ObservableListSource<AnketaPerson> AnketaPerson { get; set; }
        public ObservableListSource<BankAccount> BankAccount { get; set; }
        [JsonIgnore]
        public ObservableListSource<Employee> Employee { get; set; }
        public ObservableListSource<FileCustomer> FileCustomer { get; set; }
        [JsonIgnore]
        public ObservableListSource<ReqAgreement> ReqAgreement { get; set; }
        [JsonIgnore]
        public ObservableListSource<ReqCustomer> ReqCustomer { get; set; }
        [JsonIgnore]
        public ObservableListSource<Request> Request { get; set; }
        [JsonIgnore]
        public ObservableListSource<UserRole> UserRole { get; set; }
    }
}


