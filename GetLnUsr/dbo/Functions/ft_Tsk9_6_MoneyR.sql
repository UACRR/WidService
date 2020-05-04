--drop function ft_Tsk_5_GetGive
CREATE function  ft_Tsk9_6_MoneyR  (@custId integer, @dateBegin date = NULL, @dateEnd date = NULL)
--Клієнт. Портал.
---Платежі за період  (CustId, dateBegin, dateEnd)
RETURNS @RT TABLE
(
paidid integer not null primary key,
clCustId integer,
numberInvoice varchar(32), 
dateInvoice date, 
goalInvoice varchar(256), 
amount money,
unDestribAmount money
)
as
BEGIN

--Первый день предыдущего месяца
--set @dateBegin = isnull(@dateBegin, dateadd(month, -1,  (convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102)))) 
set  @dateBegin =  Case @dateBegin When '1900-01-01' THEN 
                        dateadd(month, -1,  (convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))) 
                                   ELSE  isnull(@dateBegin, dateadd(month, -1,  (convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102)))) 
                                   END
set @dateEnd = isnull(@dateEnd, getdate())

 insert into @RT (paidId, clCustId, numberInvoice, dateInvoice, amount, unDestribAmount, goalInvoice) 
           select paidId, custId, numberInvoice, dateInvoice, amount, amount - isnull(destribAmount,0), goalInvoice
             from MoneyReceived where custId = @custId and dateInvoice between @dateBegin and @dateend
RETURN
END

--select * from ft_Tsk9_6_MoneyR (134, '2018-01-31', '2019-02-28') order by dateInvoice desc


GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk9_6_MoneyR] TO [ReportUser]
    AS [dbo];

