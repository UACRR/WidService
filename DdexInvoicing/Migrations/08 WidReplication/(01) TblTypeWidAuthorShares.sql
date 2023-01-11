use DDEX
go

drop type if exists tblTypeWidAuthorShares
go

create type tblTypeWidAuthorShares 
as table (
	  Wic int
	, IpBaseNr varchar(13)
	, IpNameNr int
	, RoleInWid varchar(3) 
	, MecWidShr decimal(5, 2)
	, MecSoc int
	, MecSocShr decimal(5, 2)
	, PerWidShr decimal(5, 2)
	, PerSoc int
	, PerSocShr decimal(5, 2)
)
go
