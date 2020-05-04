--Відкриття обєктів права без виконавців
--update loads..ImportObject set perId = NULL, objid = NULL

---------------------------------------------------------
CREATE PROCEDURE [dbo].[Intr_IO_OpenObjects]
as
begin

--Открытие объектов права

 create table #TmpObj
( id	integer primary key, 
  innerCode integer,  
  objName	varchar(200), 
  categoryCode	integer, 
  genreType integer, 
  genreName varchar(200), 
  author varchar(512), 
  lirics varchar(512), 
  composers varchar(512), 
  performers varchar(512), 
  objid	integer
  )

--------------------------------------------------------------
------Контроль 
--Жанри
  update loads..ImportObject 
     set errFlag = 1, errComment = 'Не знайдено жанри'
     from  loads..ImportObject t1 
     where t1.genreCode = 0  --специально без NULL
        and workFlag = 1

----Объекты права уже есть
/*  ---Пока как ошибка
 update loads..ImportObject set objid = t2.objid 
     from loads..ImportObject t1 
       join objectRight t2 on upper(REPLACE(t2.name,' ','')) = upper(REPLACE(t1.objName,' ','')) collate Ukrainian_100_CI_AS 
	   and exists (select  1 from Authors t4  where t4.objid = t2.objid 
	                     and upper(REPLACE(t4.authorName,' ',''))  like '%'+upper(REPLACE(t1.authors,' ',''))+'%' collate Ukrainian_100_CI_AS )
*/
 update loads..ImportObject set objid = t2.objid, ErrFlag = 1,  errComment = 'Знайдено об''єкти права'
     from loads..ImportObject t1 
       join objectRight t2 on upper(REPLACE(t2.name,' ','')) = upper(REPLACE(t1.objName,' ','')) collate Ukrainian_100_CI_AS 
	   and exists (select  1 from Authors t4  where t4.objid = t2.objid 
	                     and upper(REPLACE(t4.authorName,' ',''))  like '%'+upper(REPLACE(t1.authors,' ',''))+'%' collate Ukrainian_100_CI_AS )
	                     and t1.objInnerCode = t2.innerCode
     where t1.workFlag = 1

--------------------------------------------------------------

--Объекты в одном экземпляре по шифру
delete #TmpObj
insert into #TmpObj (id, innerCode,  objname, categoryCode, genreType, author, lirics, composers, performers, genreName) 
select  wid_id,  max(objInnerCode), max(objname), max(categoryCode), max(genreCode), max(authors), max(lyrics), max(composers), max(performers), max(ltrim(genreName))
  from loads..ImportObject  
  where isnull(objid,0) = 0 
      and workFlag = 1   --отмеченные
      and isnull(errFlag,0) = 0
  --group by objInnerCode 
  group by wid_id


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
         select  objName, categoryCode, genreType, author, 0, id, innerCode
           from #TmpObj 

          update #TmpObj 
             set objid = t2.objid
            from #TmpObj t1 
                join #TabId t2 on t1.id = t2.id

         insert into MediaTrack (objId, iswc, name, lyrics, composers, performers, Album, genre, numberInAlbum, year, label, modifyDate, modifyLogin, duration)
		  select objid, 
		        NULL, objName, 
		        lirics, composers, performers, NULL, genreName, NULL, NULL, NULL, getdate(), NULL, NULL
		    from #TmpObj
		 
         insert into Authors (authorName, objId, roleCode, custId, isFolkOrUnknown, folkType) 
		  select t2.authorNameOpen,t3.objid, 
		  t2.rolecode, t2.custId, NULL, (Case WHEN isnull(t2.folkType,0) in (0,1) Then 1 else t2.folkType end )
		   from loads..ImportObject t2 
                   join #TabId t3 on t2.wid_id = t3.id
		     and t2.roleCode <> 3  --не виконавці

-----------
      update loads..ImportObject set objid = t3.objid
	     from  loads..ImportObject t1 
                 join #TabId t3 on t1.wid_id = t3.id

-------------Исполнители ---------------------
  create table #TabId1 (perId integer not null primary key, idPerLoad integer)

  --в имя прописываю идентификатор, чтобы открыть пракетом. Потом заменю.
  insert into Performer (perName)
   output inserted.perId, cast(inserted.perName as integer) into #TabId1 (perId, idPerLoad)
   select distinct cast(idPerLoad as varchar(10)) 
    from loads..ImportObject t1 
      join #TmpObj t2 on t2.objid = t1.objid
     where roleCode = 3 
         and isnull(perId,0) = 0 

  update loads..ImportObject  set perId  = t3.perid 
  from loads..ImportObject t1 
       join #TabId1 t3 on t3.idPerLoad = t1.idPerLoad
   where RoleCode = 3

 --поменяются все имена
  update Performer  set perName  = t2.authorName 
  from Performer t1 
      join loads..ImportObject t2 on t1.perId = t2.perId 
      join #TmpObj t3 on t3.objid = t2.objid
   where roleCode = 3 

   insert into RelObjPerformer (perId, objid)
      select distinct t1.perid, t1.objid 
         from loads..ImportObject t1 
          join #TmpObj t2 on t2.objid = t1.objid
         where isnull(perid,0) <> 0 and 
           not exists (select  1 from RelObjPerformer t2 where t1.perid = t2.perid and t1.objid = t2.objid)

insert into SeekObject (codeI, objId, name)
select 2, objid, pername
from vRelObjPerformer t1 
 where isnull(t1.pername, '') <> ''  and not exists 
  (select  1 from SeekObject t2 where t2.objid = t1.objid and replace(t1.pername,' ','') = replace(t2.name, ' ','') )


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

--exec Intr_IO_OpenObjects


