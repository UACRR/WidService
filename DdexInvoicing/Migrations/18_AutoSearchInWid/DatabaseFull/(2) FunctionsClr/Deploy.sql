use AutoSearch
go

create assembly MsSqlClrExt from 'C:\MsSqlClrExt\MsSqlClrExt.dll' -- change path as apprpiate
go

create function ClrTranslitFromUkrToLat(@source nvarchar(256))
returns nvarchar(1000)
as external name MsSqlClrExt.[MsSqlClrExt.ClrTranslit].ClrTranslitFromUkrToLat;
go

create function ClrCompareNormalized(@text1 nvarchar(256), @text2 nvarchar(256))
returns int
as external name MsSqlClrExt.[MsSqlClrExt.ClrStringHelpers].ClrCompareNormalized;
