use SocIpiTesting
go

create or alter procedure spCreateRecMan
as
begin
drop table if exists RecMan

select
	  Id
	, FileId
	, substring(Text, 1,  3) as RecType
	, substring(Text, 4,  8) as TransSeqNr
	, substring(Text, 12, 8) as RecSeqNr
	, substring(Text, 20, 3) as SocCde
	, substring(Text, 23, 2) as CreClsCde
	, substring(Text, 25, 2) as RolCde
	, substring(Text, 27, 2) as RgtCde
	, substring(Text, 29, 8) as ValidFromD
	, substring(Text, 37, 6) as ValidFromT
	, substring(Text, 43, 8) as ValidToD
	, substring(Text, 51, 6) as ValidToT
	, substring(Text, 57, 8) as SignD
	, substring(Text, 65, 5) as Shr
	, substring(Text, 70, 8) as AmdD
	, substring(Text, 78, 6) as AmdT
into RecMan
from FullDumpFileRecords
where substring(Text, 1, 3) = 'MAN'
--	and substring(Text, 23, 2) = 'MW'					-- CreClsCde
--	and substring(Text, 25, 2) in ('LY', 'MC', 'EM')	-- RolCde
--	and substring(Text, 27, 2) in ('PR', 'MR')			-- RgtCde

end

-- exec spCreateRecMan