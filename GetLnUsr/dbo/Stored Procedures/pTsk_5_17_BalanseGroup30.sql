CREATE  procedure [dbo].[pTsk_5_17_BalanseGroup30] (@dateBegin date = NULL, @dateEnd date = NULL)
 as
begin


set @dateBegin = isnull(@dateBegin, (select convert(date, (convert(char(4),year(getdate()))+'-01-01'))))
set @dateEnd = isnull(@dateEnd, getdate())
if @dateBegin > @dateEnd 
	return

declare  @result table (
	bals					varchar (5) not Null,
	balsname				varchar(20) NULL,
--	accname				varchar(100) null,
--	accid					int				,
	rest_begin_D		money null,
	rest_begin_K		money null,
	turn_D					money null,
	turn_K					money null,
	rest_end_D			money null,
	rest_end_K			money null,
 primary key (bals) )

 insert  @result
 select 	SUBSTRING(accNls,1,5) bals,'Об''єкти по виду '+ SUBSTRING(accNls,4,2) balsname,	
				 0 rest_begin_D	,0	rest_begin_K	
				 ,isnull(sum(t3.deboborot),0)	turn_D,
				 isnull(sum(t3.krdoborot),0)	turn_K ,
			     0 rest_end_D,	  0 rest_end_K
			from 
			 Account t2 ,	SaldoDay t3
			 where
			 substring (t2.accNls,1,2) ='30'		and
			  t2.accId = t3.accid						and 
			  t3.dateBegin between @dateBegin and @dateEnd 
group by SUBSTRING(accNls,1,5),SUBSTRING(accNls,4,2)



merge @result  as target
using (   select 	SUBSTRING(accNls,1,5) bals 					 
				 ,isnull(sum(case  when t3.rest > 0 then t3.restbegin else 0 end),0)	rest_D
				 ,isnull(sum(case  when t3.rest < 0 then -t3.restbegin else 0 end),0)	rest_K			    
				 ,isnull(sum(case  when t4.rest > 0 then t4.rest else 0 end),0)	rest_end_D
				 ,isnull(sum(case  when t4.rest < 0 then -t4.rest else 0 end),0)	rest_end_K			    
			from
			 Account t2,SaldoDay t3,SaldoDay t4
			 where
			 substring (t2.accNls,1,2) ='30'		and
			 t2.accId = t3.accid	and 
			 dateadd (day,-1,@dateBegin) between t3.dateBegin and t3.dateEnd  and
			 t2.accId = t4.accid and 
			 @dateEnd between t4.dateBegin and t4.dateEnd 
			group by SUBSTRING(accNls,1,5)
			)   as source on (source.bals = target.bals) 

		when matched
then 
	update set 
			target.rest_begin_D = source.rest_D,
			target.rest_begin_K =source.rest_K,
			target.rest_end_D = source.rest_end_D,
			target.rest_end_K =source.rest_end_K;

select * from @result



end

--pTsk_5_17_BalanseGroup30

GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pTsk_5_17_BalanseGroup30] TO [ReportUser]
    AS [dbo];

