CREATE PROCEDURE [dbo].[CatalogInputRH] @fileId integer, @result  varchar(100) OUT, @RetCode integer OUTPUT
as
begin
---Загрузка каталога Авторов
--Обрабатываю только status = 1 
--Алгоритм. 
--1) Если есть такой объект с др.% - закрываю и создаю новый crightId. 
--2) Если у Автора есть объекты, которых нет в каталоге - открываю эти объекты. 
--3) Если проставлены проценты по соавторам нашего ОКУ - добавляю в crightId все права. Автор каталога - подтвержден, соавторы - не подтвержден. 
--4) Если у соавтора др.% - не вношу его % из реестра. Это ошибка. 
--5) Если передан объект права с % = 0 по Автору. Все как обычно (создаю объект права, если нет). Если владелец каталога - закрываю его права. Если по соавтору %=0 - ничего не делаю, просто добавляю в авторы. 

SET NOCOUNT ON;
--declare @RetCode integer
set @RetCode = 0

If exists (select  1 from vMyAnk where typeAlg = 1 )
 EXEC CatalogInputRHAF @fileId, @result OUTPUT, @RetCode  OUTPUT

If exists (select  1 from vMyAnk where typeAlg = 2 )
 EXEC CatalogInputRHAS @fileId, @result OUTPUT, @RetCode  OUTPUT

return --@Retcode
END

/*
DECLARE @result VARCHAR(100), @RetCode integer;
exec CatalogInputRH 5011, @result OUTPUT, @RetCode  OUTPUT
--exec CatalogControlRH 5011, @result OUTPUT, @RetCode  OUTPUT
select @result, @retCode
--
*/