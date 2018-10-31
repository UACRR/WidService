--Функция получения таблицы с описанием правообладателей
--drop FUNCTION dbo.ft_PrtCustAnk
create FUNCTION dbo.ft_PrtCustAnk (@reqId integer = NULL, @lang char(2) = NULL, @custId integer = NULL)
RETURNS @RT TABLE
( 
  custId integer not null primary key,
  custType        integer null,   
  custName          varchar(254) null, 
  custInnOkpo       varchar(15)  null, 
  custCountryCode   char(3)      null, 
  custCountryName   varchar(254) null, 
  custCountryLit    char(3)      null,
  custAddress       varchar(254) null,
  custPhone         varchar(254) null, 
  custEmail         varchar(254) null, 
  custMFO           integer      null, 
  custBankName      varchar(254) null, 
  custR030          char(3)      null, 
  custCurName       varchar(254) null, 
  custCurShName     char(3)      null, 
  custAccount       varchar(32)  null, 
  custSigner        varchar(254) null
)
  as
  BEGIN 
--declare @reqId integer 
--set @reqId = 115

If isnull(@reqId,0) = 0 and isnull(@custId,0)=0 
 return 

If isnull(@custId,0) = 0 
  set  @custId = (select custId from request where reqId = @reqId)

set @lang = (Case When @lang is NULL or  @lang not in ('Uk', 'Ru','En') Then 'Uk' Else  @lang end)

Insert into @RT
(
  custId, custType, custName,  custInnOkpo, custCountryCode, custCountryName, custCountryLit )
select 
  u1.custId
, u1.custType
, u1.name  
, u1.iNNOKPO 
, c1.countryCode
, c1.countryName
, c1.kod_lit
from  
  vCustomer u1 
  join vlCountry c1 on u1.countryCode = c1.countryCode and c1.lang = @lang
where u1.custId = @custId 

  Update @RT 
  set 
  custAddress = a1.registrationCity +' '+ a1.registrationAddress
 ,custPhone = isnull(a1.phoneMobileMain, a1.phoneMobileExtra)  
 ,custEmail = a1.eMail  
 ,custMFO =  b1.mfo
 ,custBankName =  mfoName
 ,custR030 =  b1.currency
 ,custcurName = v1.r030Name 
 ,custCurShName = v1.a3  
 ,custAccount = b1.accountNumber
 from @RT r1 
 join customer c1 on r1.custId = c1.custId 
 join anketaperson a1 on r1.custId = a1.custId and c1.ankVersion = a1.version
 left join BankAccount b1 on a1.custId = b1.custId and a1.banAccId = b1.banAccId
 left join vlcurrency v1 on b1.currency = v1.r030
 where c1.custType in (1,2)  

  Update @RT 
  set 
  custAddress = a1.jaCity +' '+ a1.jaAddress
, custPhone = y1.phoneNumber
, custEmail = y1.email
, custSigner = isnull(y1.firstName,'')+' '+isnull(y1.surName,'')+' '+isnull(y1.lastName,'')
 ,custMFO =  b1.mfo
 ,custBankName =  mfoName
 ,custR030 =  b1.currency
 ,custCurName = v1.r030Name 
 ,custCurShName = v1.a3  
 ,custAccount = b1.accountNumber
 from @RT r1 
 join customer c1 on r1.custId = c1.custId 
 join anketaCompany a1 on r1.custId = a1.custId and c1.ankVersion = a1.version
 left join RelEmployee e1 on r1.custId = e1.custId and e1.positionCode = 1
 left join Employee y1 on e1.emplid = y1.emplid  
 left join BankAccount b1 on a1.custId = b1.custId and a1.banAccId = b1.banAccId
 left join vlcurrency v1 on b1.currency = v1.r030 and v1.lang = @lang
where c1.custType = 3  


RETURN 
END  

--select * from ft_PrtCustAnk (112, NULL, NULL)