--Функция получения строки с описанием территории
--drop FUNCTION dbo.ft_ProductLocate 
create FUNCTION dbo.ft_ProductLocate (@reqId integer, @lang char(2) = NULL)
RETURNS @RT TABLE
( id integer not null identity primary key, 
  reqId integer not null , 
  UseCountry  text  null 
)
  as
  BEGIN 
--declare @reqId integer 
--set @reqId = 115
set @lang = (Case When @lang is NULL or  @lang not in ('Uk', 'Ru','En') Then 'Uk' Else  @lang end)
;
;
with CC as 
(
select l1.reqId, c1.continentCode, n1.continentName, c1.countryCode, c1.countryName 
 from ReqLocationUse l1 
 join vlCountry c1 on l1.countryCode = c1.countryCode and isnull(l1.countryCode,0) <> 0 and c1.lang = @lang  and l1.reqId = @reqId
 join vlContinent n1 on c1.continentCode = n1.continentCode and c1.lang = n1.lang
 union 
select l1.reqId, l1.continentCode, n1.continentName, c1.countryCode, c1.countryName
 from ReqLocationUse l1 
 join vlCountry c1 on l1.continentCode = c1.continentCode and isnull(l1.countryCode,0) = 0 and c1.lang = @lang and l1.reqId = @reqId
 join vlContinent n1 on c1.continentCode = n1.continentCode and c1.lang = n1.lang
 -- order by 2,4
 ) 
insert into @RT
Select  
@reqId, STUFF (( 
select ' '+
(Case When tt.continentName like 'Укра_на' Then '' Else tt.continentName+':' End )+ countryName +';'
from 
(select reqId, max(t1.continentName) as continentName,
 STUFF (( 
select  ', ' +countryName from CC t2 where t1.continentCode = t2.continentCode
 for XML path('')) ,1,1,'') as countryName
 from CC t1
 group by t1.reqId, t1.continentCode ) TT
 for XML path('')), 1,1,'') as Name

RETURN 
END  

--select * from dbo.ft_ProductLocate (112,'Ru')