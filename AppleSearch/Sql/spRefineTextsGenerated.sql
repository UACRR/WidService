use MediaService
go
create or alter procedure spRefineTexts
as
begin
update ObjectRight          set Name           = dbo.ClrRefineText(Name          ) where Name           is not null and dbo.ClrNeedRefineText(Name          ) = 1
update ObjectRight          set Author         = dbo.ClrRefineText(Author        ) where Author         is not null and dbo.ClrNeedRefineText(Author        ) = 1
update ObjectRight          set Performer      = dbo.ClrRefineText(Performer     ) where Performer      is not null and dbo.ClrNeedRefineText(Performer     ) = 1

update MediaTrack           set Name           = dbo.ClrRefineText(Name          ) where Name           is not null and dbo.ClrNeedRefineText(Name          ) = 1
update MediaTrack           set lyrics         = dbo.ClrRefineText(lyrics        ) where lyrics         is not null and dbo.ClrNeedRefineText(lyrics        ) = 1
update MediaTrack           set composers      = dbo.ClrRefineText(composers     ) where composers      is not null and dbo.ClrNeedRefineText(composers     ) = 1
update MediaTrack           set performers     = dbo.ClrRefineText(performers    ) where performers     is not null and dbo.ClrNeedRefineText(performers    ) = 1

update SeekObject           set Name           = dbo.ClrRefineText(Name          ) where Name           is not null and dbo.ClrNeedRefineText(Name          ) = 1

update Authors              set authorName     = dbo.ClrRefineText(authorName    ) where authorName     is not null and dbo.ClrNeedRefineText(authorName    ) = 1

update Performer            set perName        = dbo.ClrRefineText(perName       ) where perName        is not null and dbo.ClrNeedRefineText(perName       ) = 1

update AnketaCompany        set Name           = dbo.ClrRefineText(Name          ) where Name           is not null and dbo.ClrNeedRefineText(Name          ) = 1
update AnketaCompany        set ShortName      = dbo.ClrRefineText(ShortName     ) where ShortName      is not null and dbo.ClrNeedRefineText(ShortName     ) = 1

update AnketaPerson         set FirstName      = dbo.ClrRefineText(FirstName     ) where FirstName      is not null and dbo.ClrNeedRefineText(FirstName     ) = 1
update AnketaPerson         set LastName       = dbo.ClrRefineText(LastName      ) where LastName       is not null and dbo.ClrNeedRefineText(LastName      ) = 1
update AnketaPerson         set SurName        = dbo.ClrRefineText(SurName       ) where SurName        is not null and dbo.ClrNeedRefineText(SurName       ) = 1
update AnketaPerson         set NikName        = dbo.ClrRefineText(NikName       ) where NikName        is not null and dbo.ClrNeedRefineText(NikName       ) = 1

update AnketaExternal       set Name           = dbo.ClrRefineText(Name          ) where Name           is not null and dbo.ClrNeedRefineText(Name          ) = 1

update ClnBusinessPlace     set placeName      = dbo.ClrRefineText(placeName     ) where placeName      is not null and dbo.ClrNeedRefineText(placeName     ) = 1
update ClnBusinessPlace     set placeCountry   = dbo.ClrRefineText(placeCountry  ) where placeCountry   is not null and dbo.ClrNeedRefineText(placeCountry  ) = 1
update ClnBusinessPlace     set placeRegion    = dbo.ClrRefineText(placeRegion   ) where placeRegion    is not null and dbo.ClrNeedRefineText(placeRegion   ) = 1
update ClnBusinessPlace     set placeCity      = dbo.ClrRefineText(placeCity     ) where placeCity      is not null and dbo.ClrNeedRefineText(placeCity     ) = 1
update ClnBusinessPlace     set placeAddress   = dbo.ClrRefineText(placeAddress  ) where placeAddress   is not null and dbo.ClrNeedRefineText(placeAddress  ) = 1
update ClnBusinessPlace     set placePhone     = dbo.ClrRefineText(placePhone    ) where placePhone     is not null and dbo.ClrNeedRefineText(placePhone    ) = 1

update RegisterItem         set ItemName       = dbo.ClrRefineText(ItemName      ) where ItemName       is not null and dbo.ClrNeedRefineText(ItemName      ) = 1
update RegisterItem         set performer      = dbo.ClrRefineText(performer     ) where performer      is not null and dbo.ClrNeedRefineText(performer     ) = 1
update RegisterItem         set authorMusic    = dbo.ClrRefineText(authorMusic   ) where authorMusic    is not null and dbo.ClrNeedRefineText(authorMusic   ) = 1
update RegisterItem         set authorText     = dbo.ClrRefineText(authorText    ) where authorText     is not null and dbo.ClrNeedRefineText(authorText    ) = 1

update RHCatalogItem        set objName        = dbo.ClrRefineText(objName       ) where objName        is not null and dbo.ClrNeedRefineText(objName       ) = 1
update RHCatalogItem        set authorName     = dbo.ClrRefineText(authorName    ) where authorName     is not null and dbo.ClrNeedRefineText(authorName    ) = 1
update RHCatalogItem        set cmName         = dbo.ClrRefineText(cmName        ) where cmName         is not null and dbo.ClrNeedRefineText(cmName        ) = 1

end
go

-- exec spRefineTexts
