drop table if exists CisNet_140_wid_works
create table CisNet_140_wid_works (
	  Id int primary key clustered identity (1, 1)
	, SocWorkCde varchar(32)
	, SocIswcCde varchar(13)
	, Title varchar(512)
)
go

drop table if exists CisNet_140_cn2_works
create table CisNet_140_cn2_works (
	  Id int primary key clustered identity (1, 1)
	, SocWorkCde varchar(32)
	, SocIswcCde varchar(13)
	, Title varchar(512)
)
go

drop table if exists CisNet_140_not_migrated_works
create table CisNet_140_not_migrated_works (
	  Id int primary key clustered identity (1, 1)
	, SocWorkCde varchar(32)
	, SocIswcCde varchar(13)
	, Title varchar(512)
)
go

select * from CisNet_140_not_migrated_works where left(SocWorkCde, 2) <> 'MS'

select * from CisNet_140_wid_works t1 left join CisNet_140_cn2_works t2 on t1.SocWorkCde = t2.SocWorkCde where t2.SocWorkCde is null

EXEC sp_configure 'show advanced options', 1;
RECONFIGURE;
EXEC sp_configure 'xp_cmdshell', 1;
RECONFIGURE;
EXEC master..xp_cmdshell 'bcp "SocWidSubmitEx.dbo.CisNet_140_wid_works" out "C:\BCP\CisNet_140_wid_works.bcp" -c -T -S localhost';