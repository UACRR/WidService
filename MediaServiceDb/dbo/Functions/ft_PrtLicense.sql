--drop function dbo.ft_PrtLicense
create  function dbo.ft_PrtLicense (@reqId integer, @lang char(2) = NULL)
RETURNS @RT TABLE
(
id  integer not null identity primary key, 
reqId        integer not null, 
licNum       varchar(64), 
licDate      char(10), 
licNumDate   varchar(100), 
custDecr     varchar(254),
licName      varchar(254),
productDesc  varchar(512), 
LocationName text,
termUseName  varchar(254),
licNameType  varchar(254),
useMediaTypeName varchar(254),
AddUse       varchar(254), 
custNameMy   varchar(254)
 )
AS
BEGIN

set @lang = (Case When @lang is NULL or  @lang not in ('Uk', 'Ru','En') Then 'Uk' Else  @lang end)

insert into @RT (reqId, custDecr,  licNameType) 
 select r1.reqId, c1.name+' код OKPO/Ід.код: '+InnOkpo as custDesc
, l1.licname
 from request r1
     join vCustomer c1 on r1.custId = c1.custId
	 join vlLicenseType l1 on isnull(r1.licCode,2) = l1.licCode and l1.lang = @lang
 where r1.reqId = @reqId

 update @RT set  LicNum = d3.docNumber, licDate = d3.docDate, licname = k3.docTypeName
   from Document d3 
   join vlDocumentKind k3 on d3.docTypeCode = k3.docTypeCode and k3.lang = @lang
   where d3.docId = 
   (select max(d2.docId) as docId  
     from 
     request r1 
     join DocReq d1 on r1.reqId = d1.reqId 
     join Document d2 on d1.docId = d2.docId 
 	 where r1.reqId = @reqId and d2.docTypeCode = 3 )

 update @RT set AddUse = (select  dbo.f_PrtAddUse (@reqId, @lang))
 update @RT set LocationName = UseCountry 
    from dbo.ft_ProductLocate  (@reqId, @lang)
 update @RT set useMediaTypeName = (select dbo.f_PrtUseMedia (@reqId, @lang))

 update @RT set termUseName = (Case When isnull(r1.termUseCode,1) = 1 Then u1.termUseName
     Else  ' з '+convert(char(10), r1.beginDate, 104)+' по '+ convert(char(10), r1.endDate, 104) end)
   from 
	request r1 
	join vlTermUse u1 on r1.termUseCode = u1.termUseCode and u1.lang = @lang
	where r1.reqId = @reqId 
	  and isnull(r1.termUseCode,1) = u1.termUseCode
 
  update @RT set licNumDate = '№'+rtrim(licNum)+' від '+licDate, 
                 custNameMy = (select name from vCustomer where ankMy = 1)

   update @RT set productDesc = (select reqAimName + 
       (Case When isnull(cntSeries,0)> 0 Then ' що має '+rtrim(ltrim(convert(char(10),cntSeries))) Else '' end) +' під умовною назвою ' + workName +
	        ' у жанрі ' + GenreName 
	        from  dbo.ft_ProductDesc (@reqId, @lang) where id=1 ) 
  
RETURN;
END;

--select * from dbo.ft_PrtLicense (123,NULL)
--select * from dbo.ft_ProductDesc (112, NULL)