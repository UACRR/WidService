USE [MediaService]
GO

/****** Object:  View [dbo].[vWidSrObjectAuthors]    Script Date: 30.09.2025 14:32:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create or alter  view [dbo].[vWidSrObjectAuthorsEx]
as
select 
		  t1.Wic									as WIC					
		, cast(t1.RolId	as smallint)				as SeqNr				
		, cast(t1.IpNameNr as varchar(11))			as IPINr
		, t2.IpBaseNr								as IP_BASE_NR
		, t1.IpRole									as IntrPtyRol
		, trim(concat(t2.FstName, ' ', t2.Name))	as authName
		, trim(t2.FstName)							as authFstName
		, trim(t2.Name)								as authLstName
		, t3.Shares									as ratePER
		, t4.Shares									as rateMEC 
from SocWid..widIntrPty t1
	join SocIpi..IpiName t2 on t1.IpNameNr = t2.IpNameNr
	left join SocWid..WidShares t3 on t1.Wic = t3.Wic
		and t1.RolId = t3.IntrPtyRolid
		and t3.RightType = 'PER'
	left join SocWid..WidShares t4 on t1.Wic = t4.Wic
		and t1.RolId = t4.IntrPtyRolid
		and t4.RightType = 'MEC'
GO

