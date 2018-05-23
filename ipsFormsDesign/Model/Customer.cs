using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Customer : ICustomer
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

        public CustomerType CustTypeNavigation { get; set; }
        public CustomerStatus StatusNavigation { get; set; }
        public Client Client { get; set; }
        public Community Community { get; set; }
        public Company Company { get; set; }
        public MyAnketa MyAnketa { get; set; }
        public Partner Partner { get; set; }
        public Person Person { get; set; }
        public RightHolder RightHolder { get; set; }
        public ICollection<Account> Account { get; set; }
        public ICollection<AgreementMaster> AgreementMaster { get; set; }
        public ICollection<AnketaAddName> AnketaAddName { get; set; }
        public ICollection<AnketaAddParam> AnketaAddParam { get; set; }
        public ICollection<AnketaCompany> AnketaCompany { get; set; }
        public ICollection<AnketaPerson> AnketaPerson { get; set; }
        public ICollection<BankAccount> BankAccount { get; set; }
        public ICollection<Employee> Employee { get; set; }
        public ICollection<Register> Register { get; set; }
        public ICollection<ReqAgreement> ReqAgreement { get; set; }
        public ICollection<ReqCustomer> ReqCustomer { get; set; }
        public ICollection<Request> Request { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
    }
}

