--Відкриття обєктів права без виконавців
--use MediaService
--go
/*
--Народное - потом найти, отвязать и удаить
select * from test..Go_InCRight where rhName like '%народ%' and rolecode <>3
*/
/*
----ПОДГОТОВКА
update test..Go_InCRight 
set perId = NULL, objid = NULL

--drop table #TmpObj
create table #TmpObj
( id	integer primary key, 
  objName	varchar(200), 
  categoryCode	integer, 
  genreType integer, 
  author varchar(512), 
  lirics varchar(512), 
  composers varchar(512), 
  composersLirics varchar(512), 
  performers varchar(512), 
  genreName varchar(200), 
  objid	integer
  )

--Объекты в одном экземпляре по шифру
delete #TmpObj
insert into #TmpObj (id, objname, categoryCode, genreType, author, lirics, composers, composersLirics, performers, genreName, objid) 
select distinct innerCode, objname, categoryCode, genreType, author, lirics, composers, composersLirics, performers, genreName, objid
  from test..Go_InCRight where isnull(objid,0) = 0
*/

---------------------------------------------------------
CREATE PROCEDURE Intr_OpenObjects
as
begin

--Открытие правообладателей с анкетой и договором

--drop table #TabId
--drop table #TabPer
create table #TabId (objid integer not null, id integer)
create table #TabPer (perId integer null)

SET NOCOUNT ON;

declare @RetCode integer
set @RetCode = 0

declare @id integer, @objid integer, @idp varchar(10)

     begin Tran Intr1 
     BEGIN TRY

        delete #TabId 
         --Вставляю как заблоковані
        --ObjectRight
         insert into objectRight (name, categoryCode, genreType, author, status, loadid, innerCode)
         output inserted.objId, inserted.loadid into #TabId (objid, id)
         select  objName, categoryCode, genreType, author, 0, id, id
           from #TmpObj 

          update #TmpObj 
             set objid = t2.objid
            from #TmpObj t1 
                join #TabId t2 on t1.id = t2.id

         insert into MediaTrack (objId, iswc, name, lyrics, composers, performers, Album, genre, numberInAlbum, year, label, modifyDate, modifyLogin, duration)
		  select objid, 
		        NULL, objName, 
		        trim(isnull(lirics,'')+ (Case WHEN isnull(composersLirics,'') <> '' THEN '  '+composersLirics ELSE '' END)), 
				trim(isnull(composers,'')+ (Case WHEN isnull(composersLirics,'') <> '' THEN '  '+composersLirics ELSE '' END)), 
				performers, NULL, genreName, NULL, NULL, NULL, getdate(), NULL, NULL
		    from #TmpObj
		 
         insert into Authors (authorName, objId, roleCode, custId, isFolkOrUnknown, folkType) 
		  select t2.rHName,t3.objid, 
		  t2.rolecode, t2.custId, NULL, (Case isnull(t2.folkType,0) when 1 Then 3 else 1 end )
		   from test..Go_InCRight t2 
                   join #TabId t3 on t2.innerCode = t3.id
		     and t2.roleCode <> 3  --не виконавці

-----------
      update test..Go_InCRight set objid = t3.objid
	     from  test..Go_InCRight t1 
                 join #TabId t3 on t1.innerCode = t3.id

-------------Исполнители ---------------------
  create table #TabId1 (perId integer not null primary key, idPerTest integer)

  insert into Performer (perName)
   output inserted.perId, cast(inserted.perName as integer) into #TabId1 (perId, idPerTest)
   select distinct cast(idPerTest as varchar(10)) 
    from test..Go_InCRight 
     where roleCode = 3

  update test..Go_InCRight  set perId  = t3.perid 
  from test..Go_InCRight t1 
       join #TabId1 t3 on t3.idperTest = t1.idPerTest
   where RoleCode = 3

  update Performer  set perName  = t2.rhName 
  from Performer t1 
      join test..Go_InCRight t2 on t1.perId = t2.perId 
   where roleCode = 3

   insert into RelObjPerformer (perId, objid)
      select distinct perid, objid 
         from test..GO_InCRight 
         where isnull(perid,0) <> 0

-------------------------------------------------------

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

  
return @Retcode
END

--exec Intr_OpenObjects

--Очистка исполнителей
/*
delete RelObjPerformer where perId > 2 
delete Performer where perId > 2 
update test..GO_InCRight set perId = NULL
--DBCC CHECKIDENT (Performer,RESEED, 0)
*/