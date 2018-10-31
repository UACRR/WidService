create FUNCTION [dbo].[f_rest_out] (@account varchar(20),@dateEnd date)
RETURNS numeric(20,2)

    BEGIN 
    declare  @result numeric(20,2)
    set @result = 
(select t2.rest from account t1, SaldoDay t2
		where
				t1.accNls =@account		and
					t2.accId = t1.accId			
					and						@dateEnd >= t2.datebegin  
					and						@dateEnd <= t2.dateend
)
	RETURN @result
END