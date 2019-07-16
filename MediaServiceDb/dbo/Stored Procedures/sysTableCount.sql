CREATE procedure [dbo].[sysTableCount]  @a varchar (40)
 
as
--[sp__DBCC CHECKIDENT] TEST
BEGIN
SET NOCOUNT ON; 

declare @e varchar(8000)
--declare @a varchar (20)
--drop table #tab1
--set @a='SO_UCARR'
set @e='
select ROW_NUMBER()over(order by t1.name) id, 
  convert(varchar(40), t1.name) t_name , 0 count_zap into #tab1
from --'+@a+'..
sysobjects t1
where --(t2.status & 0x80)>0 and
--t1.id=t2.id and 
t1.type=''U''
order by t1.name 
--exec (@e)

declare @id bigint
declare @t_name varchar(40)
declare @d varchar(2000)
declare cur cursor for   select   id, t_name from #tab1
 open cur                                                   
    fetch cur into  @id,@t_name
  while @@fetch_status =0                                 
							begin
							--select  @d=''''
							select  @d=''
		declare @maxvalue int									
    	select  @maxvalue=count(*) from '+''+@a +'..'+'''+@t_name+'' 
		update #tab1 set count_zap = @maxvalue where id=''+ convert(varchar(10),@id)
     exec(@d)
	 fetch cur into  @id,@t_name
 end
close cur   
deallocate cur 
select * from #tab1
'
--select @e
exec (@e)

END
  
--exec sysTableCount SO_ucarr