use CopyrightObjectSearch
go

create or alter function fnDdexFileTitle
(
	  @ddexFileType varchar(64)
	, @year			int
	, @quarter		int
	, @month		int
)
returns nvarchar(255)
as
begin

	return case 
		when @ddexFileType = 'adsupport-music'		then concat('«в≥т YouTube реклама за '		, @year, ', квартал '	, @quarter	)
		when @ddexFileType = 'subscription-music'	then concat('«в≥т YouTube п≥дписка за '		, @year, ', квартал '	, @quarter	)
		when @ddexFileType = 'subscription-premium' then concat('«в≥т YouTube прем≥альний за '	, @year, ', квартал '	, @quarter	)
		when @ddexFileType = 'srmf'					then concat('«в≥т YouTube попередн≥й за '	, @year, ', м≥с€ць '	, @month	)
		when @ddexFileType = 'spotify-free'			then concat('«в≥т Spotify безкоштовний за '	, @year, ', м≥с€ць '	, @month	)
		when @ddexFileType = 'spotify-premium'		then concat('«в≥т Spotify прем≥альний за '	, @year, ', м≥с€ць '	, @month	)
		when @ddexFileType = 'deezer-all'			then concat('«в≥ти Deezer за '				, @year, ', квартал '	, @quarter	)
	end;
end
go

