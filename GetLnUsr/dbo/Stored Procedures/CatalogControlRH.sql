
CREATE PROCEDURE [dbo].[CatalogControlRH] @fileId integer, @result  varchar(500) OUT, @RetCode integer OUTPUT 
as
begin

---Контроль каталога издателей
---Контроль каталога издателей
--1) Объект уже открыт; 2) % > 100 
--Алгоритм. 1) Если есть такой объект с др.% - закрываю и создаю новый crightId с подтверждением. 2) Открываю новые объекты с crightId с подтверждением. 
--3) Если у Автора % = 0 - закрываю право. 
--4) Если у соавтора % = 0 прописываю в авторы. 
--5) Если у соавтора % <> 0 и он с договором - прописываю право без подтверждения.
--6) Если у соавтора подтверждены др.% - не вношу его %. Это ошибка. 
--7) Дописываю (если такого нет) для поиска из отчетов.
--18-06-2019 Убираю кавычки, если они в начале и в конце 
--12-07-2019 - контроль на дубли
--23-09-2019 - разделение
SET NOCOUNT ON;
--declare @RetCode integer
set @RetCode = 0

If exists (select  1 from vMyAnk where typeAlg = 1 )
 EXEC CatalogControlRhAF @fileId, @result OUTPUT, @RetCode  OUTPUT

If exists (select  1 from vMyAnk where typeAlg = 2 )
 EXEC CatalogControlRhAS @fileId, @result OUTPUT, @RetCode  OUTPUT

return --@Retcode
END
/*
DECLARE @result VARCHAR(500), @RetCode integer;
exec CatalogControlRH 2108, @result OUTPUT, @RetCode  OUTPUT
select @result, @retCode
*/

