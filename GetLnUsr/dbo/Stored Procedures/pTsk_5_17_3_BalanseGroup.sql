CREATE procedure [dbo].[pTsk_5_17_3_BalanseGroup] (@dateBegin date = NULL, @dateEnd date = NULL ,@account varchar(20)=NULL)
 as
begin


set @dateBegin = isnull(@dateBegin, (select convert(date, (convert(char(4),year(getdate()))+'-01-01'))))
set @dateEnd = isnull(@dateEnd, getdate())
set @account =isnull(@account,'0')
if @dateBegin > @dateEnd 
	return




declare  @result table (
	
	account varchar(20),
	accname				varchar(100) null,
    date_begin			date,
	rest_begin_D		money null,
	rest_begin_K		money null,
	turn_D					money null,
	turn_K					money null,
	rest_end_D			money null,
	rest_end_K			money null,
 primary key (account ,date_begin)
 )



BEGIN   ----2
 insert  @result (account ,accname,date_begin,rest_begin_D,rest_begin_K,turn_D,turn_K,rest_end_D,rest_end_K)
 select 	t2.accnls,	t2.accName accname,
				isnull(dateBegin,@dateBegin)
				 ,0--isnull((case  when t3.rest > 0 then t3.rest else 0 end),0)	rest_D
				 ,0--isnull((case  when t3.rest < 0 then -t3.rest else 0 end),0)	rest_K			    
				 ,isnull(t3.deboborot,0)	turn_D,
				 isnull(t3.krdoborot,0)	turn_K ,
				 0 --isnull((case  when t3.rest > 0 then t3.rest else 0 end),0)	rest_end_D
				 ,0 --isnull((case  when t3.rest < 0 then -t3.rest else 0 end),0)	rest_end_K			    
			from
			 Account t2 
	--		left join SaldoDay t3 on (t2.accId = t3.accid and  '20180425'  <= dateBegin and dateEnd <= '20180701')
			--left
			 join SaldoDay t3 on (t2.accId = t3.accid and  @dateBegin  <= dateBegin and dateBegin <= @dateEnd)
			where 
		@account= t2.accNls
--			'100001'= t2.accNls
order by dateBegin


merge @result  as target
using (   select 	t2.accnls ,t2.accName accname,	t3.dateBegin
				 ,isnull((case  when t3.rest > 0 then t3.rest else 0 end),0)	rest_D
				 ,isnull((case  when t3.rest < 0 then -t3.rest else 0 end),0)	rest_K			    
			from 
			Account t2 
			left join SaldoDay t3 on (t2.accId = t3.accid and dateadd(day,-1,@dateBegin) between t3.dateBegin and t3.dateEnd )

--			left join SaldoDay t3 on (t2.accId = t3.accid and @dateBegin between dateadd(day,-1,t3.dateBegin) and t3.dateEnd )
			where @account=t2.accnls
		)   as source on (source.dateBegin = target.date_begin) 
		when  matched
then 
	update 
		set
		rest_begin_D=source.rest_d,
		rest_begin_K=source.rest_k;

--	insert values( source.accnls ,source.accname,@datebegin,source.rest_D,source.rest_K,0,0,source.rest_D,source.rest_K);

merge @result  as target
using (   select 	t2.accnls ,t2.accName accname,	t3.dateBegin
				 ,isnull((case  when t3.rest > 0 then t3.rest else 0 end),0)	rest_D
				 ,isnull((case  when t3.rest < 0 then -t3.rest else 0 end),0)	rest_K			    
			from 
			Account t2 
			left join SaldoDay t3 on (t2.accId = t3.accid and @dateEnd between t3.dateBegin and t3.dateEnd )
			where @account=t2.accnls
		)   as source on (source.dateBegin = target.date_begin) 
		when  matched
then 
	update 
		set
		rest_end_D=source.rest_d,
		rest_end_K=source.rest_k;

	--insert values( source.accnls ,source.accname,@dateend,source.rest_D,source.rest_K,0,0,source.rest_D,source.rest_K);



select * from @result
return
END   -- 2



end






GO
GRANT CONTROL
    ON OBJECT::[dbo].[pTsk_5_17_3_BalanseGroup] TO [ReportUser]
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pTsk_5_17_3_BalanseGroup] TO [ReportUser]
    AS [dbo];

