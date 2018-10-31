
CREATE FUNCTION [dbo].[ft_PrlListDoc] (@curLang char(2) = NULL, @custId integer = NULL, @reqId integer = NULL )
RETURNS @RT TABLE 
( id integer not null identity primary key, 
  reqId integer  null, 
  custId integer null, 
  custName  varchar(254) null, 
  docid integer null, 
  docNumber varchar(64) null,
  docDate varchar(20) null, 
  docTypeCode integer null,    
  docTypeName varchar(200) null,
  docFile varchar(254) null
)
  as
  BEGIN 
 set @curLang = (Case When @curLang is NULL or  @curLang not in ('uk', 'ru','En') Then 'uk' Else  @curLang end)

Insert into @RT
   select  t1.reqId, r1.custID, c1.name as custName, d1.docId,  d1.docNumber,
   convert(char(12),isnull(d1.docDate,getdate()),104)	, d1.docTypeCode, k1.name, d1.docFile
   from docreq t1 
   join Request r1 on t1.reqId = r1.reqId
   join vCustomer c1 on r1.custID = c1.custID
   join Document d1 on t1.docId = d1.docId 
   join DocumentKindTr k1 on d1.docTypeCode = k1.codeI
--   join vlDocumentKind k1 on d1.docTypeCode = k1.docTypeCode
where r1.custId = isnull(@custId, r1.custId) and lang = @curLang 
  and r1.reqId = isnull(@reqId, r1.reqId)

  
RETURN ;
END;

--select * from dbo.ft_PrlListDoc ('en',2, NULL)