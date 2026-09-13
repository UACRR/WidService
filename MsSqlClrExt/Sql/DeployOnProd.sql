use MediaService
go

drop function if exists ClrCompareNormalized
drop function if exists ClrTranslitFromUkrToLat
drop function if exists ClrNeedRefineText
drop function if exists ClrRefineText
drop function if exists ClrIsUkraine

--create assembly MsSqlClrExt from 'C:\MsSqlClrExt\MsSqlClrExt.dll' -- change path as apprpiate
--go
drop assembly if exists MsSqlClrExt
go
create assembly MsSqlClrExt from 'C:\UACRR\WID_Service\bin\MsSqlClrExt\MsSqlClrExt.dll' -- change path as apprpiate
go

-- ClrTranslit
create or alter function ClrTranslitFromUkrToLat(@source nvarchar(256))
returns nvarchar(1000)
as external name MsSqlClrExt.[MsSqlClrExt.ClrTranslit].ClrTranslitFromUkrToLat;
go

create or alter function ClrNeedRefineText(@source nvarchar(256))
returns bit
as external name MsSqlClrExt.[MsSqlClrExt.ClrTranslit].ClrNeedRefineText;
go

create or alter function ClrRefineText(@source nvarchar(256))
returns nvarchar(256)
as external name MsSqlClrExt.[MsSqlClrExt.ClrTranslit].ClrRefineText;
go

-- ClrStringHelpers
create or alter function ClrCompareNormalized(@text1 nvarchar(256), @text2 nvarchar(256))
returns int
as external name MsSqlClrExt.[MsSqlClrExt.ClrStringHelpers].ClrCompareNormalized;
go

-- ClrIsUkraine
create or alter function ClrIsUkraine(@source nvarchar(256))
returns bit
as external name MsSqlClrExt.[MsSqlClrExt.ClrTerrCalc].ClrIsUkraine;
go

print dbo.ClrCompareNormalized('aaa', 'bbb')
print dbo.ClrTranslitFromUkrToLat('ПАПА МАМА Я')
print dbo.ClrNeedRefineText('some text')
print dbo.ClrRefineText('some text')
print dbo.ClrIsUkraine('I2119')
go

