CREATE view [dbo].[vEtGenreRole] as 
(select distinct t1.genreCode, t2.name as genreName, t1.roleCode, t3.name as roleName, t1.actCode, t4.name as actName, t1.rate
from EtGenreRole t1 
join EtGenre t2 on t1.genreCode = t2.codeI
join EtRole t3 on t1.roleCode = t3.codeI 
join ObjAct t4 on t1.actCode = t4.codeI
)