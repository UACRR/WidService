---------------
CREATE PROCEDURE dbo.IO_ObjectPrepare 
as begin 

SET NOCOUNT ON;

declare @RetCode integer = 0
declare @cnt integer = 0

---Подготовка для открітия объектов права
BEGIN Transaction ObjectPrepare
 BEGIN TRY

--проверка, что все правообладатели открыты
if exists ( select 1 from  LOADS..ImportObject where custid is NULL )
 BEGIN 
 --print 'Знаходимо відкритих правовласників'
 update LOADS..ImportObject set custid = t2.custid 
    from LOADS..ImportObject t1 
    join vCustomerRHolder t2 on t2.innerCode = t1.authorInnerCode and t2.interCode = t1.ipi

 update LOADS..ImportObject set custid = t2.custid 
    from LOADS..ImportObject t1 
    join vCustomerRHolder t2 on t2.interCode = t1.ipi
        where isnull(t1.custId, 0) = 0
 update LOADS..ImportObject set custid = t2.custid 
    from LOADS..ImportObject t1 
	   join vCustomer t2 on Replace(t1.authorName,' ','') = Replace(t2.name,' ','') collate Ukrainian_100_CI_AS
	   where isnull(t1.custId, 0) = 0
 END 
-------------------------------------------

-------Genre
 update loads..ImportObject set genreCode = t3.codei
    from loads..ImportObject t1 
	  join loads..export_genre t2 on t2.record_id = cast(t1.genreName as integer) 
	  join GenreType t3 on t3.codeI = t2.codeI
	  	   and t1.genreCode is null
--	  and t1.fileName = 'export_obj_2.csv'

update loads..ImportObject set genreCode = 9999 
where genreCode is null 


-------Role
 update loads..ImportObject set roleCode = t2.codei
    from loads..ImportObject t1 
	   --join CreativeRoleType t2 on upper(Replace(t1.roleName,' ','')) = upper(Replace(t2.name,' ','')) collate Ukrainian_100_CI_AS
	   join CreativeRoleType t2 on cast (t1.roleName as integer) = t2.codeI
       and roleCode is NULL 
--	   and fileName = 'export_obj_2.csv'

--Проверить какой код виконавці
 update loads..ImportObject set roleCode = 3
    from loads..ImportObject t1 
      where roleCode is NULL and roleName like 'виконав%'

---Community
 update loads..ImportObject set cmCustid = t2.custId
    from loads..ImportObject t1 
	   join vCustomerCommunity t2 on Replace(t1.cmName,' ','') = Replace(t2.name,' ','') collate Ukrainian_100_CI_AS

----Lyrics ---- Формирование списка авторов-------
 ;with TabL1 as 
 (
 select objInnerCode, 
            lyrics = STUFF (
                        (SELECT ', '+t2.authorName from loads..ImportObject t2 where t2.objInnerCode = t1.objInnerCode and t2.roleCode in (1,10) FOR XML PATH ('') ), 1, 1, ''
			          ), 
            composers = STUFF (
                        (SELECT ', '+t2.authorName from loads..ImportObject t2 where t2.objInnerCode = t1.objInnerCode and t2.roleCode in (2,10) FOR XML PATH ('') ), 1, 1, ''
			          ), 
            performers = STUFF (
                        (SELECT ', '+t2.authorName from loads..ImportObject t2 where t2.objInnerCode = t1.objInnerCode and t2.roleCode in (3) FOR XML PATH ('') ), 1, 1, ''
			          ),
            authors = STUFF (
                        (SELECT ', '+t2.authorName from loads..ImportObject t2 where t2.objInnerCode = t1.objInnerCode and t2.roleCode not in (3) FOR XML PATH ('') ), 1, 1, ''
			          )
 from loads..ImportObject t1 group by t1.objInnerCode
 )
 update loads..ImportObject 
  set lyrics = left(ltrim(t2.lyrics), 254), 
     composers = left(ltrim(t2.composers),254), 
	 performers = left(ltrim(t2.performers),254), 
	 authors = left(ltrim(t2.authors),254)
    from loads..ImportObject t1 
  join TabL1 t2 on t2.objInnerCode = t1.objInnerCode

     
--cmFlag 
update loads..ImportObject set cmFlag = 1 where REPLACE(cmName,' ','') like '%УААСП%' 
update loads..ImportObject set cmFlag = 0 where REPLACE(cmName,' ','') not like  '%УААСП%' 

------------FolkType----------------------------
update loads..ImportObject set FolkType = 3 where authorName like '%народ%'
update loads..ImportObject set FolkType = 2 where authorName like '%текст%' and FolkType is null 

------------------------------
-----Исполнители-------------
--Идентификатор в таблице
;with TabPer as 
(
select distinct authorName 
  from loads..ImportObject 
  where roleCode = 3 
), 
TabR as 
(select ROW_NUMBER () over(order by authorName ) as id, authorName 
  from TabPer 
 )
 update loads..ImportObject set idPerLoad = t2.id 
    from loads..ImportObject t1 
	  join TabR  t2 on t2.authorName = t1.authorName and t1.roleCode = 3 

--Поиск уже открытых исполнителей
--update loads..ImportObject set perId = NULL 

update loads..ImportObject set perId = t2.perId 
  from loads..ImportObject t1 
  join Performer t2 on REPLACE(upper(t2.perName),' ','') = REPLACE(upper(t1.authorName),' ','') collate Ukrainian_100_CI_AS 
      and t1.roleCode = 3 

--------------------------------------
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

END CATCH

---Проверки
set @cnt =  (select count(distinct authorNameOpen) from loads..ImportObject where rolecode <> 3 and custid is null and cmFlag = 1)
print 'Авторів для відкриття - ' + convert(char(10),@cnt)

set @cnt =  (select count(*) from loads..ImportObject where rolecode  is null )
print 'Без ролі записів - ' + convert(char(10),@cnt)

set @cnt =  (select count(*) from loads..ImportObject where genreCode  is null )
print 'Без жанру записів - ' + convert(char(10),@cnt)

return @Retcode
END

--exec IO_ObjectPrepare 
