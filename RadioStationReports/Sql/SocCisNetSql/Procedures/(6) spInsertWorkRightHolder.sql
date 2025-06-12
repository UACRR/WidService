use SocCisNet
go

create or alter procedure spInsertWorkRightHolder
	  @SeqNr				int
	, @IpBaseNr				varchar(13)
	, @IpNameNr				int
	, @IpRole				varchar(2)
	, @FstName				varchar(128)
	, @LstName				varchar(128)
	, @IsLeadingPublisher	bit
	, @PerSocCde			int
	, @PerShr				decimal(5, 2)
	, @MecSocCde			int
	, @MecShr				decimal(5, 2)
	, @WorkCode				varchar(50)
as
begin
	if exists (select null 
		from WorkRightHolders
		where IpBaseNr	 = @IpBaseNr
			and IpNameNr = @IpNameNr
			and IpRole	 = @IpRole
			and WorkCode = @WorkCode
	)
		return

	insert WorkRightHolders (
		  SeqNr	
		, IpBaseNr	
		, IpNameNr	
		, IpRole	
		, FstName	
		, LstName	
		, IsLeadingPublisher
		, PerSocCde		
		, PerShr			 
		, MecSocCde		
		, MecShr			 
		, WorkCode		
	)
	values (
		  @SeqNr	
		, @IpBaseNr	
		, @IpNameNr	
		, @IpRole	
		, @FstName	
		, @LstName	
		, @IsLeadingPublisher
		, @PerSocCde		
		, @PerShr			 
		, @MecSocCde		
		, @MecShr			 
		, @WorkCode			 
	)
end
go