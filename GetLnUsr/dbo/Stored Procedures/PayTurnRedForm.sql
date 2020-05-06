CREATE procedure [dbo].[PayTurnRedForm]
as BEGIN 
SET NOCOUNT ON 
/*
  --drop table PayTurnRed
  create table PayTurnRed
  (
   redId integer not null identity, 
   dateWork date not null, 
   turnId integer not null, 
   turnIdRed integer null, 
   dateWorkRed date null, 
   amount money not null, 
   AmountRest money, 
   accId integer, --счет 31
   redType integer null, 
   dateCreate datetime, 
   primary key (redId)
   )
*/
--select * from PayTurnRed
--  drop table #TmpRed
--Type=1 - на технический, 4 - @amount21 > @amount31, 3-@amount21 <= @amount31
declare @retCode integer, @msg varchar(100)

  create table #TmpRed
  (
   redId integer not null identity, 
   dateWork date not null, 
   turnId integer not null, 
   turnIdRed integer null, 
   dateWorkRed date  null, 
   amount money not null, 
   accId integer not null, 
   primary key (redId)
   )

   --drop table #Tmp31
   create table #Tmp31  
   (turnid integer not null, 
    dateWork date,  
    amount money, 
    accId integer, 
    primary key (turnId)) 
 
 --drop table #TmpR1 
  create table #TmpR1 
  (turnId integer not null, 
   dateWork date not null, 
  primary key (turnId, dateWork) )

  --Проводки на технический
--  delete PayTurnRed
  --31 - 30
  insert into PayTurnRed
  (dateWork, turnId, dateWorkRed, turnIdRed, amount, amountRest, accId, redType, dateCreate)
   select t1.dateWork, t1.turnId,  t1.dateWork, t1.turnId, t1.amount, t1.amount, accIdDebet, 1, getdate()
     from PayTurn t1
     where left(t1.accDebet,2) = '31' and left(t1.accCredit,2) = '30'
           and not exists (select 1 from PayTurnRed t2  where t2.turnId = t1.turnId and t2.dateWork = t1.dateWork)
   -- and t1.accidDebet = 328

---Проводки с технического - найти id для соответсвия и снимать
---Проводки дораспределения
  --21 - 31 
  delete #TmpRed
  insert into #TmpRed
  (dateWork, turnId, dateWorkRed, turnIdRed,  amount, accId)
   select t1.dateWork, t1.turnId, NULL, NULL, t1.amount, accIdCredit 
     from PayTurn t1
     where left(t1.accDebet,2) = '21' and left(t1.accCredit,2) = '31' 
           and not exists (select 1 from PayTurnRed t2  
                            -- where t2.turnIdRed = t1.turnId and t2.dateWorkRed = t1.dateWork)
							where t2.turnId = t1.turnId and t2.dateWork = t1.dateWork)
-- and accIdCredit = 328

 IF (select count(*) from #TmpRed ) > 0  --есть дораспределение
 BEGIN 

 declare @turnId21 integer, @dateWork21 date, @amount31 money, @amount21 money, @accId integer, @amountRest money, @amountRed money

 declare cur cursor  for  select turnId, dateWork, amount, accId  from #TmpRed  order by dateWork, turnId  --по проводкам дораспределения
  open cur                                                   
    fetch cur into  @turnId21, @dateWork21, @amount21, @accId
  
    set @msg = cast(@turnId21 as varchar(20))
	PRINT @msg 
	                                                
    while @@fetch_status = 0                                                   
    BEGIN 
    --Ищу проводки на технический, которые еще не погашены и снимаю, пока можно 
    --31 - 30 не погашенные
  set @amountRed  = @amount21
 
  WHILE @amount21>0 
    BEGIN 

  --ищу платежи 31-30 по счету 
   delete #TmpR1
   insert into #TmpR1 (turnId, dateWork)
   select max(t1.turnId), max(t1.dateWork)  
      from PayTurnRed t1
	  where t1.accId = @accId 
	      and isnull(AmountRest,0) > 0
	  having max(t1.turnId) is not null

   set @amount31 = (select amountRest 
      from #TmpR1 t1 
	   join PayTurnRed t2 on t1.turnId = t2.turnId and t1.dateWork = t2.dateWork)

   if @amount21 > @amount31 
   BEGIN 
    update PayTurnRed 
	  set  amountRest = 0
	  from #TmpR1 t1 
	   join PayTurnRed t2 on t2.turnId = t1.turnId and t2.dateWork = t1.dateWork

    --вставляю запись проводи дораспределения с минусом
	insert PayTurnRed (dateWork, turnId, turnIdRed, dateWorkRed, amount, amountRest, accId, redType, dateCreate)
       select @dateWork21, @turnId21, t1.turnId, t1.dateWork, -1*@amount31, NULL, t2.accId, 4, getdate()
        from #TmpR1 t1 
	    join PayTurnRed t2 on t2.turnId = t1.turnId and t2.dateWork = t1.dateWork
    END 

   --declare @amount31 money = 880, @amount21 money = 88,  @turnId21 integer = 46, @dateWork21 date = '2018-12-11'
   if @amount21 <= @amount31 
   BEGIN 
    update PayTurnRed 
	  set 
		  amountRest = amountRest - @amount21 
	  from #TmpR1 t1 
	   join PayTurnRed t2 on t2.turnId = t1.turnId and t2.dateWork = t1.dateWork

    --вставляю запись проводи дораспределения с минусом
	insert PayTurnRed (dateWork, turnId, turnIdRed, dateWorkRed, amount, amountRest, accId, redType, dateCreate)
       select  @dateWork21,  @turnId21,  t2.turnId, t2.dateWork, -1*@amount21, NULL, t2.accId, 3, getdate()
        from #TmpR1 t1 
	    join PayTurnRed t2 on t2.turnId = t1.turnId and t2.dateWork = t1.dateWork

    END 
   
    set @amount21 = @amount21 - @amount31 

  END

--------------
 --    if @@ERROR <> 0 
 --	  Return -1

     fetch cur into  @turnId21, @dateWork21, @amount21, @accId
    END                                                   
close cur   
deallocate cur      
END 
RETURN 0
end 
--exec PayTurnRedForm

--select * from payTurnRed 
--select * from payTurnRed  where turnId = 57
--select * from PayTurnRed where accId = 328
--select * from payTurn where 328 in (accIddebet, accIdCredit) order by dateOper
--delete payTurnRed
--select * from payturn where turnId in (57, 10803)
