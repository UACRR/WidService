--drop procedure dbo.CRightMainInsert  
create procedure dbo.CRightMainInsert  
@cRType integer, @custId integer, @objid integer, @rate decimal(10,5), 
@lBasis integer = NULL,  @dateBegin date, @dateEnd date=NULL, @userId nvarchar(48) = NULL  
--Ввод главныъ прав
AS   
Begin
SET NOCOUNT ON;   
SET ANSI_WARNINGS OFF  
declare @Retcode integer, @ErrMsg varchar(200), @curDate datetime

Set @userId = isnull(@userId, current_user)
set @curDate = getdate()

Set @Retcode = 0
Set @ErrMsg = ''

If  (select sum(rate)+@rate from MainCopyRight where objId = @objId and cRType = @cRType ) >100
 BEGIN 
 set @ErrMsg = 'Перевищення 100%!'
 set @retCode = 1
 END 

 If @Retcode <> 0 
   Begin 
     Set @ErrMsg = 'Операцію відхилено!  '+@ErrMsg  
	 RAISERROR
    (N'%s',
    10, -- Severity.
    1, -- State.
    @ErrMsg  -- First substitution argument.
     ); -- Second substitution argument.
    Return @RetCode
   end

insert into MainCopyRight (custId, cRType, objId, rate, beginDate, endDate, lBasis, createDate)
select @custId, @cRType, @objId, @rate, @dateBegin, isnull(@dateEnd,dateadd(year,75,@dateBegin)), isnull(@lBasis,1), @curDate

end

--exec dbo.CRightMainInsert  1, 57, 1027, 30, 5, '2011-01-02', NULL, NULL  