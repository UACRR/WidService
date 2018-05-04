using System;
using System.Collections.Generic;
using System.Text;

namespace ipsFormsDesign.Interfaces
{
    
	interface IClnBusinessPlace
	{
	}
	interface ILicenseAgreement
	{
	}
	interface IMoneyReceived
	{
	}
	interface IPaidPeriod
	{
	}

	interface IClient
	{
        int CustId { get; set; }
        ICollection<IClnBusinessPlace> ClnBusinessPlace { get; set; }
        ICollection<ILicenseAgreement> LicenseAgreement { get; set; }
        ICollection<IMoneyReceived> MoneyReceived { get; set; }
        ICollection<IPaidPeriod> PaidPeriod { get; set; }

	}
	
	interface ICommunity
	{
	}
	
	interface ICompany
	{
	}

	interface IMyAnketa
	{
	}
	interface IPartner
	{
	}
	interface IPerson
	{
	}
	interface IRightHolder
	{
	}
    
	interface IAccount
	{
	}
	interface IAgreementMaster
	{
	}
	interface IAnketaAddName
	{
	}
	interface IAnketaAddParam
	{
	}
	interface IAnketaCompany
	{
	}
	interface IAnketaPerson
	{
	}
	interface IBankAccount
	{
	}
	interface IEmployee
	{
	}
	interface IRegister
	{
	}
	interface IReqAgreement
	{
	}
	interface IReqCustomer
	{
	}
	interface IRequest
	{
	}
	interface IUserRole
	{
	}
    
	
	interface ICustomer
    {
        int CustId { get; set; }
        int? CustType { get; set; }
        int Status { get; set; }
        int? AnkVersion { get; set; }
        byte? AnkMy { get; set; }
        byte? AnkPublish { get; set; }
        byte? AnkTech { get; set; }

        IClient Client { get; set; }
        ICommunity Community { get; set; }
        ICompany Company { get; set; }
		
        IMyAnketa MyAnketa { get; set; }
        IPartner Partner { get; set; }
        IPerson Person { get; set; }
        IRightHolder RightHolder { get; set; }
        
		ICollection<IAccount> Account { get; set; }
        ICollection<IAgreementMaster> AgreementMaster { get; set; }
        ICollection<IAnketaAddName> AnketaAddName { get; set; }
        ICollection<IAnketaAddParam> AnketaAddParam { get; set; }
        ICollection<IAnketaCompany> AnketaCompany { get; set; }
        ICollection<IAnketaPerson> AnketaPerson { get; set; }
        ICollection<IBankAccount> BankAccount { get; set; }
        ICollection<IEmployee> Employee { get; set; }
        ICollection<IRegister> Register { get; set; }
        ICollection<IReqAgreement> ReqAgreement { get; set; }
        ICollection<IReqCustomer> ReqCustomer { get; set; }
        ICollection<IRequest> Request { get; set; }
        ICollection<IUserRole> UserRole { get; set; }

    }
}
