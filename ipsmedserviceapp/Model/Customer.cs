using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Customer
    {
        public Customer()
        {
            Account = new HashSet<Account>();
            AgreementMaster = new HashSet<AgreementMaster>();
            AnketaAddName = new HashSet<AnketaAddName>();
            AnketaAddParam = new HashSet<AnketaAddParam>();
            AnketaCompany = new HashSet<AnketaCompany>();
            AnketaPerson = new HashSet<AnketaPerson>();
            BankAccount = new HashSet<BankAccount>();
            Employee = new HashSet<Employee>();
            FileCustomer = new HashSet<FileCustomer>();
            Register = new HashSet<Register>();
            ReqAgreement = new HashSet<ReqAgreement>();
            ReqCustomer = new HashSet<ReqCustomer>();
            Request = new HashSet<Request>();
            UserRole = new HashSet<UserRole>();
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
        [JsonIgnore]
        public AnketaExternal AnketaExternal { get; set; }
        public Client Client { get; set; }
        public Community Community { get; set; }
        public Company Company { get; set; }
        [JsonIgnore]
        public MyAnketa MyAnketa { get; set; }
        [JsonIgnore]
        public Partner Partner { get; set; }
        public Person Person { get; set; }
        public RightHolder RightHolder { get; set; }
        [JsonIgnore]
        public ICollection<Account> Account { get; set; }
        public ICollection<AgreementMaster> AgreementMaster { get; set; }
        public ICollection<AnketaAddName> AnketaAddName { get; set; }
        [JsonIgnore]
        public ICollection<AnketaAddParam> AnketaAddParam { get; set; }
        [JsonIgnore]
        public ICollection<AnketaCompany> AnketaCompany { get; set; }
        [JsonIgnore]
        public ICollection<AnketaPerson> AnketaPerson { get; set; }
        public ICollection<BankAccount> BankAccount { get; set; }
        [JsonIgnore]
        public ICollection<Employee> Employee { get; set; }
        [JsonIgnore]
        public ICollection<FileCustomer> FileCustomer { get; set; }
        [JsonIgnore]
        public ICollection<Register> Register { get; set; }
        [JsonIgnore]
        public ICollection<ReqAgreement> ReqAgreement { get; set; }
        [JsonIgnore]
        public ICollection<ReqCustomer> ReqCustomer { get; set; }
        [JsonIgnore]
        public ICollection<Request> Request { get; set; }
        [JsonIgnore]
        public ICollection<UserRole> UserRole { get; set; }
    }
}

