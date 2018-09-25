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
            ReqAgreement = new HashSet<ReqAgreement>();
            ReqCustomer = new HashSet<ReqCustomer>();
            Request = new HashSet<Request>();
            userRole = new HashSet<userRole>();
        }

        public int custId { get; set; }
        public int? custType { get; set; }
        public int status { get; set; }
        public int? ankVersion { get; set; }
        public byte? ankMy { get; set; }
        public byte? ankPublish { get; set; }
        public byte? ankTech { get; set; }

        [JsonIgnore]
        public CustomerType custTypeNavigation { get; set; }
        [JsonIgnore]
        public CustomerStatus statusNavigation { get; set; }
        [JsonIgnore]
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
        public ICollection<FileCustomer> FileCustomer { get; set; }
        [JsonIgnore]
        public ICollection<ReqAgreement> ReqAgreement { get; set; }
        [JsonIgnore]
        public ICollection<ReqCustomer> ReqCustomer { get; set; }
        [JsonIgnore]
        public ICollection<Request> Request { get; set; }
        [JsonIgnore]
        public ICollection<userRole> userRole { get; set; }
    }
}

