CREATE procedure [dbo].[Ptsk_3_SearchObjWIDSimpl_21]  @t1AltTtl varchar (60) null,@t2LsNa varchar(45) null,
@t3lstName varchar(100) null

as
BEGIN
SET NOCOUNT ON; 
declare @e varchar(8000)

			if (@t1AltTtl='')
					SET @t1AltTtl	=   NULL ;		
			if (@t2LsNa='' )
					SET @t2LsNa	=   NULL ;

			if (@t3lstName='')
					SET @t3lstName	=   NULL ;
				



if (@t1AltTtl is null and @t2LsNa is null and @t3lstName is null)
			begin
				return
			end

if (@t1AltTtl is not null and @t2LsNa is not null and @t3lstName is not null)
			begin
					select * from [WID_IPI].[dbo].[vObjRigthsForLink]  a1,
						(	
							select distinct t1.wic from [WID_IPI].[dbo].[TblAltTtl] t1 
							left join [WID_IPI].[dbo].[TblArtist] t2 on t2.WIC = t1.WIC 
							left join [WID_IPI].[dbo].[wObjectAuthor] t3 on t3.WIC = t1.WIC
						where 
							freetext((t1.AltTtl),  @t1AltTtl)
							and freetext((t2.LstNa, t2.FstNa), @t2LsNa)
							and freetext((t3.lstName, t3.fstName), @t3lstName)
						) a2
							where
									a1.WIC = a2.WIC
return

			end
if (@t1AltTtl is not null and @t2LsNa is not null and @t3lstName is  null)
			begin
					select * from [WID_IPI].[dbo].[vObjRigthsForLink]  a1,
						(	
							select distinct t1.wic from [WID_IPI].[dbo].[TblAltTtl] t1 
							left join [WID_IPI].[dbo].[TblArtist] t2 on t2.WIC = t1.WIC 
						where 
							freetext((t1.AltTtl),  @t1AltTtl)
							and freetext((t2.LstNa, t2.FstNa), @t2LsNa)
						) a2
							where
									a1.WIC = a2.WIC
return
			end

if (@t1AltTtl is not null and @t2LsNa is  null and @t3lstName is  null)
			begin
					select a1.* from 							
							 [WID_IPI].[dbo].[TblAltTtl] a2 ,[WID_IPI].[dbo].[vObjRigthsForLink]  a1
							where 
							freetext((a2.AltTtl),  @t1AltTtl)
							and a1.WIC = a2.WIC			
return						
			end

if (@t1AltTtl is  null and @t2LsNa is not null and @t3lstName is not null)
			begin
					select * from [WID_IPI].[dbo].[vObjRigthsForLink]  a1,
						(	
							select distinct t2.wic from 
							[WID_IPI].[dbo].[TblArtist] t2
							left join [WID_IPI].[dbo].[wObjectAuthor] t3 on t3.WIC = t2.WIC
						where 
							freetext((t2.LstNa, t2.FstNa), @t2LsNa)
							and freetext((t3.lstName, t3.fstName), @t3lstName)
						) a2
							where
									a1.WIC = a2.WIC
return
			end

if (@t1AltTtl is  null and @t2LsNa is  null and @t3lstName is not  null)
		begin
					select a1.* from 							
							 [WID_IPI].[dbo].[wObjectAuthor] a2 ,[WID_IPI].[dbo].[vObjRigthsForLink]  a1
							where 
							freetext((a2.lstName, a2.fstName), @t3lstName)
							and a1.WIC = a2.WIC			
			end

if (@t1AltTtl is  null and @t2LsNa is not null and @t3lstName is  null)
			begin				
					select * from [WID_IPI].[dbo].[vObjRigthsForLink]  a1,[WID_IPI].[dbo].[TblArtist] t2 
					where
						freetext((t2.LstNa, t2.FstNa), @t2LsNa) and
						a1.WIC = t2.WIC
return
			end

if (@t1AltTtl is not null and @t2LsNa is  null and @t3lstName is not null)
			begin
			
				select 	a2.WIC, iswc,a2.AltTtl name, authors as author, performers as performer, genreName, rateTotalMEC, rateTotalPER 
					from [WID_IPI].[dbo].wObject a1,
						(	
							select  t1.wic,t1.AltTtl from [WID_IPI].[dbo].[TblAltTtl] t1 
							left join [WID_IPI].[dbo].[wObjectAuthor] t3 on t3.WIC = t1.WIC
						where 
							freetext((t1.AltTtl),  @t1AltTtl)
							and freetext((t3.lstName, t3.fstName), @t3lstName)
						) a2
							where
									a1.WIC = a2.WIC
									order by a2.wic
return
			end

--select @e
--exec (@e)

END
--exec Ptsk_3_SearchObjWIDSimpl_2 'BARCAROLLE','MOONEY','HAROLD'
--exec Ptsk_3_SearchObjWIDSimpl_2 'BARCAROLLE','MOONEY',NULL
--exec Ptsk_3_SearchObjWIDSimpl_2 'BEATLE',NULL,'TESTa'
--exec Ptsk_3_SearchObjWIDSimpl_2 NULL,'MOONEY','HAROLD'
--exec Ptsk_3_SearchObjWIDSimpl_2 NULL,NULL,'HAROLD'
--exec Ptsk_3_SearchObjWIDSimpl_2 NULL,'MOONEY',NULL
--exec Ptsk_3_SearchObjWIDSimpl_2 'BARCAROLLE',NULL,'HAROLD/u'

