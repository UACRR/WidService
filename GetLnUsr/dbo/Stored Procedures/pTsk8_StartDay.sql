/****** Object:  StoredProcedure [dbo].[pTsk8_StartDay]    Script Date: 22.07.2019 11:30:56 ******/
CREATE procedure [dbo].[pTsk8_StartDay] (@date date = NULL)
as
begin
/*
--Стартові роботи дня
*/
SET NOCOUNT ON;
declare @RetCode integer
set @RetCode = 0
set @date = isnull(@date,convert(date, getdate(), 104))

   insert into SystemMessage (modifydate, nameMain, sysName, keyObj, text)  
   select getdate(), 'StarDay', 'StarDay ('+convert(char(10),@date)+')',  NULL, 'Стартові роботи за'+'('+convert(char(10),@date)+')'

--Удаляю сообщения старше 2 месяцев
  delete SystemMessage where datediff (month, modifydate, getdate()) >2
   insert into SystemMessage (modifydate, nameMain, sysName, keyObj, text)  
   select getdate(), 'StarDay', 'StarDay ('+convert(char(10),@date)+')',  NULL, 'Очистка системного журналу. Вилучено записів '+ltrim(rtrim(convert(char(20), @@ROWCOUNT)))


--Создание договоров по параметрам - автопролонгация, дата конца договора <=@date, status = активный. 
--После создания договора старый закрывается. 
execute dbo.pTsk8_LicProlongCreate @date

--Перевод договора будущего периода, подтвержденного (статус = 2) с dateBegin = @date  в активный (установка версим в LicenseAgreement). Старый договор закрывается. 
execute dbo.pTsk8_LicProlongActive @date 

--Создаются периоды расчетов по активным договорам. Период расчимтывается с 01 числа текущего месяца/квартала/полугодия/года. 
execute dbo.pTsk8_LicPeriodCreate @date

--Установка признака "Борг" на периоде (status = 3). Устанавливается, если undistribution <> 0 и разница @date и конца периода ( dateEnd ) больше месяца
execute dbo.pTsk8_LicPeriodBorg @date

--Удаление помеченніх договоров
exec pTsk8_AgrDelete

--Пересчет PayTurnRed
--Используется в ф-ии для доставания распределения по объектам с учетом оборотов и дораспределения - ft_Tsk_5_DistributedRed
exec pTsk8_PayTurnRedForm

return @Retcode
END

--exec dbo.pTsk8_StartDay


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pTsk8_StartDay] TO [ReportUser]
    AS [dbo];

