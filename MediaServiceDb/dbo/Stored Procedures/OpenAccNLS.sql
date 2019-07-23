/****** Object:  StoredProcedure [dbo].[OpenAccNLS]    Script Date: 12.07.2019 15:24:06 ******/
--ALTER PROCEDURE [dbo].[OpenAccNLS]   
CREATE procedure [dbo].[OpenAccNLS] 
  @CustId  integer, @Objid  integer,  @r030 char(3) , @AccNls varchar(26) , 
           @AccName varchar(200) = NULL
AS   
--Открывает счет, который задал пользователь 
--Если  передается @CustId и/или @Objid - проверяется на наличие в соответствующих таблицах
--внутренние счета откріваются с @CustId = NULL и @Objid = NULL
--12-07-2019 -ограничение имени счета
Begin
SET NOCOUNT ON;   --отключение вывода кол-ва строк для оптимизации
declare @Retcode integer, @ErrMsg varchar(200), @ErrMsg2 varchar(200)
Set @Retcode = 0
Set @ErrMsg = ''

--Проверка входных параметров
 If isnull(@CustId,0) > 0 and  not exists 
    ( select 1 from Customer where CustId = @CustId ) 
  begin 
    Set @ErrMsg = 'Помилка клієнта!'
    Set @Retcode = 1
  end 

 If isnull(@Objid,0)>0 and not exists 
  ( select 1 from ObjectRight  where Objid = @ObjId ) 
  begin 
    Set @ErrMsg = @ErrMsg+ 'Помилка об'+''''+'єкта!  objId ====> ' + cast(@ObjId as varchar(20))
    Set @Retcode = 1
  end 

 If not exists ( select 1 from Currency t1 where t1.r030 = @r030) 
  begin 
    Set @ErrMsg = @ErrMsg + ' Валюта не робоча! R030 ==> ' + @r030
    Set @Retcode = 1
  end 

 If exists ( select 1 from Account t1 where t1.AccNls = @AccNls and t1.r030 = @r030 ) 
  begin 
    Set @ErrMsg = 'Такий рахунок вже відкритий! ==> ' +  ISNULL( @AccNls, 'NULL' )
    Set @Retcode = 1
  end 

 If (len(rtrim(@AccNls)) > 25 ) or not exists ( select 1 from AccountBals where CodeI = left(@AccNls,2)) 
  begin 
    Set @ErrMsg = @ErrMsg + ' Помилка рахунку! == > ' + @AccNls
    Set @Retcode = 1
  end 

  If @Retcode <> 0 
   Begin 
     Set @ErrMsg = @ErrMsg + ' Операцію відхилено!'
	 RAISERROR
    (N'%s',
    10, -- Severity.
    1, -- State.
    @ErrMsg  -- First substitution argument.
     ); -- Second substitution argument.
    Return @RetCode
   end

begin Transaction OpenAccount 
 BEGIN TRY

set @AccName = left( isnull(@AccName, dbo.ft_accOpenName(@accNls)), 100)

If isnull(@CustId,0) <> 0
begin

insert into Account   (balsCode, AccDK, CustID, R030, AccNls, DateOpen, AccName, AccStatus)
select t7.CodeI, t7.BalsType,  @custid, @r030, @AccNls, getdate(), @AccName, 0
from AccountBals t7 
where CodeI = convert(integer,left(@accNls,2))
     and  not exists 
  ( select 1 from Account t1 where t1.custId = @custid and t1.accNls = @AccNls and t1.r030 = @r030)
 end
---------------Object---------
If isnull(@Objid,0) <> 0
Begin

 insert into Account (AccStatus, balsCode, AccDK, ObjId, R030, AccNLS, DateOpen, AccName) 
  select 0, t7.CodeI,  t7.BalsType, @ObjId, @R030, 
     @AccNls, getdate(), @AccName 
     from AccountBals t7 
     where t7.CodeI = convert(integer,left(@accNls,2)) 
           and not exists ( select 1 from Account t1 where t1.r030=@r030 and t1.AccNls = @AccNls)
end 

--------Счета внутринние
If isnull(@Objid,0) = 0 and isnull(@CustId,0) = 0  and isnull(@AccNLS, '') <> ''
begin 
 insert into Account (AccStatus, BalsCode, AccDK,  R030, AccNLS, DateOpen, AccName) 
  select 0, t7.CodeI,  t7.BalsType,  @R030, @AccNLS, getdate(), @AccName 
     from AccountBals t7 
     where t7.CodeI not in (20, 21, 30, 31, 28, 29) 
           and left(@accNls,2) = convert(integer,t7.CodeI)
           and not exists ( select 1 from Account t1 where t1.r030=@r030 and t1.AccNls = @AccNls)
end 

 IF (@@TRANCOUNT > 0 ) commit tran
 Else rollback tran
 END TRY

BEGIN CATCH
  IF (@@TRANCOUNT > 0 ) rollback tran
    DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;
    SELECT @ErrorMessage = ERROR_MESSAGE(),
           @ErrorSeverity = ERROR_SEVERITY(),
           @ErrorState = ERROR_STATE();
    -- Use RAISERROR inside the CATCH block to return 
    -- error information about the original error that 
    -- caused execution to jump to the CATCH block.
    RAISERROR (@ErrorMessage, -- Message text.
               @ErrorSeverity, -- Severity.
               @ErrorState -- State.
               );
 set @Retcode = 1

END CATCH

Return @Retcode
END


/*
Exec  dbo.OpenAccNLS  NUll, Null,  980, '100001', 'Счет поступления средств из 1С (П)'  
Exec  dbo.OpenAccNLS  NUll, Null,  980, '110001', 'Счет для распределения (А)'  
Exec  dbo.OpenAccNLS  NUll, Null,  980, '180001', 'Счет кредиторской задолженности (A)'  
Exec  dbo.OpenAccNLS  NUll, Null,  980, '190001', 'Счет дебиторской задолженности (П)'  
Exec  dbo.OpenAccNLS  null, 7856,  '980', '311037856',NULL

*/