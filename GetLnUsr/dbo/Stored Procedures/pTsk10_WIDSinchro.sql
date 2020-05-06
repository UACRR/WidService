
CREATE procedure [dbo].[pTsk10_WIDSinchro] 
as begin 
SET NOCOUNT ON;
--Устанавливает взаимосвязь между объектами права и авторами в WID и MediaService(MS)
--По международным кодам запись сразу в таблицы синхронизации - RepMSWIC,  RepMSIPI
--По совпадению - в таблицу TMPWIC. После проверки (ручной) нужно выполнить синхронизацию исполнителей, авторов, альтернативных названий из базы WID и записать в REP*

declare @retCode integer = 0

--create table TMPWIC (dateCreate datetime, WIC integer, objid integer, sumAllTogether float, id integer not null  identity  primary key)
--Проверка по названию и автору
 --drop table ##TmpWIC 
 create table ##TmpWIC 
 (WIC integer not null, 
  objid integer not null, 
  accName float, 
  author varchar(512),
  primary key (objid, WIC) ) 

 --drop table ##TmpMAXWIC
 create table ##TmpMAXWIC
 (WIC integer not null, 
  objid integer not null, 
  accName float, 
  author varchar(512),
  primary key (objid, WIC) ) 

--drop table ##TmpAuthor 
create table ##TmpAuthor 
(WIC integer not null,
 objid integer not null, 
 coeffName float, 
 coeffAuth float, 
 cntAuth integer, 
 sumAllTogether float,  
 primary key (WIC, objid)
)

-------------------
 insert into RepMSWIC (WIC, objId, dateCreate) 
 select t3.WIC, t2.objId, getdate()
  from Mediatrack t2 
     join WID_IPI..tblISWC t3 on t3.ISWC = t2.iswc
  where exists (select 1 from RepMSWIC t4 where t4.objId = t2.objId)
  
--Авторов по IPI 
 insert into RepMSIPI (custId, IP_BASE_NR, IPInr, dateCreate) 
 select t2.custId, t3.IP_BASE_NR, max(t3.IP_Name_NR), getdate()
  from vCustomerRHolder t2 
     join WID_IPI..TBLIPINAME t3 on t2.interCode = t3.Ip_Base_NR 
  where not exists (select  1 from RepMSIPI t4 where t4.Ip_Base_NR  = t2.interCode and t4.custId = t2.custId )
  group by t2.custId, t3.IP_BASE_NR

-------------------

delete ##TmpWIC
delete ##TmpMAXWIC
delete ##TmpAuthor 

declare @accuracy float = 0.4, @precision float = 0.001;
declare @i1 integer = 0, @iN integer = 0
declare @i2 integer = 5000
set @i1 = (select isnull(min(objid),0) from ObjectRight)
set @iN = (select isnull(max(objid),0)+1 from ObjectRight)

 WHILE @i1 < @iN
 BEGIN 

delete ##TmpWIC
delete ##TmpMAXWIC
delete ##TmpAuthor 

--declare @accuracy float = 0.4, @precision float = 0.001;
  insert into ##TmpWIC (objid, WIC, accName, author)
   select t1.objid, t2.WIC, 
     max(mediaservice.dbo.[Ft_tsk_3_Accurace_strong]( t2.name, t1.name, @precision )) as accName, 
	 max(t1.author)
    from ObjectRight t1
      join wid_ipi..wSeekObject t2 on left(REPLACE(t1.name,' ',''),3) = t2.nameIdx 
    where --t1.objId between 5000 and 10000  
	      t1.objId between @i1 and @i1 + @i2  
	     --t1.objId in (107168,107169) and
	      and  mediaservice.dbo.Ft_tsk_3_Accurace_strong( t2.name, t1.name, @precision ) > @accuracy
    group by t1.objid, t2.WIC 


---Беру с максимально похожим названием 
 ;with TabMax as 
 (Select objid, max(accName) as accName  
   from ##TmpWIC
   group by objid) 
 insert into ##TmpMAXWIC (objid, WIC, accName, author)
 select t2.objid, t1.WIC, t2.accName, t1.author 
    from ##TmpWIC t1 
       join  TabMax t2 on t2.objid = t1.objid  and t2.accName = t1.accName 

--Авторы с подходящим ФИО
--declare @accuracy float = 0.4, @precision float = 0.001; 
insert into ##TmpAuthor (WIC, objid, coeffName, coeffAuth, cntAuth)
select t1.WIC, t1.objId, max(coeffName) as coeffName, max(coeffAuth) as coeffAuth, count(*) 
  from 
( select t1.WIC, t1.objId, t1.accName as coeffName, dbo.[Ft_tsk_3_Accurace]( t5.lstName+isnull(' '+t5.fstName,''), t1.author, @precision ) as coeffAuth 
  from ##TmpMAXWIC t1
   join wid_IPI..wObjectAuthor t5 on t1.WIC = t5.WIC
 )  t1 
  where t1.coeffAuth > @accuracy
group by t1.objid, t1.WIC

update ##TmpAuthor set sumAllTogether = coeffName + coeffAuth

--Максимально подходящее значение
 insert TMPWIC (WIC, objId, dateCreate, sumAllTogether ) 
  select t1.WIC, t1.objId, getdate(), t1.sumAllTogether
   from 
   (select row_number() over( partition by t1.objid order by t1.objid, t1.sumAllTogether desc ) as rowid,
      t1.WIC, t1.objId, t1.sumAllTogether 
        from ##TmpAuthor t1
        where t1.sumAllTogether  > @precision*2
   ) t1
   where t1.rowid = 1
   
   Print convert(char(10), @i1)+' - '+ convert(char(10), @@RowCount)
  
   set @i1 = @i1 + @i2+1
   
-------------

 END
return @retcode 
END 

--select * from TMPWIC 
--delete TMPWIC 
 --select * from ##TmpWIC
 --select * from ##TmpMAXWIC 
