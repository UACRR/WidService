
create procedure [dbo].[Ptsk_3_SearchObjWIDSimpl_5]  @t1AltTtl varchar (60) null,@t2LsNa varchar(45) null,
@t3lstName varchar(100) null

as
BEGIN
SET NOCOUNT ON; 
declare @e varchar(8000)

if (@t1AltTtl is null and @t2LsNa is null and @t3lstName is null)
			begin
				return
			end
				SET @t1AltTtl = ''+'"'+ @t1AltTtl +'"'+''
				SET @t2LsNa = ''+'"'+ @t2LsNa +'"'+''
				SET @t3lstName = ''+'"'+ @t3lstName+'"'+''



if (@t1AltTtl is not null and @t2LsNa is not null and @t3lstName is not null)
			begin
					select t1.WIC, t1.iswc, t1.name, t1.authors as author, 
					t1.performers as performer, t1.genreName, t1.rateTotalMEC, t1.rateTotalPER 
					from [WID_IPI].[dbo].wObject t1
								left join [WID_IPI].[dbo].[wObject] t2 on t2.WIC = t1.WIC 
							left join [WID_IPI].[dbo].[wObject] t3 on t3.WIC = t1.WIC
						where 
							contains((t1.name),  @t1AltTtl)
							and contains((t2.performers), @t2LsNa)
							and contains((t3.authors), @t3lstName)
						
return

			end
if (@t1AltTtl is not null and @t2LsNa is not null and @t3lstName is  null)
			begin
					select t1.WIC, t1.iswc, t1.name, t1.authors as author, 
					t1.performers as performer, t1.genreName, t1.rateTotalMEC, t1.rateTotalPER 
					from [WID_IPI].[dbo].wObject t1
							left join [WID_IPI].[dbo].[wObject]   t2 on t2.WIC = t1.WIC 
						where 
							contains((t1.name),  @t1AltTtl)
							and contains((t2.performers), @t2LsNa)
return
			end

if (@t1AltTtl is not null and @t2LsNa is  null and @t3lstName is  null)
			begin
					select WIC, iswc, name, authors as author, performers as performer, genreName, rateTotalMEC, rateTotalPER 
					from [WID_IPI].[dbo].wObject 
							where 
							contains((name),  @t1AltTtl)
return						
			end

if (@t1AltTtl is  null and @t2LsNa is not null and @t3lstName is not null)
			begin
					select t1.WIC, t1.iswc, t1.name, t1.authors as author, 
					t1.performers as performer, t1.genreName, t1.rateTotalMEC, t1.rateTotalPER 
					from [WID_IPI].[dbo].wObject   t1 left join
							 [WID_IPI].[dbo].[wObject] t3 on t3.WIC = t1.WIC
						where 
							contains((t1.performers), @t2LsNa)
							and contains((t3.authors), @t3lstName)
return
			end

if (@t1AltTtl is  null and @t2LsNa is  null and @t3lstName is not  null)
		begin
					select WIC, iswc, name, authors as author, performers as performer, genreName, rateTotalMEC, rateTotalPER 
					from [WID_IPI].[dbo].wObject  
							where 
							contains((authors), @t3lstName)

			end

if (@t1AltTtl is  null and @t2LsNa is not null and @t3lstName is  null)
			begin				
					select WIC, iswc, name, authors as author, performers as performer, genreName, rateTotalMEC, rateTotalPER 
					from [WID_IPI].[dbo].wObject  
							where 
							contains((performers), @t2LsNa)
return
			end

if (@t1AltTtl is not null and @t2LsNa is  null and @t3lstName is not null)
			begin
					select t1.WIC, t1.iswc, t1.name, t1.authors as author, t1.performers as performer, 
					t1.genreName, t1.rateTotalMEC, t1.rateTotalPER 
					from [WID_IPI].[dbo].wObject    t1
							left join [WID_IPI].[dbo].[wObject] t3 on t3.WIC = t1.WIC
						where 
							contains((t1.name),  @t1AltTtl)
							and contains((t3.authors), @t3lstName)
return
			end

--select @e
--exec (@e)

END
--exec Ptsk_3_SearchObjWIDSimpl_5 'BARCAROLLE','MOONEY','HAROLD'
--exec Ptsk_3_SearchObjWIDSimpl_5 'BARCAROLLE','MOONEY',NULL
--exec Ptsk_3_SearchObjWIDSimpl_5 'BEATLE',NULL,'TESTA JAMES M'
--exec Ptsk_3_SearchObjWIDSimpl_5 NULL,'MOONEY','HAROLD'
--exec Ptsk_3_SearchObjWIDSimpl_5 NULL,NULL,'HAROLD'
--exec Ptsk_3_SearchObjWIDSimpl_5 NULL,'MOONEY',NULL
--exec Ptsk_3_SearchObjWIDSimpl_5 'BARCAROLLE',NULL,'HAROLD'
