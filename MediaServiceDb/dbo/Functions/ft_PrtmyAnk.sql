--Функция получения таблицы с описанием правообладателей
--drop FUNCTION dbo.ft_PrtmyAnk 
CREATE FUNCTION [dbo].[ft_PrtmyAnk] (@lang char(2) = NULL)
RETURNS @RT TABLE
( 
  custId integer not null primary key,
  custType        integer null,   
  myName          varchar(254) null, 
  myInnOkpo       varchar(15)  null, 
  myCountryCode   char(3)      null, 
  myCountryName   varchar(254) null, 
  myCountryLit    char(3)      null,
  myAddress       varchar(254) null,
  myPhone         varchar(254) null, 
  myEmail         varchar(254) null, 
  myMFO           integer      null, 
  myBankName      varchar(254) null, 
  myR030          char(3)      null, 
  mycurName       varchar(254) null, 
  mycurShName     char(3)      null, 
  myAccount       varchar(32)  null, 
  mySigner        varchar(254) null
)
  as
  BEGIN 
--declare @reqId integer 
--set @reqId = 115
set @lang = (Case When @lang is NULL or  @lang not in ('Uk', 'Ru','En') Then 'Uk' Else  @lang end)

Insert into @RT
(
  custId, custType, myName,  myInnOkpo, myCountryCode, myCountryName, myCountryLit )
select 
  u1.custId
, u1.custType
, u1.name  
, u1.iNNOKPO 
, c1.countryCode
, c1.countryName
, c0.kod_lit
from  vCustomer u1 
  join Country  c0 on u1.countryCode = c0.countryCode
  join CountryTr c1 on u1.countryCode = c1.countryCode and c1.lang = 'uk'--@lang
where ankMy = 1 

  Update @RT 
  set 
  myAddress = a1.reCity +' '+ a1.reAddress
 ,myPhone = isnull(a1.phoneMobileMain, a1.phoneMobileExtra)  
 ,myEmail = a1.eMail  
 ,myMFO =  b1.mfo
 ,myBankName =  mfoName
 ,myR030 =  b1.currency
 ,mycurName = v1.r030Name 
 ,mycurShName = v1.a3  
 ,myAccount = b1.accountNumber
 from @RT r1 
 join customer c1 on r1.custId = c1.custId 
 join anketaperson a1 on r1.custId = a1.custId and c1.ankVersion = a1.version
 left join BankAccount b1 on a1.custId = b1.custId and a1.banAccId = b1.banAccId
 left join KL_R030 v1 on b1.currency = v1.r030
 where c1.custType in (1,2)  

  Update @RT 
  set 
  myAddress = a1.jaCity +' '+ a1.jaAddress
, myPhone = y1.phoneNumber
, myEmail = y1.email
, mySigner = isnull(y1.firstName,'')+' '+isnull(y1.surName,'')+' '+isnull(y1.lastName,'')
 ,myMFO =  b1.mfo
 ,myBankName =  mfoName
 ,myR030 =  b1.currency
 ,mycurName = v1.r030Name 
 ,mycurShName = v0.a3  
 ,myAccount = b1.accountNumber
 from @RT r1 
 join customer c1 on r1.custId = c1.custId 
 join anketaCompany a1 on r1.custId = a1.custId and c1.ankVersion = a1.version
 left join RelEmployee e1 on r1.custId = e1.custId and e1.positionCode = 1
 left join Employee y1 on e1.emplid = y1.emplid  
 left join BankAccount b1 on a1.custId = b1.custId and a1.banAccId = b1.banAccId
 left join KL_R030 v0 on b1.currency = v0.r030  
 left join KL_R030Tr v1 on b1.currency = v1.r030 and v1.lang = @lang
where c1.custType = 3  


RETURN 
END  

--select * from dbo.ft_PrtmyAnk (NULL)
GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_PrtmyAnk] TO [ReportUser]
    AS [dbo];

