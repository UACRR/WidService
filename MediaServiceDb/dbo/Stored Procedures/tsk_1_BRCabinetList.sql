

                           
/*
1-ген всі; 1-всі, 2-активні, 3-не активні, 4-для пролонгації
2-ліцен; 1-всі, 2-активні, 3-не активні, 4-для пролонгації
3-заявки; 1-всі, 2-активні, 3-не активні
4-довідки; 1-всі, 2-активні, 3-не активні
5-не розподілені
6-борг
7-відсутні
*/
create procedure dbo.tsk_1_BRCabinetList  @docType integer, @status integer = NULL, @custId integer = NULL
  AS   
  SET NOCOUNT ON;   --отключение вывода кол-ва строк для оптимизации
BEGIN
if @status is NULL 
   set @status = 1

 If @docType = 1 --ГенУгоди
 begin 
  If @status = 1 --всі
  select * from vTSK_1_BRMaster 
     where isnull(@custId, custId) = custId
  If @status = 2 --активні
  select * from vTSK_1_BRMaster 
     where isnull(@custId, custId) = custId and agrStatus = 2
  If @status = 3 --активні
  select * from vTSK_1_BRMaster 
     where isnull(@custId, custId) = custId and agrStatus in (0,1)
  If @status = 4 --Для пролонгації
  select * from vTSK_1_BRMaster 
     where isnull(@custId, custId) = custId and agrStatus <> 4 and dateadd(day, 60, dateEnd) <=getdate()
 END

 If @docType = 2 --Ліцензії
 BEGIN 
  If @status = 1 --всі
  select * from vTsk_vBRLicense  where isnull(@custId, custId) = custId and licType  =1 
  If @status = 2 --активні
   select * from vTsk_vBRLicense  where isnull(@custId, custId) = custId and licType=1 and  licStatus = 2
  If @status = 3 --не активні
   select * from vTsk_vBRLicense  where isnull(@custId, custId) = custId and licType=1 and  licStatus in (0,1)
  If @status = 4 --пролонгація
   select * from vTsk_vBRLicense  where isnull(@custId, custId) = custId and licType=1 and  licStatus <> 4 
      and dateadd(day, 60, dateEnd) <=getdate()
 END
--3-заявки; 1-всі, 2-активні, 3-не активні
 If @docType = 3 --Заявки
 BEGIN 
  If @status = 1 --всі
  select * from vTsk_vBRLicense  where isnull(@custId, custId) = custId and licType = 2 
  If @status = 2 --активні
   select * from vTsk_vBRLicense  where isnull(@custId, custId) = custId and licType = 2 and  licStatus = 2
  If @status = 3 --не активні
   select * from vTsk_vBRLicense  where isnull(@custId, custId) = custId and licType=2 and  licStatus in (0,1)
 END

--4-довідки; 1-всі, 2-активні, 3-не активні
 If @docType = 4 --Заявки
 BEGIN 
  If @status = 1 --всі
  select * from vTsk_vBRLicense  where isnull(@custId, custId) = custId and licType = 3 
  If @status = 2 --активні
   select * from vTsk_vBRLicense  where isnull(@custId, custId) = custId and licType = 3 and  licStatus = 2
  If @status = 3 --не активні
   select * from vTsk_vBRLicense  where isnull(@custId, custId) = custId and licType=3 and  licStatus in (0,1)
 END

--5-не закріплені платежі
 If @docType = 5 --Заявки
 BEGIN 
  If @status = 1 --всі
  select * from vTsk_vBRLicense  where isnull(@custId, custId) = custId and licType = 3 
  If @status = 2 --активні
   select * from vTsk_vBRLicense  where isnull(@custId, custId) = custId and licType = 3 and  licStatus = 2
  If @status = 3 --не активні
   select * from vTsk_vBRLicense  where isnull(@custId, custId) = custId and licType=3 and  licStatus in (0,1)
 END

--6-борг
--7-відсутні р/л


END
--exec tsk_1_BRCabinetList 2,1, 142