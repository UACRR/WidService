use MediaService
go

create or alter trigger trigObjectRightRefine on ObjectRight after insert, update
as
begin
	set nocount on;
	if @@NESTLEVEL > 1 return
	if update(Name) or update(Author) or update(Performer)
	begin
		update t1
		set 
			  t1.Name      = dbo.ClrRefineText(t2.Name)
			, t1.Author    = dbo.ClrRefineText(t2.Author)
			, t1.Performer = dbo.ClrRefineText(t2.Performer)
		from ObjectRight t1
			join inserted t2 on t1.ObjId = t2.ObjId
	end
end
go

select * from ObjectRight where ObjId = 955346

update ObjectRight set Name = 'aaa', author = 'bbb', performer = 'ccc' where ObjId = 955346

update ObjectRight set status = 1 where ObjId = 955346
