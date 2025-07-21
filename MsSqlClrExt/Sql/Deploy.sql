use master
go

create assembly MsSqlClrExt from 'C:\MsSqlClrExt\MsSqlClrExt.dll' -- change path as apprpiate
go

create function ClrTranslitFromUkrToLat(@source nvarchar(256))
returns nvarchar(1000)
as external name MsSqlClrExt.[MsSqlClrExt.ClrTranslit].ClrTranslitFromUkrToLat;
go

