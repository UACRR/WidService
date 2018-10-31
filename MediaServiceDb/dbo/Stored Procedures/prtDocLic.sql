---------------------

CREATE PROCEDURE [dbo].[prtDocLic] ( @docid  integer, @lang char(2) = NULL )
AS   
Begin
SET NOCOUNT ON;   --отключение вывода кол-ва строк для оптимизации
declare @Retcode integer, @reqId integer

If not exists ( select 1 from Document where docid = @docid ) 
    Return 1

If not exists ( select 1 from Document where docid = @docid and docTypeCode=3) 
    Return 1


set @lang = (Case When @lang is NULL or  @lang not in ('Uk', 'Ru','En') Then 'Uk' Else  @lang end)

Create table #RT 
(
docid        integer not null  primary key, 
reqId        integer null, 
licNum       varchar(64) NULL, 
licDate      char(10) NULL, 
licNumDate   varchar(100) NULL, 
custDesc     varchar(254) NULL,
licName      varchar(254) NULL,
productDesc  varchar(512) NULL, 
LocationName text NULL,
termUseName  varchar(254) NULL,
licCode      integer      NULL,
licNameType  varchar(254) NULL,
licNameTypeR varchar(254) NULL,
licNameC     varchar(254) NULL,
useMediaTypeName varchar(254) NULL,
AddUse       varchar(254) NULL, 
custNameMy   varchar(254) NULL, 
objId integer null, 
objName varchar(254) null, 
objAuthor varchar(254) null,
objPerfomer varchar(254) null, 
countUse integer null,               --кол-во использования
countUseName varchar(100) null,      --кол-во использования словами
TimeDesc varchar(254) null,          --эпизод и хронометраж словами
UseAreaType varchar(512) null,        --для адаптации
CustDogNumDate  varchar(100) NULL,     --номер договора с клиентом
templName varchar(60) NULL,  --имя шаблона
templPath varchar(254) NULL         --путь к шаблону
 )

insert into  #RT  (docid, licNum, licDate, licName)
 select d3.docid, d3.docNumber, d3.docDate, k3.docTypeName
   from Document d3 
   join vlDocumentKind k3 on d3.docTypeCode = k3.docTypeCode and k3.lang = @lang
   where d3.docid = @docid

set @reqId = (select max(reqId) from docReq where docid = @docid )

update #RT set reqId = @reqId

update #RT 
 set custDesc = c1.name+' код OKPO/Ід.код: '+InnOkpo,  
     licNameType = l1.licname, 
	 licNameTypeR = l1.licNameR,
	 licNameC = l1.licNameC
from request r1
     join vCustomer c1 on r1.custId = c1.custId
	 join vlrLicenseType l1 on isnull(r1.licCode,2) = l1.licCode and l1.lang = @lang
 where r1.reqId = #RT.reqId

 update #RT set AddUse = (select  dbo.f_PrtAddUse (@reqId, @lang))
 update #RT set LocationName = UseCountry 
    from dbo.ft_ProductLocate  (@reqId, @lang)
 update #RT set useMediaTypeName = (select dbo.f_PrtUseMedia (@reqId, @lang))

 update #RT set termUseName = (Case When isnull(r1.termUseCode,1) = 1 Then u1.termUseName
     Else  ' з '+convert(char(10), r1.beginDate, 104)+' по '+ convert(char(10), r1.endDate, 104) end)
   from 
	request r1 
	join vlTermUse u1 on r1.termUseCode = u1.termUseCode and u1.lang = @lang
	where r1.reqId = @reqId 
	  and isnull(r1.termUseCode,1) = u1.termUseCode
 
  update #RT set licNumDate = '№'+rtrim(licNum)+' від '+licDate, 
                 custNameMy = (select name from vCustomer where ankMy = 1)

--описание
update #RT set productDesc = licnameTypeR+' '+ 
(select 
(select t1.Text from vlDocText t1 where lang = @lang and t1.code = 'lic')+ ' '+
(select t1.Text from vlDocText t1 where lang = @lang and t1.code = 'Vkl')+ ' ' +
' ('+reqAimName+') '+ 
   (Case When isnull(cntSeries,0)> 0 Then ' що має '+rtrim(ltrim(convert(char(10),isnull(cntSeries,0)))) Else '' end) 
	        +(Case When isnull(workName,'') <> '' 
			THEN (select t1.Text_Uk from DocText t1 where t1.code = 'Un') + ' '+ isnull(workName,'-') ELSE '' end)
			+ (CASE WHEN isnull(GenreName,'') <> '' THEN ' у жанрі ' + isnull(GenreName,'') ELSE '' END) 
			+ ' ' + (select t1.Text from vlDocText t1 where lang = @lang and t1.code = 'Dali')
	        from  dbo.ft_ProductDesc (@reqId, @lang) where id=1 )
  
--Хронометраж
 update #RT set objid = r1.objId, 
                objName = o1.name,  objAuthor = o1.author, objPerfomer = o1.performer,
                countUse = r1.countUse, countUseName = d1.dName
from request r1 
join ObjectRight o1 on r1.objid = o1.objId
left join vlDicList d1 on dKind = 'CountUse' and 
     d1.dCode = (Case When isnull(r1.countUse,0) = 0 Then 0 Else 1 end)  and lang = @lang
where r1.reqId = @reqId

--Титры
update #RT SET  TimeDesc =  (select 
STUFF (
( select ', '+TimeDesc from ft_ProductTime(@reqId,@lang)
for XML path ('')) ,1,1,'') as TTT 
)

update #RT set templName = t1.templName, templPath = t1.templPath
 from  DocTemplate t1 
 where t1.docTypeCode = 3 

 select docid ,reqId,licNum,licDate,licNumDate,custDesc, licNameC as licName,productDesc,LocationName,termUseName ,
         licNameType,licNameTypeR, ltrim(rtrim(useMediaTypeName)) useMediaTypeName,AddUse,custNameMy, 
         objid, objName, objAuthor, objPerfomer, countUse, countUseName, timeDesc, UseAreaType, CustDogNumDate, 
         templName, templPath
  from #RT 

RETURN @RetCode
END

--exec dbo.prtDocLic 55,'Uk'
--select * from Document