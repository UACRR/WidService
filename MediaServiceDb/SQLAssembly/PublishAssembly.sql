/* 
	1. Create class: https://www.codeproject.com/Tips/841439/Create-Run-Debug-and-Deploy-SQL-CLR-Function-with
	2. Create assembly:
		cmd: csc /t:library fileName.cs
		link: https://docs.microsoft.com/en-us/sql/relational-databases/clr-integration/deploying-clr-database-objects?view=sql-server-2017
	

*/

-- console compiler command: csc -t:library SQLFunctions.cs

-- copy/paste custom change and execute this: 
USE MediaServiceTest
GO

-- шлях до спільної з сервером папки
--DECLARE @path VARCHAR(128) = '\\IPS-COMPVLASD\asm\MediaServiceDb.dll';

-- знищити існуючі функції
drop function [Ft_tsk_3_Accurace]
drop function [Ft_tsk_3_Accurace_p]
drop function [Ft_tsk_3_Accurace_strong]
drop function [Ft_tsk_3_Compare]
-- знищити існуючу збірку
drop assembly MediaServiceDb

-- створити збірку
DECLARE @path VARCHAR(128) = '\\IPS-COMPVLASD\asm\MediaServiceDb.dll';
CREATE ASSEMBLY [MediaServiceDb] --AUTHORIZATION[ips\vpysmennyi]
from @path WITH PERMISSION_SET = SAFE
GO

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
