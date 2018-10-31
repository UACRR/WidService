---------------------

CREATE PROCEDURE [dbo].[prtDocInv] ( @docId  integer, @lang char(2) = NULL )
AS   
Begin
SET NOCOUNT ON;   --отключение вывода кол-ва строк для оптимизации
declare @Retcode integer, @reqId integer, @STotal money, @sLic smallint

 If not exists ( select 1 from Invoice where docId = @docId ) 
    Return 1

set @lang = (Case When @lang is NULL or  @lang not in ('Uk', 'Ru','En') Then 'Uk' Else  @lang end)

Create table #RT 
(
docId        integer  not null  primary key, 
reqId        integer      null, 
docNum       varchar(64)  NULL, 
docDate      char(10)     NULL, 
docTypeName  varchar(64)  NULL, 
docNumDate   varchar(100) NULL, 
custName     varchar(254) NULL, 
custDesc     varchar(254) NULL,
custNameMy   varchar(254) NULL,
custDescMy   varchar(254) NULL,
custDescMyAc varchar(254) NULL,
docName      varchar(254) NULL,
productDesc  varchar(512) NULL, 
nDogCl       varchar(64)  NULL, 
sTotal       money        NULL, 
sWORD        varchar(512) NULL,
pNum         integer      NULL , 
pName        varchar(512) NULL, 
pCount       integer      NULL, 
pDim         varchar(10)  NULL, 
pPrice       money        NULL, 
pAmount      money        NULL, 
templName varchar(60) NULL,  --имя шаблона
templPath varchar(254) NULL         --путь к шаблону
)

set @reqId = (select max(reqId) from docReq where docId = @docId )

insert into  #RT  (docId, reqId, docNum, docDate, docTypeName)
 select d3.docId, @reqId, d3.docNumber, d3.docDate, k3.docTypeName
   from Document d3 
   join vlDocumentKind k3 on d3.docTypeCode = k3.docTypeCode and k3.lang = @lang
   where d3.docId = @docId

update #RT 
 set pPrice = r1.reqAmount, pAmount = r1.reqAmount,  --потом вынести в отдельную функцию для перечня продуктов в инвойсе
     custName = c1.name,
     custDesc = c1.name+' код OKPO/Ід.код: '+InnOkpo,  
     custNameMy = a1.myName, 
     custDescMy = 'Код ЄДРПОУ: '+ a1.myInnOkpo+', ' + a1.myCountryName+', '+a1.myAddress + 'тел.'+a1.myPhone+ ' , '+'Email:'+a1.myEmail,
	 custDescMyAc = 'P/p'+myAccount+','+'Банк:' + a1.myBankName+', ' +'МФО '+ convert(char(6),myMFO)+' ' +a1.myCountryName+' Код за ЭДРПОУ '+ a1.myInnOkpo
from ft_PrtmyAnk (@lang) a1, 
     request r1
     join vCustomer c1 on r1.custId = c1.custId
 where r1.reqId = #RT.reqId

 
  update #RT set docNumDate = '№'+rtrim(docNum)+' від '+ docDate, 
                 custNameMy = (select name from vCustomer where ankMy = 1)

---!!! Временно !!!
/*
 update #RT set productDesc = 'Всього найменувань 2, на суму 5250.00 грн.', 
                Stotal = 5250.00, 
                SWord = '(п''ять тисяч двісті п''ятдесят гривень 00 копійок)', 
				NdogCl = 'B/N', 
				pNum  = 1,
				pName = 'Роялті за отримані права згідно Ліцензії №LSNC-51 від 24 жовтня 2017 р.', 
                pCount = 1,
				pDim = 'од.'
*/

--описание
 select @sTotal = sum(reqAmount) , @slic = count(*)
   from request r1 
   join docreq q1 on q1.reqId = r1.reqId  
   join Document d1 on d1.docId = q1.docId 
   where d1.docTypeCode = 3 and r1.reqId = @reqId

 update #RT set productDesc = 'Всього найменувань '+convert(varchar(25),@sLic)+' на суму ' 
        + convert(varchar(25),@sTotal), 
        Stotal = @sTotal, 
        SWord = (select dbo.f_Num2Wort (@sTotal, '980', @lang)), 
        NdogCl = 'B/N', 
	pNum  = 1,
	pName = 'Роялті за отримані права згідно Ліцензії ' + 
        (select STUFF ((
         select ' '+'№'+rtrim(docNumber) +' від '+ convert(char(10), docDate,104)+'; '  
             from dbo.ft_PrlListDoc (@lang, NULL, @reqId) where docTypeCode = 3
         FOR XML path('')), 1,1,'')) ,
         pCount = @slic,
	 pDim = 'од.'
/*
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
*/


update #RT set templName = t1.templName, templPath = t1.templPath
 from  DocTemplate t1 
 where t1.docTypeCode = 5 

 select docid,reqId,docNum,docDate,docNumDate, custName, custNameMy,custDescMy,docName,productDesc, nDogCl, sTotal, sWord, 
        pNum, pName, pCount, pDim, pPrice, pAmount, custDescMyAc, templName, templPath  
  from #RT 

RETURN @RetCode
END

--exec dbo.prtDocInv 54,'Uk'
--select * from docreq where docid = 54