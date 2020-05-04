CREATE procedure [dbo].[p_CreateDistribution_DDEX_valuation1] @regId int--, @ExchangeRate numeric(30,10)
 as
begin
    declare     @regIItemId		int
	declare		@amountMech		numeric(30,10)
	declare		@amountPerf		numeric(30,10)
	declare		@amountMechCur	numeric(30,10)
	declare		@amountPerfCur	numeric(30,10)
	declare		@aMP			numeric(30,10)

-- move @ExchangeRate to declare, get value from table
declare @ExchangeRate numeric(30,10) = (select ExchangeRate from registerCCID where regId = @regId);
		if (isnull(@ExchangeRate, 0) = 0) return 1;

declare @regRoyaltyReal money
declare @delta money
declare @regRoyalty money = (select round(amountCur * @ExchangeRate,2) from RegisterCCID
		where regId = @regId
		)
		if ((select regRoyalty from register where regId = @regId)<> @regRoyalty) return 1;

update RegisterCCIDMW
	set 
	amountMech = round(amountMechCur * @ExchangeRate,2),
	amountPerf = round(amountPerfCur * @ExchangeRate,2)
	where regId = @regId

select @regRoyaltyReal = (sum(amountMech)+sum(amountPerf)) from RegisterCCIDMW
  where regId = @regId

	select @delta =@regRoyalty - @regRoyaltyReal


	if (@delta >0)

nextCikl:
	BEGIN       ------1

	if ((select count(*) from RegisterCCIDMW
			where regId = @regId	and
				  ((amountMech+amountPerf)	 = 0)

		) >0 )

	BEGIN       -------2

  declare cur cursor for   
  select  distinct regIItemId,amountMech,amountPerf,amountMechCur,amountPerfCur,(amountMechCur + amountPerfCur) aMP
   from RegisterCCIDMW
  where
		regId =@regId		and
--		regId =7431		and
		(amountMech+amountPerf)	 = 0	and
		(amountMechCur + amountPerfCur) <> 0 
		order by (amountMechCur + amountPerfCur) desc
	
    open cur                                                   
    fetch cur into  @regIItemId,@amountMech,@amountPerf,@amountMechCur,@amountPerfCur,@aMP
	    
		
	while ((@@fetch_status =0 ) and (@delta >0))
	BEGIN
	if (@amountMechCur> @amountPerfCur) 
	begin
		update RegisterCCIDMW
			set amountMech = amountMech + 0.01
		where	regId = @regId and
				regIItemId = @regIItemId
	end
		else
	begin
	update RegisterCCIDMW
			set amountPerf = amountPerf + 0.01
		where	regId = @regId and
				regIItemId = @regIItemId	
	end
	set @delta = @delta - 0.01

	fetch cur into  @regIItemId,@amountMech,@amountPerf,@amountMechCur,@amountPerfCur,@aMP

	END

close cur   
deallocate cur      
END         ----------2
	else

	BEGIN       -------3

  declare cur cursor for   
  select  distinct regIItemId,amountMech,amountPerf,amountMechCur,amountPerfCur,(amountMechCur + amountPerfCur) aMP
   from RegisterCCIDMW
  where
		regId =@regId		
--		regId =7431		and
		order by (amountMechCur + amountPerfCur) desc
    open cur                                                   
    fetch cur into  @regIItemId,@amountMech,@amountPerf,@amountMechCur,@amountPerfCur,@aMP
	    
		
	while ((@@fetch_status =0 ) and (@delta >0))
	BEGIN
	if (@amountMechCur> @amountPerfCur) 
	begin
		update RegisterCCIDMW
			set amountMech = amountMech + 0.01
		where	regId = @regId and
				regIItemId = @regIItemId
	end
		else
	begin
	update RegisterCCIDMW
			set amountPerf = amountPerf + 0.01
		where	regId = @regId and
				regIItemId = @regIItemId	
	end
	set @delta = @delta - 0.01

	fetch cur into  @regIItemId,@amountMech,@amountPerf,@amountMechCur,@amountPerfCur,@aMP

	END

close cur   
deallocate cur      
END         ----------3
END         ----------1

select @regRoyaltyReal = (sum(amountMech)+sum(amountPerf)) from RegisterCCIDMW
  where regId = @regId

	select @delta =@regRoyalty - @regRoyaltyReal
if @delta >0 GOTO nextCikl

--	select @delta
--select 'OK'
update Register
set rgStatus = 12
where regid = @regId 
update RegisterRatedList
set royalty = isnull(royalty,0) + @regRoyalty

	return 0
end
