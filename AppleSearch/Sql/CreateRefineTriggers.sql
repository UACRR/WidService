use MediaService
go

create or alter trigger trigObjectRightRefine on ObjectRight after insert, update
as
begin
	set nocount on;
	if trigger_nestlevel(object_id('trigObjectRightRefine')) > 1 return
	if update(Name) or update(Author) or update(Performer)
	begin
		update t1
		set 
			  t1.Name      = dbo.ClrRefineText(isnull(t2.Name, ''))
			, t1.Author    = dbo.ClrRefineText(isnull(t2.Author, ''))
			, t1.Performer = dbo.ClrRefineText(isnull(t2.Performer, ''))
		from ObjectRight t1
			join inserted t2 on t1.ObjId = t2.ObjId
	end
end
go

create or alter trigger trigSeekObjectRefine on SeekObject after insert, update
as
begin
	set nocount on;
	if trigger_nestlevel(object_id('trigSeekObjectRefine')) > 1 return
	if update(Name)
	begin
		update t1
		set 
			  t1.Name      = dbo.ClrRefineText(isnull(t2.Name, ''))
		from SeekObject t1
			join inserted t2 on t1.Id = t2.Id
	end
end
go

create or alter trigger trigMediaTrackRefine on MediaTrack after insert, update
as
begin
	set nocount on;
	if trigger_nestlevel(object_id('trigMediaTrackRefine')) > 1 return
	if update(Name) or update(lyrics) or update(composers) or update(performers)
	begin
		update t1
		set 
			    t1.Name			= dbo.ClrRefineText(isnull(t2.Name, ''))
			  , t1.lyrics		= dbo.ClrRefineText(isnull(t2.lyrics, ''))
			  , t1.composers    = dbo.ClrRefineText(isnull(t2.composers, ''))
			  , t1.performers   = dbo.ClrRefineText(isnull(t2.performers, ''))
		from MediaTrack t1
			join inserted t2 on t1.ObjId = t2.ObjId
	end
end
go

create or alter trigger trigAnketaPersonRefine on AnketaPerson after insert, update
as
begin
	set nocount on;
	if trigger_nestlevel(object_id('trigAnketaPersonRefine')) > 1 return
	if update(firstName) or update(lastName) or update(surName) or update(nikName)
	begin
		update t1
		set 
			  t1.firstName    = dbo.ClrRefineText(isnull(t2.firstName, ''))
			, t1.lastName     = dbo.ClrRefineText(isnull(t2.lastName, ''))
			, t1.surName      = dbo.ClrRefineText(isnull(t2.surName, ''))
			, t1.nikName      = dbo.ClrRefineText(isnull(t2.nikName, ''))
		from AnketaPerson t1
			join inserted t2 on t1.CustId = t2.CustId
	end
end
go

create or alter trigger trigAnketaCompanyRefine on AnketaCompany after insert, update
as
begin
	set nocount on;
	if trigger_nestlevel(object_id('trigAnketaCompanyRefine')) > 1 return
	if update(Name) or update(shortName)
	begin
		update t1
		set 
			  t1.Name		   = dbo.ClrRefineText(isnull(t2.Name, ''))
			, t1.shortName     = dbo.ClrRefineText(isnull(t2.shortName, ''))
		from AnketaCompany t1
			join inserted t2 on t1.CustId = t2.CustId
	end
end
go

create or alter trigger trigAnketaExternalRefine on AnketaExternal after insert, update
as
begin
	set nocount on;
	if trigger_nestlevel(object_id('trigAnketaExternalRefine')) > 1 return
	if update(Name)
	begin
		update t1
		set 
			  t1.Name		   = dbo.ClrRefineText(isnull(t2.Name, ''))
		from AnketaExternal t1
			join inserted t2 on t1.CustId = t2.CustId
	end
end
go
