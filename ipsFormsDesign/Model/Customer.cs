using ipsFormsDesign.Interfaces;
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
            userRole = new ObservableListSource<userRole>();
        }

        public int custId { get; set; }
        public int? custType { get; set; }
        public int status { get; set; }
        public int? ankVersion { get; set; }
        public byte? ankMy { get; set; }
        public byte? ankPublish { get; set; }
        public byte? ankTech { get; set; }

        public CustomerType custTypeNavigation { get; set; }
        public CustomerStatus statusNavigation { get; set; }
        public AnketaExternal AnketaExternal { get; set; }
        public Client Client { get; set; }
        public Community Community { get; set; }
        public Company Company { get; set; }
        public MyAnketa MyAnketa { get; set; }
        public Partner Partner { get; set; }
        public Person Person { get; set; }
        public RightHolder RightHolder { get; set; }
        public ObservableListSource<Account> Account { get; set; }
        public ObservableListSource<AgreementMaster> AgreementMaster { get; set; }
        public ObservableListSource<AnketaAddName> AnketaAddName { get; set; }
        public ObservableListSource<AnketaAddParam> AnketaAddParam { get; set; }
        public ObservableListSource<AnketaCompany> AnketaCompany { get; set; }
        public ObservableListSource<AnketaPerson> AnketaPerson { get; set; }
        public ObservableListSource<BankAccount> BankAccount { get; set; }
        public ObservableListSource<Employee> Employee { get; set; }
        public ObservableListSource<FileCustomer> FileCustomer { get; set; }
        public ObservableListSource<ReqAgreement> ReqAgreement { get; set; }
        public ObservableListSource<ReqCustomer> ReqCustomer { get; set; }
        public ObservableListSource<Request> Request { get; set; }
        public ObservableListSource<userRole> userRole { get; set; }
    }
}

