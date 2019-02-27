CREATE function [dbo].[ft_Tsk9_4_RhRegister]  (@userId varchar(48))
--ФОРМА ДОХОДЫ В РАЗРЕЗЕ ВИДОВ ПРАВ:
RETURNS @RT TABLE
(
 custId integer, 
 objid integer not null primary Key, 
 objName varchar(200), 
 categoryName varchar(1),
 genreType integer, 
 genreName varchar(200), 
 duration char(8), 
 specName varchar(100), 
 performer varchar(254), 
 roleName varchar(200), 
 rate decimal (5,2), 
 statusName varchar(100),
 iswc varchar(100)
 )
AS
BEGIN  

--Определяю пользователя
declare @custId integer = (select max(t2.custId) 
                            from  aspNetUsers t1 
                              join vCustomer t2 on t1.id = t2.userId 
							 where t1.id = @userId)

---- реестр объектов правообладателей
insert into @RT (custId, objid, objName, genreType, genreName, duration, specName, roleName, rate, categoryName, performer, statusName, iswc )
select custId, objid, t1.name, genreType, genreName, convert(char(8), duration), specName, roleName, rateRh, category, performer, t2.name, t1.iswc
from vtsk_3_OR_03_V2 t1 
left join CRightStatus t2 on t2.codeI = (t1.statusActive+t1.statusNoActive )
where custId = @custId 

RETURN
END

/*
select * from ft_Tsk9_4_RhRegister ('8f1f2428-48b4-4209-a577-1fab339c0d82')
select * from vtsk_3_OR_03_V2 -- реестр объектов правообладателей
*/