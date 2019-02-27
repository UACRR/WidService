---Открытие неполных анкет с договорами ГО УААСП 
--Подготовка таблиці для работы процедуры
-------------------------------------------------
/*
--!!!--Проставить в Test..GO_InCRight custid
update Test..GO_InCRight set custId = NULL 
update Test..GO_InCRight set custId = t2.custId 
  from Test..GO_InCRight t1 
   join test..GO_InRhFo t2 on t1.idFo = t2.id

alter table Test..GO_InCRight 
add cmFlag integer null

update Test..GO_InCRight  
  set cmFlag = 1 where REPLACE (cmName, ' ','') = 'ГОУААСП'

 ;with Tab1 as 
 (select idRh, REPLACE (cmName, ' ','') as cmName
   from Test..GO_InCRight 
   where isnull(cmFlag ,0)<>1
   group by idRh, REPLACE (cmName, ' ','')
  ),
  TabCm as  
 (select idRh, count(*)  as kol
   from Tab1 group by idRh having count(*)=1)
   select distinct t1.idRh, cmName into test..Intr_GO_Community
    from TabCm t1 
	 join Test..GO_InCRight t2 on t1.idRh = t2.idRh
 where cmName <> 'НЕВИЗНАЧЕНИЙ'
order by 1

--select distinct cmName from test..Intr_GO_Community
-------------------------------------------------

--drop table #TmpRH 

create table #TmpRH 
(id integer not null, 
 rhName  varchar(200), 
 cmFlag integer, --1-наш 
 custId integer, 
 primary key (id) )

delete #TmpRH 
insert into #TmpRH (id, rhName, cmFlag) 
select idRh, max(rhName), max(isnull(cmFlag,0)) as cmFlag 
  from Test..GO_InCRight 
  where isnull(roleCode,0)<>3 and isnull(idRh,0)<>0 
  group by idRh

--update #tmpRH set custId = t2.custId 
--  from #tmpRH t1 
--   join vcustomer t2 on REPLACE(t1.rhName,' ', '') = REPLACE(t2.name,' ', '')

--select * from #tmpRH where cmflag <> 0

*/

--select * from Test..GO_InCRight where idRH is not NULL

CREATE PROCEDURE Intr_OpenAnkRh2 
as
begin

--Открытие правообладателей с анкетой и договором

SET NOCOUNT ON;
declare @RetCode integer
set @RetCode = 0


--drop table #TabId
create table #TabId (custId integer not null)

declare @id integer, @custId integer, @idp varchar(10), @cmFlag integer
declare cur cursor for  select id from #TmpRH  where isnull(custid,0) = 0  --and id in (101110,100310) ---and cmFlag = 1  --не исполнители свои

open cur                                                   

    fetch cur into   @Id
                                                  
    while @@fetch_status = 0                                                   
    BEGIN 

     begin Tran Intr1 
     BEGIN TRY

     delete #TabId 

     set @idp = convert(char(4),@id)
	 print @idp

       set @cmFlag = (select max(cmFlag) from #TmpRH  where id = @id)

       --Вставляю новые
       insert into customer (custType, status, ankVersion)
         output inserted.custId  into #TabId (custId)
         select  (Case @cmFlag When 1 Then 1 Else 5 end ) -- физлицо или внешний правообладатель, 
                 , 0, 1 
           from #TmpRH 
		   where id = @id

       set @custId = (select max(custId) from #TabId )

        update #TmpRH 
             set custId = @custId 
             where id = @id  

      insert into RightHolder (custId, rHolderType, aroundWord) 
		 select custId,  1, 1
		   from #TmpRH t1  
		   where id = @id 

    IF @cmFlag = 1 --наш
     BEGIN

	   insert into Person (custId, version)
	   select @custId, 1

       insert into AnketaPerson 
		(custId, version, status, 
		 lastName, firstName, surName,
		 citizenship, residency, reCountry, faCountry, 
		 modifyDate,modifyLogin )
         select  t1.custId, 1, 0, 
                 --ФИО
                 (select dbo.ParseStr (t1.rhName, ' ', 1)), 
                 (select dbo.ParseStr (t1.rhName, ' ', 2)), 
                 (select dbo.ParseStr (t1.rhName, ' ', 3)), 
		 (Case cmFlag When 1 Then 804 else NULL end ), --citizenship
		 (Case cmFlag When 1 Then 1 else NULL end ),   --residency
		 (Case cmFlag When 1 Then 804 else NULL end ), --reCountry
		 (Case cmFlag When 1 Then 804 else NULL end ), --faCountry
		 getdate(), 'Input'
		  from #TmpRH t1 
			 where id = @id

	--Договор с правовласником (не будет технического!)
	insert into AgreementMaster (custId, agrStatus, modifyDate, modifyLogin, agrType, version)
		select @custId, 0, getdate(), 'input', 
                       1, --(Case cmFlag When 1 Then 1 Else 6 end) ,   --'Технічна угода з іншим'
                       1
                   from #TmpRH 
  		   where id = @id 

        insert into AgreementAddRH 
	    (agrId, custId, rateCommiss, rateCourt, version,agrNumber,agrDate, dateBegin, dateEnd, periodCode, dayForPay, ankVersion, agrStatus, getCode, modifyDate,modifyLogin)
		select t2.agrId, t1.custId, NULL, NULL,  
			   1, 'Tech-'+convert(varchar(10), t2.custId),  '2000-01-01', 
                           '2000-01-01', '3000-01-01', 
			   1, NULL, 1, 0, NULL, getdate(), 'Input'
		   from #TmpRH t1  
		    join AgreementMaster t2 on t1.custId = t2.custId 
		   where t1.id = @id 

   END 

  ELSE 
---Чужие правовласники (из др.сообщества)
    BEGIN 
      insert into AnketaExternal (custId,name,interCode,countryCode,innOkpo)
         select  t1.custId, t1.RhName, NULL, NULL,NULL 
		  from #TmpRH t1 
			 where id = @id

    END 

       --Права 
    insert into TermsOfService (custId, crKindCode, ourService) 
		   select  @custId, t1.codeI, (Case  @cmFlag WHEN 0 Then 0 Else 1 END)
		    from CopyrightKind t1

    update Test..GO_InCRight set custId = @custId 
	     from Test..GO_InCRight t1 
		 join #TmpRH t2 on t1.idRh = t2.id
		 and t2.id = @id

IF @@TRANCOUNT > 0 commit tran
END TRY


   BEGIN CATCH
     IF @@TRANCOUNT > 0 rollback tran
  

     SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_SEVERITY() AS ErrorSeverity  
        ,ERROR_STATE() AS ErrorState  
        ,ERROR_PROCEDURE() AS ErrorProcedure  
        ,ERROR_LINE() AS ErrorLine  
        ,ERROR_MESSAGE() AS ErrorMessage;  

        set @Retcode = 1
    return @Retcode
    END CATCH

    fetch cur into   @id
    END                                                   

close cur   
deallocate cur      

return @Retcode
END


--exec Intr_OpenAnkRh2 