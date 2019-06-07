CREATE procedure [dbo].[pTsk_5_17_2_BalanseGroup] (@dateBegin date = NULL, @dateEnd date = NULL ,@account varchar(20)=NULL)
 as
begin
/*   Розширений баланс   */

set @dateBegin = isnull(@dateBegin, (select convert(date, (convert(char(4),year(getdate()))+'-01-01'))))
set @dateEnd = isnull(@dateEnd, getdate())
set @account =isnull(@account,'0')
if @dateBegin > @dateEnd 
	return


	declare  @accountT  table(
	id			int identity,
	msk		varchar(10),	
	name	varchar(40),
	primary key (id)
	)

	insert @accountT (msk,name)
select distinct case when accnls like '10%'  then '10'
							when accnls like '11%'  then substring(accnls,1,6)
								when accnls like '20%' then '20'
								when accnls like '21%' then '21'
								when accnls like '22%' then '22'
								when accNls like  '3%'  then substring (accnls,1,5)
								when accnls like   '4%' then '40'
						end  msk,
						case when accnls like '10%'  then 'Рахунок компанії'
							when accnls like '11%'  then accName
								when accnls like '20%' then  'Рахунки клієнтів'
								when accnls like '21%' then  'Технічні рахунки клієнтів'
								when accnls like '22%' then  'Рахунки клієнтів-платників'
								when accNls like  '30%'  then  'Об''єкти по виду '+ SUBSTRING(accnls,4,2)
								when accNls like  '31%'  then  ' Нерозподіл. об''єкти по виду '+ SUBSTRING(accnls,4,2)
								when accnls like   '4%' then ' Комісії партнерів'
						end  name
from Account


declare  @result table (
	
	account varchar(10),
	accname				varchar(100) null,
--	accid					int				,
	rest_begin_D		money null,
	rest_begin_K		money null,
	turn_D					money null,
	turn_K					money null,
	rest_end_D			money null,
	rest_end_K			money null,
 primary key (account )
 )

 if  (@account ='0')
 BEGIN   ----1
 insert  @result (account ,accname,rest_begin_D,rest_begin_K,turn_D,turn_K,rest_end_D,rest_end_K)
 select 	t1.msk,	t1.name accname	,	--t2.accname	, 	t2.accid	,	
				 0 rest_begin_D	,0	rest_begin_K	
				 ,isnull(sum(t3.deboborot),0)	turn_D,
				 isnull(sum(t3.krdoborot),0)	turn_K ,
			     0 rest_end_D,	  0 rest_end_K
			from @accountT t1 
			left join Account t2 on (t1.msk= SUBSTRING(t2.accNls,1,len(t1.msk)))
	--		left join SaldoDay t3 on (t2.accId = t3.accid and t3.dateBegin between '20180101' and '20180724'
			left join SaldoDay t3 on (t2.accId = t3.accid and t3.dateBegin between @dateBegin and @dateEnd 			
			)
group by t1.msk, t1.name
order by t1.msk


merge @result  as target
using (   select 	t1.msk 					 
				 ,isnull(sum(case  when t3.restbegin > 0 then t3.restbegin else 0 end),0)	rest_D
				 ,isnull(sum(case  when t3.restbegin < 0 then -t3.restbegin else 0 end),0)	rest_K			    
				 ,isnull(sum(case  when t4.rest > 0 then t4.rest else 0 end),0)	rest_end_D
				 ,isnull(sum(case  when t4.rest < 0 then -t4.rest else 0 end),0)	rest_end_K			    
			from @accountT  t1 
			left join Account t2 on (t1.msk= SUBSTRING(t2.accNls,1,len(t1.msk)))
			left join SaldoDay t3 on (t2.accId = t3.accid and @dateBegin between t3.dateBegin and t3.dateEnd )
--			left join SaldoDay t3 on (t2.accId = t3.accid and '20180101' between t3.dateBegin and t3.dateEnd )
			left join SaldoDay t4 on (t2.accId = t4.accid and @dateEnd between t4.dateBegin and t4.dateEnd 
			)
			group by t1.msk
		)   as source on (source.msk = target.account) 

		when matched
then 
	update set 
			target.rest_begin_D = source.rest_D,
			target.rest_begin_K =source.rest_K,
			target.rest_end_D = source.rest_end_D,
			target.rest_end_K =source.rest_end_K;

select * from @result
return
END   -- 1


BEGIN   ----2
 insert  @result (account ,accname,rest_begin_D,rest_begin_K,turn_D,turn_K,rest_end_D,rest_end_K)
 select 	t2.accnls,	t2.accName accname	,	--t2.accname	, 	t2.accid	,	
				 0 rest_begin_D	,0	rest_begin_K	
				 ,isnull(sum(t3.deboborot),0)	turn_D,
				 isnull(sum(t3.krdoborot),0)	turn_K ,
			     0 rest_end_D,	  0 rest_end_K
			from
			 Account t2 
			--left join SaldoDay t3 on (t2.accId = t3.accid and t3.dateBegin between '20180101' and '20180724'
			left join SaldoDay t3 on (t2.accId = t3.accid and t3.dateBegin between @dateBegin and @dateEnd)
			where @account= SUBSTRING(t2.accNls,1,len(@account))
			
group by t2.accNls, t2.accName
order by t2.accNls


merge @result  as target
using (   select 	t2.accnls 					 
				 ,isnull(sum(case  when t3.restbegin > 0 then t3.restbegin else 0 end),0)	rest_D
				 ,isnull(sum(case  when t3.restbegin < 0 then -t3.restbegin else 0 end),0)	rest_K			    
				 ,isnull(sum(case  when t4.rest > 0 then t4.rest else 0 end),0)	rest_end_D
				 ,isnull(sum(case  when t4.rest < 0 then -t4.rest else 0 end),0)	rest_end_K			    
			from 
			Account t2 
			left join SaldoDay t3 on (t2.accId = t3.accid and @dateBegin between t3.dateBegin and t3.dateEnd )
--			left join SaldoDay t3 on (t2.accId = t3.accid and '20180101' between t3.dateBegin and t3.dateEnd )
			left join SaldoDay t4 on (t2.accId = t4.accid and @dateEnd between t4.dateBegin and t4.dateEnd 
			)
			where @account= SUBSTRING(t2.accNls,1,len(@account))
			group by t2.accnls


		)   as source on (source.accnls = target.account) 

		when matched
then 
	update set 
			target.rest_begin_D = source.rest_D,
			target.rest_begin_K =source.rest_K,
			target.rest_end_D = source.rest_end_D,
			target.rest_end_K =source.rest_end_K;

select * from @result
where abs(rest_begin_D)+abs(rest_begin_K)+abs(	turn_K	)+ abs(	rest_end_D)+abs(rest_end_K	)<>0
return
END   -- 2



end

--pTsk_5_17_2_BalanseGroup  null,null,null