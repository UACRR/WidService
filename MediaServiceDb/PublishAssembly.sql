/* 
	1. Create class: https://www.codeproject.com/Tips/841439/Create-Run-Debug-and-Deploy-SQL-CLR-Function-with
	2. Create assembly:
		cmd: csc /t:library fileName.cs
		link: https://docs.microsoft.com/en-us/sql/relational-databases/clr-integration/deploying-clr-database-objects?view=sql-server-2017
	

*/

-- copy/paste custom change and execute this: 
USE MediaServiceTest
GO

-- шлях до спільної з сервером папки
DECLARE
@path VARCHAR(128) = '\\IPS-COMPVLASD\asm\TestSqlFunctions.dll';
--@path VARCHAR(128) = 'd:\asm\TestSqlFunctions.dll';

-- створити збірку
CREATE ASSEMBLY [TestSqlFunctions] --AUTHORIZATION[ips\vpysmennyi]
from @path WITH PERMISSION_SET = SAFE
GO
-- створити функцію
--CREATE FUNCTION SqlFunctionTest()
--RETURNS [nvarchar](max) WITH EXECUTE AS CALLER --, RETURNS NULL ON NULL INPUT
--AS 
--EXTERNAL NAME [TestSqlFunctions].[UserDefinedFunctions].[SqlFunctionTest]
--GO

-- створити функцію
CREATE FUNCTION ToUpperString(@string nvarchar)
RETURNS [nvarchar](max) WITH EXECUTE AS CALLER, RETURNS NULL ON NULL INPUT
AS 
EXTERNAL NAME [TestSqlFunctions].[UserDefinedFunctions].[ToUpperString]
GO

-- створити функцію
CREATE FUNCTION ToLowerString(@string nvarchar)
RETURNS [nvarchar](max) WITH EXECUTE AS CALLER, RETURNS NULL ON NULL INPUT
AS 
EXTERNAL NAME [TestSqlFunctions].[UserDefinedFunctions].[ToLowerString]
GO

-- створити функцію
CREATE FUNCTION CircleSquare(@radius float)
RETURNS [float] WITH EXECUTE AS CALLER, RETURNS NULL ON NULL INPUT
AS 
EXTERNAL NAME [TestSqlFunctions].[UserDefinedFunctions].[CircleSquare]
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
