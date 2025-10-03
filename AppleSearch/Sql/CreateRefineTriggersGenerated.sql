use MediaService
go

create or alter trigger trigObjectRightRefine on ObjectRight after insert, update
as
begin
    set nocount on;
    if trigger_nestlevel(object_id('trigObjectRightRefine')) > 1 return
    if update(Name)  or  update(Author)  or  update(Performer) 
    begin
        update t1
        set
           t1.Name =  t2.Name,  t1.Author =  t2.Author,  t1.Performer =  t2.Performer
        from ObjectRight t1
            join inserted t2 on t1.ObjId = t2.ObjId
    end
end
go

create or alter trigger trigMediaTrackRefine on MediaTrack after insert, update
as
begin
    set nocount on;
    if trigger_nestlevel(object_id('trigMediaTrackRefine')) > 1 return
    if update(Name)  or  update(lyrics)  or  update(composers)  or  update(performers) 
    begin
        update t1
        set
           t1.Name =  t2.Name,  t1.lyrics =  t2.lyrics,  t1.composers =  t2.composers,  t1.performers =  t2.performers
        from MediaTrack t1
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
           t1.Name =  t2.Name
        from SeekObject t1
            join inserted t2 on t1.Id = t2.Id
    end
end
go

create or alter trigger trigAuthorsRefine on Authors after insert, update
as
begin
    set nocount on;
    if trigger_nestlevel(object_id('trigAuthorsRefine')) > 1 return
    if update(authorName) 
    begin
        update t1
        set
           t1.authorName =  t2.authorName
        from Authors t1
            join inserted t2 on t1.ObjId = t2.ObjId
    end
end
go

create or alter trigger trigPerformerRefine on Performer after insert, update
as
begin
    set nocount on;
    if trigger_nestlevel(object_id('trigPerformerRefine')) > 1 return
    if update(perName) 
    begin
        update t1
        set
           t1.perName =  t2.perName
        from Performer t1
            join inserted t2 on t1.PerId = t2.PerId
    end
end
go

create or alter trigger trigAnketaCompanyRefine on AnketaCompany after insert, update
as
begin
    set nocount on;
    if trigger_nestlevel(object_id('trigAnketaCompanyRefine')) > 1 return
    if update(Name)  or  update(ShortName) 
    begin
        update t1
        set
           t1.Name =  t2.Name,  t1.ShortName =  t2.ShortName
        from AnketaCompany t1
            join inserted t2 on t1.CustId = t2.CustId
    end
end
go

create or alter trigger trigAnketaPersonRefine on AnketaPerson after insert, update
as
begin
    set nocount on;
    if trigger_nestlevel(object_id('trigAnketaPersonRefine')) > 1 return
    if update(FirstName)  or  update(LastName)  or  update(SurName)  or  update(NikName) 
    begin
        update t1
        set
           t1.FirstName =  t2.FirstName,  t1.LastName =  t2.LastName,  t1.SurName =  t2.SurName,  t1.NikName =  t2.NikName
        from AnketaPerson t1
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
           t1.Name =  t2.Name
        from AnketaExternal t1
            join inserted t2 on t1.CustId = t2.CustId
    end
end
go

create or alter trigger trigClnBusinessPlaceRefine on ClnBusinessPlace after insert, update
as
begin
    set nocount on;
    if trigger_nestlevel(object_id('trigClnBusinessPlaceRefine')) > 1 return
    if update(placeName)  or  update(placeCountry)  or  update(placeRegion)  or  update(placeCity)  or  update(placeAddress)  or  update(placePhone) 
    begin
        update t1
        set
           t1.placeName =  t2.placeName,  t1.placeCountry =  t2.placeCountry,  t1.placeRegion =  t2.placeRegion,  t1.placeCity =  t2.placeCity,  t1.placeAddress =  t2.placeAddress,  t1.placePhone =  t2.placePhone
        from ClnBusinessPlace t1
            join inserted t2 on t1.PlaceId = t2.PlaceId
    end
end
go

create or alter trigger trigRegisterItemRefine on RegisterItem after insert, update
as
begin
    set nocount on;
    if trigger_nestlevel(object_id('trigRegisterItemRefine')) > 1 return
    if update(ItemName)  or  update(performer)  or  update(authorMusic)  or  update(authorText) 
    begin
        update t1
        set
           t1.ItemName =  t2.ItemName,  t1.performer =  t2.performer,  t1.authorMusic =  t2.authorMusic,  t1.authorText =  t2.authorText
        from RegisterItem t1
            join inserted t2 on t1.RegId = t2.RegId and t1.RegIItemId = t2.RegIItemId
    end
end
go

create or alter trigger trigRHCatalogItemRefine on RHCatalogItem after insert, update
as
begin
    set nocount on;
    if trigger_nestlevel(object_id('trigRHCatalogItemRefine')) > 1 return
    if update(objName)  or  update(authorName)  or  update(cmName) 
    begin
        update t1
        set
           t1.objName =  t2.objName,  t1.authorName =  t2.authorName,  t1.cmName =  t2.cmName
        from RHCatalogItem t1
            join inserted t2 on t1.ItemId = t2.ItemId
    end
end
go

