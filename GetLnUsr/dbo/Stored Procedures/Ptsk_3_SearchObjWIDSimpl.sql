CREATE procedure [dbo].[Ptsk_3_SearchObjWIDSimpl]  @t1AltTtl varchar (60) null,@t2LsNa varchar(45) null,
@t3lstName varchar(100) null

as
BEGIN
SET NOCOUNT ON; 
declare @e varchar(8000)
/*
SET @t1AltTtl = ''''+ @t1AltTtl +''''
SET @t2LsNa = ''''+ @t2LsNa +''''
SET @t3lstName = ''''+ @t3lstName +''''
*/

if (@t1AltTtl is null and @t2LsNa is null and @t3lstName is null)
			begin
				return
			end

if (@t1AltTtl is not null and @t2LsNa is not null and @t3lstName is not null)
			begin
				SET @t1AltTtl = ''''+'"'+ @t1AltTtl +'"'+''''
				SET @t2LsNa = ''''+'"'+ @t2LsNa +'"'+''''
				SET @t3lstName = ''''+'"'+ @t3lstName+'"'+''''
				set @e='
					select * from [WID_IPI].[dbo].[vObjRigthsForLink]  a1,
						(	
							select distinct t1.wic from [WID_IPI].[dbo].[TblAltTtl] t1 
							left join [WID_IPI].[dbo].[TblArtist] t2 on t2.WIC = t1.WIC 
							left join [WID_IPI].[dbo].[wObjectAuthor] t3 on t3.WIC = t1.WIC
						where 
							contains((t1.AltTtl), '+ @t1AltTtl+ ')
							and contains((t2.LstNa, t2.FstNa), '+@t2LsNa+')
							and contains((t3.lstName, t3.fstName), '+@t3lstName+')
						) a2
							where
									a1.WIC = a2.WIC
						'
			end
if (@t1AltTtl is not null and @t2LsNa is not null and @t3lstName is  null)
			begin
				SET @t1AltTtl = ''''+'"'+@t1AltTtl +'"'+''''
				SET @t2LsNa = ''''+'"'+ @t2LsNa +'"'+''''
				set @e='
					select * from [WID_IPI].[dbo].[vObjRigthsForLink]  a1,
						(	
							select distinct t1.wic from [WID_IPI].[dbo].[TblAltTtl] t1 
							left join [WID_IPI].[dbo].[TblArtist] t2 on t2.WIC = t1.WIC 
						where 
							contains((t1.AltTtl), '+ @t1AltTtl+ ')
							and contains((t2.LstNa, t2.FstNa), '+@t2LsNa+')
						) a2
							where
									a1.WIC = a2.WIC
						'
			end

if (@t1AltTtl is not null and @t2LsNa is  null and @t3lstName is  null)
			begin
				SET @t1AltTtl = ''''+'"'+ @t1AltTtl +'"'+''''
				set @e='
					select a1.* from 							
							 [WID_IPI].[dbo].[TblAltTtl] a2 ,[WID_IPI].[dbo].[vObjRigthsForLink]  a1
							where 
							contains((a2.AltTtl), '+ @t1AltTtl+ ')
							and a1.WIC = a2.WIC			
						'
			end

if (@t1AltTtl is  null and @t2LsNa is not null and @t3lstName is not null)
			begin
				SET @t2LsNa = ''''+'"'+ @t2LsNa +'"'+''''
				SET @t3lstName = ''''+'"'+ @t3lstName +'"'+''''
				set @e='
					select * from [WID_IPI].[dbo].[vObjRigthsForLink]  a1,
						(	
							select distinct t2.wic from 
							[WID_IPI].[dbo].[TblArtist] t2
							left join [WID_IPI].[dbo].[wObjectAuthor] t3 on t3.WIC = t2.WIC
						where 
							contains((t2.LstNa, t2.FstNa), '+@t2LsNa+')
							and contains((t3.lstName, t3.fstName), '+@t3lstName+')
						) a2
							where
									a1.WIC = a2.WIC
						'
			end

if (@t1AltTtl is  null and @t2LsNa is  null and @t3lstName is not  null)
		begin
				SET @t3lstName = ''''+'"'+ @t3lstName +'"'+''''
				set @e='
					select a1.* from 							
							 [WID_IPI].[dbo].[wObjectAuthor] a2 ,[WID_IPI].[dbo].[vObjRigthsForLink]  a1
							where 
							contains((a2.lstName, a2.fstName), '+@t3lstName+')
							and a1.WIC = a2.WIC			
						'
			end

if (@t1AltTtl is  null and @t2LsNa is not null and @t3lstName is  null)
			begin				
				SET @t2LsNa = ''''+'"'+ @t2LsNa +'"'+''''
				set @e='
					select * from [WID_IPI].[dbo].[vObjRigthsForLink]  a1,[WID_IPI].[dbo].[TblArtist] t2 
					where
						contains((t2.LstNa, t2.FstNa), '+@t2LsNa+') and
						a1.WIC = t2.WIC
						'
			end

if (@t1AltTtl is not null and @t2LsNa is  null and @t3lstName is not null)
			begin
				SET @t1AltTtl = ''''+'"'+ @t1AltTtl +'"'+''''
				SET @t3lstName = ''''+'"'+ @t3lstName +'"'+''''
				set @e='
					select * from [WID_IPI].[dbo].[vObjRigthsForLink]  a1,
						(	
							select distinct t1.wic from [WID_IPI].[dbo].[TblAltTtl] t1 
							left join [WID_IPI].[dbo].[wObjectAuthor] t3 on t3.WIC = t1.WIC
						where 
							contains((t1.AltTtl), '+ @t1AltTtl+ ')
							and contains((t3.lstName, t3.fstName), '+@t3lstName+')
						) a2
							where
									a1.WIC = a2.WIC
						'
			end

--select @e
exec (@e)

END
--exec Ptsk_3_SearchObjWIDSimpl 'BARCAROLLE FROM','MOONEY','HAROLD'
--exec Ptsk_3_SearchObjWIDSimpl 'BARCAROLLE','MOONEY',NULL
--exec Ptsk_3_SearchObjWIDSimpl 'BARCAROLLE',NULL,NULL
--exec Ptsk_3_SearchObjWIDSimpl NULL,'MOONEY','HAROLD'
--exec Ptsk_3_SearchObjWIDSimpl NULL,NULL,'HAROLD'
--exec Ptsk_3_SearchObjWIDSimpl NULL,'MOONEY',NULL
--exec Ptsk_3_SearchObjWIDSimpl 'BARCAROLLE',NULL,'HAROLD'
       
