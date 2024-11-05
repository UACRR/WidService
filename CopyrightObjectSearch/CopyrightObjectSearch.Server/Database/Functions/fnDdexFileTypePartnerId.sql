use CopyrightObjectSearch
go

create or alter function fnDdexFileTypePartnerId
(
	@ddexFileType as varchar(64)
)
returns int
as
begin

	return case 
		when @ddexFileType = 'adsupport-music'		then 1
		when @ddexFileType = 'subscription-music'	then 1
		when @ddexFileType = 'subscription-premium' then 1
		when @ddexFileType = 'srmf'					then 1
		when @ddexFileType = 'spotify-free'			then 2
		when @ddexFileType = 'spotify-premium'		then 2
		when @ddexFileType = 'deezer-all'			then 3
	end;
end
go

