USE SocWidSubmit
GO

create or alter view [dbo].[vPerformerAgg]
as
with PerformerDistinct as (
	select distinct
		  WidSubmGroupId	as WidSubmGroupId
		, ObjId				as ObjId
		, trim(LocalName)	as LocalName
	from WidSubmGroupWorkPerformer
)
select
	  WidSubmGroupId
	, ObjId													as ObjId
	, string_agg(convert(varchar(max), LocalName), ' | ')	as Performers
from PerformerDistinct
group by WidSubmGroupId, ObjId
GO


