-- drop procedure dbo.p_Tsk3_AddAltName

CREATE procedure dbo.p_Tsk3_AddAltName @regId int as
begin

-- Додати нові альтернативні назви об'єкту в таблицю пошуку
insert into SeekObject( codeI, objId, name )
select 1, t1.objid, ltrim(rtrim(ItemName)) 
from RegisterItem t1 
join ObjectRight ob on ob.objId = t1.objId and ob.name != ltrim(rtrim(ItemName))
left join SeekObject t2 on t2.codeI = 1 and t2.objId = t1.objId and t2.name = ltrim(rtrim(ItemName))
where regid = @regId
and t2.id is null

end