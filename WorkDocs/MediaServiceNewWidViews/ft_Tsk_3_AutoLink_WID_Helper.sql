USE [MediaService]
GO

/****** Object:  View [dbo].[vtsk_3_OR_01]    Script Date: 2/9/2023 3:43:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE or alter view [dbo].[ft_Tsk_3_AutoLink_WID_Helper] as
/*
with performer as 
(select t2.wic,
  (Select rtrim(t3.LstNa)+' '+rtrim(t3.FstNa)  +','
            From TblArtist t3
            Where t3.wic= t2.wic
			   order by t3.wic         
            For XML PATH ('')) Performer
from  TblArtist t2
group by t2.WIC
 --order by t2.wic
)
*/
with Performer AS 
(
	SELECT t2.WIC, STRING_AGG(CAST(CONCAT(rtrim(t2.PerfArtistLstName), ' ', rtrim(t2.PerfArtistFstName)) as nvarchar(max)), ', ') AS Performer
	FROM SocWid..WidArtist t2
	GROUP BY t2.WIC
),
/*
Authors as 
(select t6.WIC,
(Select rtrim(t5.NAME)+' '+rtrim(t5.FST_NAME)  +','
            From TblIntrPty t4,TBLIPINAME t5
        Where t4.wic= t6.wic
			 and t5.IP_NAME_NR=t4.IPINr			            
           For XML PATH ('')) Authors
from  TblTitle t6
--order by t6.WIC
group by t6.WIC
) ,
*/
	Authors AS 
(
	SELECT t6.WIC, STRING_AGG(CAST(CONCAT(rtrim(t5.NAME), ' ', rtrim(t5.Name)) as nvarchar(max)), ', ') as Authors
	FROM SocWid..WidIntrPty t4,
		 SocIpi..IpiName t5,
		 SocWid..WidTitle t6
	WHERE t4.wic = t6.wic and 
		  t5.IpNameNr = t4.IpNameNr and
		  t4.IpRole not in ('E','CE')
	GROUP BY t6.WIC
),


  Shares as
(  SELECT t12.wic,sum(case t12.RightType when 'PER' then isnull(t12.Shares,0) else 0 end) rateTotalPER ,
				  sum(case t12.RightType when 'MEC' then isnull(t12.Shares,0) else 0 end) rateTotalMEC				  
 FROM SocWid..WidShares t12
 group by t12.wic
  ) ,
  ISWC as
(
select WIC,ISWC from SocWid..widIswc

)
,
ObjectsR as
(  SELECT t12.wic,t12.WrkTtl namem,
  /*TIMEFROMPARTS (--isnull( t2.DurHr,0),
 	
	case when isnull(t12.DurHr,0) > 23 then 23 else isnull(t12.DurHr,0) end  ,
									case when isnull(t12.DurMm,0) > 59 then 59 else isnull(t12.DurMm,0) end  ,
									  case when isnull(t12.DurSs,0) > 59 then 59 else isnull(t12.DurSs,0) end  ,
									  0,0 ) duration
*/
[dbo].[small_to_time](isnull(DurHr,0),isnull(DurMm,0),isnull(DurSs,0)) duration 
									  ,t12.VerType specName,
t12.MwDistrCat GenreType  
 FROM SocWid..WidTitle t12  
  )
    select t1.WIC,t1.namem,t1.specName,t1.GenreType,t1.duration,t3.Authors,
   t2.Performer,t4.rateTotalMEC,t4.rateTotalPER, t5.ISWC
    from ObjectsR t1
  left join performer t2 on (t1.wic =t2.WIC)
  left join   Authors t3 on   (t1.WIC=t3.WIC)
  left join   Shares  t4 on     (t1.WIC=t4.WIC)
  left join   ISWC t5 on		(t1.WIC=t5.WIC)
  --order by t1.WIC
GO


