





CREATE PROCEDURE [dbo].[CatalogInputPub] @fileId integer, @result  varchar(100) OUT, @RetCode integer OUTPUT
as
begin
--11-05-2019. Добавила в SeekObject
---Загрузка каталога издателей
--Обрабатываю только status = 1 
--Алгоритм. 
--1) Если есть такой объект с др.% - закрываю и создаю новый crightId. 
--2) Если у издателя есть объекты, которых нет в каталоге - закрываю эти crightId. 
--3) Открываю новые объекты с crightId.
--4) Исполнителей произведений дописываем (если такого нет).
--27-05-2019 insert into Authors 
--03-06-2019 - в кол-во закрытых прав, если нет в каталоге
--18-06-2019 - народные
--23-07-2019 -- ИСПОЛНИТЕЛЬ ОГРАНИЧЕНИЕ О ДЛИНЕ
SET NOCOUNT ON;
--declare @RetCode integer
set @RetCode = 0

If exists (select  1 from vMyAnk where typeAlg = 1 )
 EXEC CatalogInputPubAF @fileId, @result OUTPUT, @RetCode  OUTPUT

If exists (select  1 from vMyAnk where typeAlg = 2 )
 EXEC CatalogInputPubAS @fileId, @result OUTPUT, @RetCode  OUTPUT

return --@Retcode
END

/*
DECLARE @result VARCHAR(100), @RetCode integer;
exec CatalogInputPub 6040, @result OUTPUT, @RetCode  OUTPUT
--exec CatalogControlPub 6040, @result OUTPUT, @RetCode  OUTPUT
select @result, @retCode
--update pubCatalogItem set status = 0, objid = NULL, cRightId=NULL where fileId = 2088
--update CatalogFile set status = 0 where fileId = 6040
select * from CatalogFile
select * from pubCatalogItem where fileId = 6040
--Удаление каталога
delete DeleteObjectRight
insert into DeleteObjectRight
( objId, genreType, name, author, performer, categoryCode, actCode, loadId, sourceName, status )
select objId, genreType, name, author, performer, categoryCode, actCode, loadId, sourceName, 0 
   from ObjectRight 
   where sourceName = 'CAT_umig_new_2016_CORRECT2.xlsx'
   --where objid in (7860, 7862)

exec  DelObjectRightTable
*/

