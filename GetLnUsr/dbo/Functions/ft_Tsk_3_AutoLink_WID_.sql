/****** Object:  UserDefinedFunction [dbo].[ft_Tsk_3_AutoLink_WID]    Script Date: 25.07.2019 3:49:28 ******/

CREATE FUNCTION [dbo].[ft_Tsk_3_AutoLink_WID_]  (@regId int )
RETURNS @RT TABLE
(	
	regId int
	,regIItemId int
	,WIC int
	,objectName varchar(254) null
	,objectAuthors varchar(254) null
	,objectPerformers varchar(254) null
	,sumAllTogether float
)
AS
BEGIN

	declare @accuracy float = 0.4, @precision float = 0.001;

	with 
	data_tbl as 
	( 
	select 
	t1.regId,
	t1.regIItemId, 
	t2.WIC
	, max( [dbo].[Ft_tsk_3_Accurace]( t2.name, t1.ItemName, @precision )) as accName
	, max( [dbo].[Ft_tsk_3_Accurace]( t2.performer, t1.performer, @precision )) as accPerformer
	, max( [dbo].[Ft_tsk_3_Accurace]( t2.author, t1.authorText, @precision )) as accAuthorText 
	, max( [dbo].[Ft_tsk_3_Accurace]( t2.author, t1.authorMusic, @precision )) as accAuthor
    ,max( [dbo].[Ft_tsk_3_Accurace]( t2.name, t1.ItemName, @precision )) + 
        max( [dbo].[Ft_tsk_3_Accurace]( t2.performer, t1.performer, @precision )) + 
		max( [dbo].[Ft_tsk_3_Accurace]( t2.author, t1.authorText, @precision )) + 
		max( [dbo].[Ft_tsk_3_Accurace]( t2.author, t1.authorMusic, @precision )) 
					as sumAllTogether
	from 
	( select regId, regIItemId, objid, WIC 
	   , trim(ItemName) as ItemName 
	   , case when trim(performer) = '' then null else trim(performer) end performer
	   , case when trim(authorText) = '' then null else trim(authorText) end authorText
	   , case when trim(authorMusic) = '' then null else trim(authorMusic) end authorMusic
	   from  RegisterItem 
	   where regId =@regId
	   ) t1
	join  
	(select t2.wic, t2.ttl as name, t3.LstNa+' '+t3.FstNa as performer, t4.IntrPtyRol as rhRole, t5.name +' '+t5.FST_NAME as author
      from 
   ( select WIC, Ttl from WID_IPI..TblTitle
			union 
           select WIC, AltTtl from WID_IPI..TblAltTtl) t2 
    left outer join WID_IPI..TblArtist t3 on t3.WIC = t2.WIC
	left outer join WID_IPI..TblIntrPty t4 on t4.WIC = t3.WIC
	left outer join WID_IPI..TBLIPINAME t5 on t5.IP_NAME_NR = t4.IPINr
       where t4.IntrPtyRol not in ('E') ) t2  on left(t1.ItemName,3) = left(t2.name,3)  --исключаю из авторов издателей
    where
	t1.regid = @regId --and t1.regIItemId in ( 1,2,3,4,5,6,7,8,9,10)  --для теста
	and t1.objId is null 
	and t1.WIC is null
	and ( [dbo].[Ft_tsk_3_Accurace]( t2.name, t1.ItemName, @precision ) >= @accuracy ) -- name
	and (
	    ( (t1.authorText is null or (t1.authorText is not null and [dbo].[Ft_tsk_3_Accurace]( t2.author, t1.authorText, @precision ) >= @accuracy )) 
	    and (t1.authorMusic is null or (t1.authorMusic is not null and [dbo].[Ft_tsk_3_Accurace]( t2.author, t1.authorMusic, @precision ) >= @accuracy ))	
	    ) -- authors
 	   and (t1.performer is null or (t1.performer is not null and [dbo].[Ft_tsk_3_Accurace]( t2.performer, t1.performer, @precision )  >= @accuracy  )) -- performers
	) -- main check
	group by t1.regid, t1.regIItemId, t2.WIC
	)
	, result_data as 
	(
	select 
	row_number() over( partition by t1.regId,t1.regIItemId  order by t1.regId,t1.regIItemId, t1.sumAllTogether desc
		 ) as rowid,
	t1.regId, t1.regIItemId, t1.WIC , t1.accName, t1.accAuthor, t1.accAuthorText, t1.accPerformer, t1.sumAllTogether
	from data_tbl t1
	where accPerformer + accAuthorText + accAuthor  > 0
	)

	insert into @RT
	select
		 t1.regId
		,t1.regIItemId
		,t1.WIC
		,left(t2.namem, 254) as objectName
		,left(t2.Authors, 254) as objectAuthors
		,left(t2.performer, 254) as objectPerformers
		,t1.sumAllTogether
	from result_data t1
		left join WID_IPI..vtsk_3_OR_01 t2 on t2.WIC = t1.WIC
	where rowid = 1
	order by 1,2
RETURN
END
--select * from dbo.ft_Tsk_3_AutoLink_WID (3361)
--select * from WID_IPI..vtsk_3_OR_01
