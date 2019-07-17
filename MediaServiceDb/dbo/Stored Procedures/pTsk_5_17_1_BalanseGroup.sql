CREATE procedure [dbo].[pTsk_5_17_1_BalanseGroup] (@dateBegin date = NULL, @dateEnd date = NULL)
 as
begin
/*   баланс   */

set @dateBegin = isnull(@dateBegin, (select convert(date, (convert(char(4),year(getdate()))+'-01-01'))))
set @dateEnd = isnull(@dateEnd, getdate())
if @dateBegin > @dateEnd 
	return

declare  @result table (
	codeI					integer not Null,
	balsname				varchar(100) NULL,
--	accname				varchar(100) null,
--	accid					int				,
	rest_begin_D		money null,
	rest_begin_K		money null,
	turn_D					money null,
	turn_K					money null,
	rest_end_D			money null,
	rest_end_K			money null,
 primary key (codeI) )

 insert  @result
 select 	t1.codeI ,	t1.name balsname	,	--t2.accname	, 	t2.accid	,	
				 0 rest_begin_D	,0	rest_begin_K	
				 ,isnull(sum(t3.deboborot),0)	turn_D,
				 isnull(sum(t3.krdoborot),0)	turn_K ,
			     0 rest_end_D,	  0 rest_end_K
			from AccountBals t1 
			left join Account t2 on (t2.balsCode =t1.codeI )
			left join SaldoDay t3 on (t2.accId = t3.accid and t3.dateBegin between @dateBegin and @dateEnd 
			)
group by t1.codeI, t1.name

merge @result  as target
using (   select 	t1.codeI 					 
				 ,isnull(sum(case  when t3.rest > 0 then t3.rest else 0 end),0)	rest_D
				 ,isnull(sum(case  when t3.rest < 0 then -t3.rest else 0 end),0)	rest_K			    
				 ,isnull(sum(case  when t4.rest > 0 then t4.rest else 0 end),0)	rest_end_D
				 ,isnull(sum(case  when t4.rest < 0 then -t4.rest else 0 end),0)	rest_end_K			    
			from AccountBals t1 
			left join Account t2 on (t2.balsCode =t1.codeI )
			left join SaldoDay t3 on (t2.accId = t3.accid and dateadd(day,-1,@dateBegin) between t3.dateBegin and t3.dateEnd )
--			left join SaldoDay t3 on (t2.accId = t3.accid and @dateBegin between dateadd(day,-1,t3.dateBegin) and t3.dateEnd )
			left join SaldoDay t4 on (t2.accId = t4.accid and @dateEnd between t4.dateBegin and t4.dateEnd 
			)
			group by t1.codeI
		)   as source on (source.codeI = target.codeI) 

		when matched
then 
	update set 
			target.rest_begin_D = source.rest_D,
			target.rest_begin_K =source.rest_K,
			target.rest_end_D = source.rest_end_D,
			target.rest_end_K =source.rest_end_K;

select * from @result



end
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pTsk_5_17_1_BalanseGroup] TO [ReportUser]
    AS [dbo];

