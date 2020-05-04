create procedure [dbo].[p_rest_out] (@account varchar(20),@dateEnd date)
as

    BEGIN 
	set @dateEnd = isnull(@dateEnd, getdate())
    declare  @result numeric(20,2)
    set @result = 
isnull((select t2.rest from account t1, SaldoDay t2
		where
				t1.accNls =@account		and
					t2.accId = t1.accId			
					and						@dateEnd >= t2.datebegin  
					and						@dateEnd <= t2.dateend
),0)
select  @result
END
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[p_rest_out] TO [ReportUser]
    AS [dbo];

