
CREATE FUNCTION [dbo].[ft_PrlListDoc1] (@lang char(2) = NULL, @custId integer = NULL, @docid integer = NULL )
RETURNS @RT TABLE 
( id integer not null identity primary key, 
  reqId integer  null, 
  reqType	int ,
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
 set @lang = (Case When @lang is NULL or  @lang not in ('Uk', 'Ru','En') Then 'Uk' Else  @lang end)

Insert into @RT
   select  t1.reqId, r1.reqType,r1.custID, c1.name as custName, d1.docId,  d1.docNumber,
   convert(char(12),isnull(d1.docDate,getdate()),104)	, d1.docTypeCode, k1.name, 
   isnull(d1.docFile,'') docFile
   from docreq t1 
   join Request r1 on t1.reqId = r1.reqId
   join vCustomer c1 on r1.custID = c1.custID
   join Document d1 on t1.docId = d1.docId 
   join DocumentKindTr k1 on d1.docTypeCode = k1.codeI
where r1.custId = isnull(@custId, r1.custId) and lang = @lang 
  and d1.docId = isnull(@docid, d1.docId)

  
RETURN ;
END;

--select * from dbo.ft_PrlListDoc1 (NULL, NULL, NULL)