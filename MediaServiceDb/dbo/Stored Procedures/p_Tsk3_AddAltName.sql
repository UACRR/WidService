CREATE procedure dbo.p_Tsk3_AddAltName @regId int as
begin

-- Додати нові альтернативні назви об'єкту в таблицю пошуку
insert into SeekObject( codeI, objId, name )
select 1, t1.objid, ltrim(rtrim(ItemName)) 
from RegisterItem t1 
join ObjectRight ob on ob.objId = t1.objId and ob.name != ltrim(rtrim(ItemName))
left join SeekObject t2 on t2.codeI = 1 and t2.objId = t1.objId and t2.name = ltrim(rtrim(ItemName))
where regid = @regId
and t2.id is null;

-- Додати нові альтернативні назви виконавців в таблицю пошуку
insert into SeekObject( codeI, objId, name )
select 2, t1.objid, ltrim(rtrim(t1.performer)) 
from RegisterItem t1 
join ObjectRight ob on ob.objId = t1.objId 
left join SeekObject t2 on t2.codeI = 2 and t2.objId = t1.objId and t2.name = ltrim(rtrim(t1.performer))
where regid = @regId
and t2.id is null
and t1.performer is not null
and len(ltrim(t1.performer)) > 0;

end