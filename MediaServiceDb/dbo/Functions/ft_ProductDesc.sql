--Функция получения строки с описанием продукта
--т.е., заявка в одну строку
--drop FUNCTION dbo.ft_ProductDesc 
create FUNCTION dbo.ft_ProductDesc (@reqId integer, @lang char(2) = NULL)
RETURNS @RT TABLE
( id integer not null identity primary key, 
  reqId integer not null , 
  docId  integer  null, 
  docNumber varchar(100) null, 
  docDate date null,
  docTypeName varchar(200) null, 
  reqTypeName varchar(200) null,
  categoryName varchar(200) null,
  reqAimName varchar(200) null,
  cntSeries integer null,
  workName varchar(200) null,
  GenreName varchar(512) null,
  useDesc varchar(254) null, 
  UseAreaType varchar(512) null
)
  as
  BEGIN 
--declare @reqId integer 
--set @reqId = 115
 set @lang = (Case When @lang is NULL or  @lang not in ('Uk', 'Ru','En') Then 'Uk' Else  @lang end)
Insert into @RT (reqId, docId, docNumber, docDate, docTypeName, reqTypeName, categoryName, reqAimName, cntSeries, workName, GenreName, useDesc) 
 select r1.reqId, d2.docId, d2.docNumber, d2.docDate, d3.docTypeName, t1.reqTypeName, c1.categoryName, a1.reqAimName
 ,isnull(s1.cntSeries,0) as cntSeries
 ,isnull(r1.workName,'') as workName 
 ,gs.GenreName 
 ,o1.useDesc
 from request r1 
 join vlRequestType t1 on r1.reqType = t1.reqType and t1.lang = @lang
 join vlrequestAim a1 on r1.reqAimCode = a1.reqAimCode
 join vlcategory c1 on a1.categoryCode = c1.categoryCode and a1.lang = c1.lang and c1.lang=@lang
 left join RequestSerial s1 on s1.reqId = r1.reqId
 left join (select r11.reqId,
stuff (( 
select   ' '+g1.genreName 
  from request r1
  join 
  ( select reqid, genreId from RelGenreSerial where reqid = @reqId 
     union 
	select reqid, genreId from RelGenreMovie where reqid = @reqId )
	 rg1 on r1.reqid = rg1.reqId
  join vlgenre g1 on rg1.genreId = g1.genreId and g1.lang=@lang
where r1.reqId = @reqId
for XML path('')) ,1,1,'') as GenreName
from request r11 where r11.reqId = @reqId
) GS on Gs.reqId = r1.reqId
  left join DocReq d1 on r1.reqId = d1.reqId 
  left join Document d2 on d1.docId = d2.docId 
  left join vlDocumentKind d3 on d2.docTypeCode = d3.docTypeCode and d3.lang = @lang
  left join RequestOther o1 on r1.reqId = o1.reqId
where r1.reqId = @reqId 
      and r1.reqType = 10 --синхронизация


Insert into @RT (reqId, docId, docNumber, docDate, docTypeName, reqTypeName, categoryName, reqAimName, workName, GenreName, UseAreaType) 
 select r1.reqId, d2.docId, d2.docNumber, d2.docDate, d3.docTypeName, t1.reqTypeName, c1.categoryName, a1.reqAimName
 ,isnull(r1.workName,'') as workName 
 ,gs.GenreName 
 ,UseAreaTypeName as UseAreaType
 from request r1 
 join requestAdapt ad1 on r1.reqId = ad1.reqId 
 join vlRequestType t1 on r1.reqType = t1.reqType and t1.lang = @lang
 join vlrequestAim a1 on r1.reqAimCode = a1.reqAimCode
 join vlcategory c1 on a1.categoryCode = c1.categoryCode and a1.lang = c1.lang and c1.lang=@lang
 left join (select r11.reqId,
stuff (( 
select   ', '+g1.genreName 
  from request r1
  join RelGenreAdapt rg1 on r1.reqid = rg1.reqId
  join vlgenre g1 on rg1.genreId = g1.genreId and g1.lang=@lang
where r1.reqId = @reqId
for XML path('')) ,1,1,'') as GenreName
from request r11 where r11.reqId = @reqId
) GS on Gs.reqId = r1.reqId
  left join DocReq d1 on r1.reqId = d1.reqId 
  left join Document d2 on d1.docId = d2.docId 
  left join vlDocumentKind d3 on d2.docTypeCode = d3.docTypeCode and d3.lang = @lang
  left join (select ua11.reqId, 
  STUFF (( 
  select ', '+ ut1.UseAreaTypeName
  from RelAdaptUseArea ua1 
  join vlUseAreaType ut1 on ua1.useAreaTypeCode = ut1.useAreaTypeCode and ua1.reqId = @reqId and lang=@lang
  for XML path('')), 1,1,'') as UseAreaTypeName
  from requestAdapt ua11 ) ua12 on r1.reqId = ua12.reqId
  where r1.reqId = @reqId
      and r1.reqType = 20 --адаптация

    
RETURN 
END  

--select * from dbo.ft_ProductDesc (135,'Uk')
--exec prtDocLic 23, NULL