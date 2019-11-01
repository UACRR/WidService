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
            UserRole = new HashSet<UserRole>();
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
        public virtual ICollection<Account> Account { get; set; }
        public virtual ICollection<AgreementMaster> AgreementMaster { get; set; }
        public virtual ICollection<AnketaAddName> AnketaAddName { get; set; }
        [JsonIgnore]
        public virtual ICollection<AnketaAddParam> AnketaAddParam { get; set; }
        [JsonIgnore]
        public virtual ICollection<AnketaCompany> AnketaCompany { get; set; }
        [JsonIgnore]
        public virtual ICollection<AnketaPerson> AnketaPerson { get; set; }
        public virtual ICollection<BankAccount> BankAccount { get; set; }
        [JsonIgnore]
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<FileCustomer> FileCustomer { get; set; }
        [JsonIgnore]
        public virtual ICollection<ReqAgreement> ReqAgreement { get; set; }
        [JsonIgnore]
        public virtual ICollection<ReqCustomer> ReqCustomer { get; set; }
        [JsonIgnore]
        public virtual ICollection<Request> Request { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}



