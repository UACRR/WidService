
CREATE PROCEDURE [dbo].[CatalogControlPub] @fileId integer, @result  varchar(100) OUT, @RetCode integer OUTPUT 
as
begin

---Контроль каталога издателей
--1) Объект уже открыт; 2) % > 100 
--Алгоритм. 1) Если есть такой объект с др.% - закрываю и создаю новый crightId. 2)Если у издателя есть объекты, которых нет в каталоге - закрываю crightId. 3) Открываю новые объекты с crightId.
--4) Исполнителей дописываем (если такого нет) для поиска из отчетов.
--20-05-2019
--27-05-31 --оптимизация, контроль издателя
--17-06-2019 кавычки
--12.07.2019 - дубли
--19-07-2019 - пробелі в названии правообладателя
SET NOCOUNT ON;
--declare @RetCode integer
set @RetCode = 0

If exists (select  1 from vMyAnk where typeAlg = 1 )
 EXEC CatalogControlPubAF @fileId, @result OUTPUT, @RetCode  OUTPUT

If exists (select  1 from vMyAnk where typeAlg = 2 )
 EXEC CatalogControlPubAS @fileId, @result OUTPUT, @RetCode  OUTPUT

return --@Retcode
END
/*
DECLARE @result VARCHAR(100), @RetCode integer;
exec CatalogControlPub 6014, @result OUTPUT, @RetCode  OUTPUT
select @result, @retCode
*/
