select distinct 
	t1.wic 
from [WID_IPI].[dbo].[TblAltTtl] t1 
left join [WID_IPI].[dbo].[TblArtist] t2 on t2.WIC = t1.WIC 
left join [WID_IPI].[dbo].[wObjectAuthor] t3 on t3.WIC = t1.WIC