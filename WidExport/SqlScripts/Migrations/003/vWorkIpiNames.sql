USE SocWidSubmit
GO

create or alter view [dbo].[vWorkIpiNames]
as
select distinct
	  WidSubmGroupId	as WidSubmGroupId
	, ObjId				as ObjId
	, IpNameNr			as IpNameNr
from WidSubmGroupWorkShare
GO


