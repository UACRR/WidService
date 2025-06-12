use SocCisNet
go

create or alter procedure spSysClearDatabase
as
begin

delete from [dbo].[WorkSubmissions]
delete from [dbo].[WorkRightHolders]
delete from [dbo].[WorkPerformers]
delete from [dbo].[WorkAltNames]
delete from [dbo].[PackageWorks]
delete from [dbo].[Works]
delete from [dbo].[Packages]
end