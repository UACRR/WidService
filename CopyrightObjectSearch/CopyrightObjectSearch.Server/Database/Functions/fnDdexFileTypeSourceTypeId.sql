use CopyrightObjectSearch
go

create or alter function fnDdexFileTypeSourceTypeId
(
	@ddexFileType as varchar(64)
)
returns int
as
begin

	return case 
		when @ddexFileType = 'adsupport-music'		then 1
		when @ddexFileType = 'subscription-music'	then 2
		when @ddexFileType = 'subscription-premium' then 3
		when @ddexFileType = 'srmf'					then 4
		when @ddexFileType = 'spotify-free'			then 5
		when @ddexFileType = 'spotify-premium'		then 6
		when @ddexFileType = 'deezer-all'			then 7
	end;
end
go

