create procedure SysIfProcedure @pName varchar(100) 
as BEGIN 
declare @STR varchar(1024) 
set @STR =
'
if not exists (select  * from sysobjects where name = '+''+@pName+''+' and xtype = '+''+'P'+''+')'+
'create procedure ipTsk10_LoadAuthors 
as
begin
return 0
END
'
execute @STR
Return 0 
END 
