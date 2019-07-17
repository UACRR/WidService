CREATE Function ft_Tsk_5_ForPayFact (@dateBegin date = NULL, @dateEnd date = NULL, @cmCustID integer = NULL, @rateCommiss decimal(7,5) = NULL)
-- @cmCustId = 0-все 
-- @rateCommiss - по конкретной комиссии. NULL / -1 - все комиссии

RETURNS @RT TABLE
(
custId integer not null, 
amount money, 
kindCode integer not null, 
custIdRh integer not null, 
custIdCm integer, 
amount_sum money, 
rateCommiss money, 
amountCommiss money, 
primary key (custId, kindCode, custIdRh)
)
AS
BEGIN  

--declare @dateBegin date, @dateEnd date, @cRightKind integer, @category integer
set  @dateBegin  =  (Case WHEN isnull(@dateBegin , '1900-01-01') ='1900-01-01'
                    THEN convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102)
                    ELSE @dateBegin  END)
set @dateEnd = isnull(@dateEnd, getdate())


set @rateCommiss = (Case When isnull(@rateCommiss,-1) = -1 Then NULL Else @rateCommiss end)
set @cmCustID = (Case When isnull(@cmCustID,0) = 0  Then NULL Else @cmCustID end)

insert into @RT (custId, kindCode, custIdRh, custIdCm, amount_sum, rateCommiss, amountCommiss, amount )
select t1.custId, kindCode, custIdRh, isnull(custIdCm, t1.custId), amount_sum, rateCommiss, amountCommiss, amount
  from PayTurnCm t1
   where t1.dateWork between @dateBegin and @dateEnd 
  --where t1.datework between '2019-01-01' and '2019-02-28'
      and isnull(t1.custIdCm, t1.custId) = isnull(@cmCustId, isnull(t1.custIdCm, t1.custId))
	  and isnull(t1.rateCommiss,0) = isnull(@rateCommiss, isnull(t1.rateCommiss,0))
  RETURN
END
--select * from ft_Tsk_5_ForPayFact (NULL, NULL, 138, NULL)
GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_ForPayFact] TO [ReportUser]
    AS [dbo];

