
CREATE procedure [dbo].[p_rest_in] (@account varchar(20),@datebegin date)
as

    BEGIN 
	set @dateBegin = isnull(@dateBegin, (select convert(date, (convert(char(4),year(getdate()))+'-01-01'))))
--	set @datebegin = isnull(@datebegin, getdate())
    declare  @result numeric(20,2)
    set @result = 
isnull((select t2.restBegin from account t1, SaldoDay t2
		where
				t1.accNls =@account		and
					t2.accId = t1.accId			
					and						@datebegin >= t2.datebegin  
					and						@datebegin <= t2.dateend
),0)
select  @result
END