
CREATE procedure [dbo].[pTsk_5_2_CrKind] (@Type integer = NULL, @dateBegin date = NULL, @dateEnd date = NULL)
--@Type = 0/NULL - всі, 1-Великі права, 2-Малі Права
 as
begin

--Звіт по видам права у розрізі великих та малих прав
declare @category integer
set @dateBegin =  isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))
set @dateEnd = isnull(@dateEnd, getdate())
set @type = (Case When isnull(@type,0) not in (1,2) Then NULL Else @type end)
set @category = (Case When isnull(@type,0) not in (1,2) Then NULL Else (Case @type WHEN 1 Then 6 Else 5 End ) end)

declare @result table 
( --id integer not null identity, 
 usesType integer, 
 usesTypeName varchar(100), 
 categoryCode integer, 
 cRKindCode integer not Null, 
 cRKindName varchar(600) NULL, 
 countRh integer null, 
 countCl integer null,
 countObj integer null,
 sPaid money null, 
 sComm money null, 
 primary key (cRKindCode,usesType) )

--Матрица для вывода
delete @result
insert into @result (usesType, usesTypeName, cRKindCode, cRKindName, categoryCode)
select distinct usesType, usesTypeName, kindCode, kindName, (CASE WHEN usesType =1 Then 6 else 5 end)
   from  vAgrLicenseType
   where UsesType = isnull(@type, usesType)
union 
select 0, '',0, 'Всього',0
--------------------------------
--Сколько всего правообладателей по видам использования
;with TabRH as 
(select count(*) as countRH, CRKindCode
  from vCustCmService 
  where agrStatusRH = 2 and ourService = 1
  group by CRKindCode
)
update @result set countRh = t2.countRh 
  from @result t1 
   join TabRH t2 on t1.cRKindCode = t2.CRKindCode 
--------------------------------

--Остатки по собраным
create table #TmpR 
(id integer not null primary key,
 clCustId integer, 
 objid integer, 
 accIdDebet integer,
 accIdCredit integer,
 kindCode integer, 
 categoryCode integer,
 amount money 
)
delete #TmpR  
insert into #TmpR  
(id, clCustId,  objid, accIdDebet, accIdCredit, kindCode,  categoryCode, amount) 
 select id, clCustId,  objid, accIdDebet, accIdCredit, kindCode,  categoryCode, amount 
   --from dbo.ft_Tsk_5_COLLECTED   ('2019-01-01', NULL, NULL, NULL) --(@dateBegin, @dateEnd, @category, NULL) 
   from dbo.ft_Tsk_5_COLLECTED   (@dateBegin, @dateEnd, @category, NULL) 

--корректирую матрицу - если часть счета не соответствует справочнику 
insert into @result (usesType, usesTypeName, cRKindCode, cRKindName, categoryCode)
select distinct (CASE WHEN categoryCode = 6 Then 1 else 2 end) as usesType, 
                  (CASE WHEN categoryCode = 6 Then 'Великі права' else 'Малі права' end), 
				  kindCode, '', categoryCode
   from  #TmpR t1 
   where t1.categoryCode = isnull(@category, t1.categoryCode)
    and not exists ( select 1 from @result t2 where t1.categoryCode = t2.categoryCode and t2.cRKindCode = t1.kindCode)

update @result set crKindName = t2.name + '!'
  from @result t1 
      join CopyrightKind t2 on t1.cRKindCode = t2.codeI 
   where isnull(t1.cRKindName, '' ) ='' 

-----------------
--остатки
;With TabGr as 
(select  categoryCode, kindCode, sum(amount) as amount, count (distinct clCustId) as countCl, count (distinct objid) as countObj  
   from #TmpR 
   group by categoryCode, kindCode
)
update @result set sPaid = amount, 
       countCl = t2.countCl, 
	   countObj = t2.countObj
 from  @result t1 
       join TabGr t2 on t1.categoryCode = t2.categoryCode and t1.cRKindCode = t2.kindCode

--Собрано комиссий от партнеров --не могу разбить на виды права - будет общая сумма
--ВСЕГО 
;with TabCl as 
(select distinct accIdCredit, clCustId from #TmpR 
)
 update @result set sComm = 
  (select sum(amount) 
    from TabCl t1 
	 join PayTurn t2 on t1.accIdCredit = t2.accIdCredit and t2.accDebet like '40%' )
   where cRKindCode = 0

--ВСЕГО 
;with TabSum as 
(select 0 as cRKindCode, max(isnull(countRh,0)) as countRh, max(isnull(countCl,0)) as countCl, sum(isnull(countObj,0))  as countObj, sum(sPaid) as sPaid
  from @result )
update @result set countRh = t2.countRH, countCl = t2.countCl, countObj = t2.countObj, sPaid = t2.sPaid
  from @result t1 
   join TabSum t2 on t1.cRKindCode = t2.cRKindCode

select usesType, usesTypeName, cRKindCode, cRKindName, countRh, sPaid,  sComm, countCl, countObj
 from @result
 order by usesType,cRKindCode
end

--exec pTsk_5_2_CrKind 0, '2019-01-01'

GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pTsk_5_2_CrKind] TO [ReportUser]
    AS [dbo];

