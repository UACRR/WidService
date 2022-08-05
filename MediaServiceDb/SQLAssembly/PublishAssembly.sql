/* 
	1. Create class: https://www.codeproject.com/Tips/841439/Create-Run-Debug-and-Deploy-SQL-CLR-Function-with
	2. Create assembly:
		cmd: csc /t:library fileName.cs
		link: https://docs.microsoft.com/en-us/sql/relational-databases/clr-integration/deploying-clr-database-objects?view=sql-server-2017
	

*/

-- console compiler command: csc -t:library SQLFunctions.cs

-- copy/paste custom change and execute this: 
-- переключитись на потрібну БД:
/*
use [database_name]
go
*/

-- знищити існуючі функції
drop function if exists [Ft_tsk_3_Accurace]
go
drop function if exists [Ft_tsk_3_Accurace_p]
go
drop function if exists [Ft_tsk_3_Accurace_strong]
go
drop function if exists [Ft_tsk_3_Compare]

-- знищити існуючу збірку
drop assembly if exists MediaServiceDb
go

-- створити збірку:
-- змінна @path - шлях до DLL файлу через хост (або прямий якщо є доступ), 
-- * в SQL Server Management Studio ОБОВ'ЯЗКОВО повинен бути доступ до папки!
/*

DECLARE @path VARCHAR(128) = '\\IPS-TESTS\deploy\ASSEMBLY';
CREATE ASSEMBLY [MediaServiceDb]
from @path WITH PERMISSION_SET = SAFE
GO

*/

-- створити функції:
CREATE FUNCTION [dbo].[Ft_tsk_3_Accurace](@sors [nvarchar](max), @dest [nvarchar](max), @accuracy [real])
RETURNS [float] WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [MediaServiceDb].[UserDefinedFunctions].[Ft_tsk_3_Accurace]
GO

CREATE FUNCTION [dbo].[Ft_tsk_3_Accurace_strong](@sors [nvarchar](max), @dest [nvarchar](max), @accuracy [real])
RETURNS [float] WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [MediaServiceDb].[UserDefinedFunctions].[Ft_tsk_3_Accurace_strong]
GO

CREATE FUNCTION [dbo].[Ft_tsk_3_Accurace_p](@sors [nvarchar](max), @dest [nvarchar](max), @accuracy [real])
RETURNS [float] WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [MediaServiceDb].[UserDefinedFunctions].[Ft_tsk_3_Accurace_p]
GO

CREATE FUNCTION [dbo].[Ft_tsk_3_Compare](@sors [nvarchar](max), @dest [nvarchar](max), @accuracy [real])
RETURNS [bit] WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [MediaServiceDb].[UserDefinedFunctions].[Ft_tsk_3_Compare]
GO

-- завершення 
-- налаштовується один раз! якщо раніше ця настройка виконувалась, можна не виконувати
sp_configure 'clr enabled', 1
GO 
RECONFIGURE
GO

/* template: 
link step: https://www.c-sharpcorner.com/article/how-to-create-clr-stored-procedure-with-and-without-namespace-in-c-sharp-and-install/
link: https://www.codemahek.com/blog/execute-c-methods-from-sql-server
Use <Database Name>
GO
Create Assembly <DLL Name> from ‘<DLL Path>’ WITH PERMISSION_SET = SAFE
GO
CREATE FUNCTION <AddGSTTax>(@inputOne float)
RETURNS [float] WITH EXECUTE AS CALLER, RETURNS NULL ON NULL INPUT
AS 
EXTERNAL NAME [<DLLName>].[<Complete Namespace>].[AddGSTTax]
GO

sp_configure 'clr enabled', 1
GO 

RECONFIGURE
GO
*/

/* drop func, than drop assembly
USE MediaServiceTest
GO
DROP FUNCTION IF EXISTS [SqlFunctionTest]
DROP ASSEMBLY IF EXISTS [TestSqlFunctions]

*/
