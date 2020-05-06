
CREATE function  [dbo].[ft_Tsk_5_22_BRcm]  (@dateBegin date = NULL, @dateEnd date = NULL)
-- Відомість розподіл АВ ВП зведена по ТОВ (4.0)
RETURNS @RT TABLE
(
cmCustId integer primary key, 
cmName varchar(200), 
amount money, 
rowNum integer, 
id integer identity
)
as
BEGIN

--Первый день месяца
set @dateBegin = isnull(@dateBegin, (select convert(date, (convert(char(4),year(getdate()))+'-01-'+ substring(convert(char(3),100+MONTH(getdate())),2,2) ))))
set @dateEnd = isnull(@dateEnd, getdate())

/*
declare @datebegin date, @dateEnd date
set @dateBegin = '2018-01-01'
set @dateEnd = '2018-12-31'
*/

insert into @RT (cmCustId, amount)
select isnull(cmCustId,-1), sum(amount)
  from ft_Tsk_5_DISTRIBUTED_CM (@dateBegin, @dateEnd, 6, NULL, NULL) 
  group by isnull(cmCustId,-1)

update @RT set cmName = isnull(t2.name, 'НЕ ВИЗНАЧЕНО')
   from @RT t1 
    left join vCustomer t2 on t1.cmCustId = t2.custId

	--Выстраиваю порядок для отображения
update @RT set rowNum = id
update @RT set rowNum = cmCustId where cmCustId < 0
update @RT set rowNum = 0  
 from @RT t1 join vCommunity t2 on t1.cmCustId = t2.cmCustId and t2.isMy = 1

RETURN
END

--select * from ft_Tsk_5_22_BRcm ('2018-01-01', '2019-02-28')

GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_22_BRcm] TO [ReportUser]
    AS [dbo];

