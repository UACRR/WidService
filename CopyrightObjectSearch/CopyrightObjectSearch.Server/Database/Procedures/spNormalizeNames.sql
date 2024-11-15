use CopyrightObjectSearch
go

create or alter procedure spNormalizeNames
as
begin

-- Replace separators and remove wrong symbols
update TmpInitialNames
set Names = trim(dbo.fnPreProcessNames(Names))

-- Split names by pipe separator
drop table if exists #SeparateNames
select
	  row_number() over (order by (select 1)) as SeparateNameId
	, MwId									  as MwId
	, trim(value)							  as Name
into #SeparateNames
from TmpInitialNames
	cross apply string_split(Names, '|')

-- Split names into parts
drop table if exists #SeparateNameParts
select distinct
	  SeparateNameId		as SeparateNameId
	, MwId					as MwId
	, value					as SeparateNamePart
into #SeparateNameParts
from #SeparateNames
cross apply string_split(Name, ' ')

-- Clean-up name parts
update #SeparateNameParts
set SeparateNamePart = ''
where SeparateNamePart in (
		  '#unknown#'
		, ''
		, '-'
		, ''
		, '$'
		, '('
		, '*'
		, '***'
		, '.'
		, '..'
		, 'CA'
		, 'UNKNOWN WRITER'
		, 'UNKNOWN'
	)

-- This removes Japanee texts, etc
update #SeparateNameParts
set SeparateNamePart = ''
where cast(substring(SeparateNamePart, 1, 1) as char) = '?'

-- Names composed from parts in alphabetic order
drop table if exists #NormalizedSeparateNames
select distinct
	  MwId														   as MwId
	, string_agg(convert(varchar(max), SeparateNamePart), ' ') 
		within group (order by SeparateNamePart asc)
																   as Name
into #NormalizedSeparateNames
from #SeparateNameParts
group by SeparateNameId, MwId

-- Final pipe separated names
delete from #NormalizedSeparateNames
where Name = ''

update #NormalizedSeparateNames
set Name = upper(Name)

drop table if exists TmpNormalizedNames
select MwId
	, string_agg(convert(varchar(max), Name), ' | ' ) 
		within group (order by Name asc)
		as Names
into TmpNormalizedNames
from #NormalizedSeparateNames
group by MwId
order by MwId

-- TmpNormalizedNames will be missing some MwIds, insert those

set identity_insert TmpNormalizedNames on
insert TmpNormalizedNames(MwId, Names)
select t1.MwId, ''
from TmpInitialNames t1
	left join TmpNormalizedNames t2 on t1.MwId = t2.MwId
where t2.MwId is null
set identity_insert TmpNormalizedNames off

end

-- exec spNormalizeNames