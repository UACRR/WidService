

CREATE procedure  [dbo].[pTsk_5_18_1_ObjUnattached] (@date date = NULL)
as
begin
--Остатки  по счету 31 с комментариями
--drop table #RT
create  TABLE #RT
( id integer not null identity primary key, 
  objid integer  null, 
  objName varchar(256) NULL, 
  performer varchar(512) null, 
  authorMus  nvarchar(2048) null, 
  authorText nvarchar(2048) null, 
  rHolder varchar(2048) null, 
  fullRate numeric(6,3) null,
  amountCollect money null, 
  amountNoshare money null,    
  comment nvarchar(2048) null
)

--set @date = isnull(@date,getdate())

--Остатки по 31 счету
insert into #RT (objid, amountNoshare) 
select objId, t2.rest
   from Account t1
    join SaldoDay t2 on t1.accId = t2.accId 
	where @date between t2.dateBegin and t2.dateEnd 
	      --getdate()  between t2.dateBegin and t2.dateEnd 
	       and t1.balsCode = 31 
		   and t2.rest <> 0

update #RT set objName = t2.name, performer = t2.performer, authorText = t3.lyrics, authorMus = t3.composers
    from #RT t1 
	 join ObjectRight t2 on t1.objId = t2.objId 
	 left join MediaTrack t3 on t2.objId = t3.objId 

update #RT set fullRate = t2.fullRate 
  from #RT t1,  
  (select t2.objId, sum(isnull(rate,0)) as fullRate 
  from #RT t1 
    join CopyRight t2 on t1.objId = t2.objid and @date between t2.beginDate and t2.endDate and isnull(t2.status,0) = 1 
	group by t2.objId) t2 
  where t1.objid = t2.objid 


--Комментарии по ошибкам
create table #TmpStatus(
objid			int,
custName		nvarchar(256),
isNoAgr smallint, 
isNoRate smallint, 
primary key (objid,custName)
)

insert #TmpStatus 
select distinct t2.objid, t4.name as custName, (Case When (isnull(t3.agrStatus,0) <> 2  and t4.custType <> 5) Then 1 Else 0 END) , (Case WHen isnull(t2.status,0) <> 1 Then 1 Else 0 END) 
 from #RT t1 
      join copyright t2 on t1.objid = t2.objId
	  left join AgreementMaster t3 on t2.custId = t3.custId 
	  join vCustomer t4 on t2.custId = t4.custId
 where
--@date between isnull(t2.beginDate,'1900-01-01') and isnull(t2.endDate, '3000-01-01')	and
'20190227' between isnull(t2.beginDate,'1900-01-01') and 	isnull(t2.endDate, '3000-01-01')  and
    (isnull(t3.agrStatus,0) <> 2  and t4.custType <> 5)  --не внешний, но договор не подписан
    OR 
	(isnull(t2.status, 0) <> 1 )

update #RT set comment = 'Відс.угода з пр.-' + t2.comment
  from #RT t1, 
  (select distinct objid, STRING_AGG (custName, ';') as comment
  from #TmpStatus 
  where isNoAgr = 1
  group by objid ) t2 
where t1.objid = t2.objid

update #RT set comment = isnull(t1.comment,'')  + 'Не підтв.права-'
  from #RT t1, 
  (select distinct objid, STRING_AGG (custName, ';') as comment
  from #TmpStatus 
  where isNoRate = 1
  group by objid ) t2 
where t1.objid = t2.objid

select * from #RT
RETURN ;
END;


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pTsk_5_18_1_ObjUnattached] TO [ReportUser]
    AS [dbo];

