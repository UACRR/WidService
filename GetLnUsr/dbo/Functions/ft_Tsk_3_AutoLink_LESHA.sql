CREATE FUNCTION [dbo].[ft_Tsk_3_AutoLink_LESHA]  (@regId int )
RETURNS @RT TABLE
(	
	regId int
	,regIItemId int
	,objId int
	,objectName varchar(254) null
	,objectAuthors varchar(254) null
	,objectPerformers varchar(254) null
	,objectDuration time(7) null
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
	t2.objId 
	, max( [dbo].[Ft_tsk_3_Accurace]( t2.name, t1.ItemName, @precision )) as accName
	, max( [dbo].[Ft_tsk_3_Accurace]( t2.performer, t1.performer, @precision )) as accPerformer
	, max( [dbo].[Ft_tsk_3_Accurace]( t2.author, t1.authorText, @precision )) as accAuthorText 
	, max( [dbo].[Ft_tsk_3_Accurace]( t2.author, t1.authorMusic, @precision )) as accAuthor
	, max( [dbo].[Ft_tsk_3_Accurace]( t3.name, t1.ItemName, @precision )) as accSeekName
	, max( [dbo].[Ft_tsk_3_Accurace]( t4.name, t1.performer, @precision )) as accSeekPerformer
	, IIF( max( [dbo].[Ft_tsk_3_Accurace]( t2.name, t1.ItemName, @precision )) > max( [dbo].[Ft_tsk_3_Accurace]( t3.name, t1.ItemName, @precision ))
			, max( [dbo].[Ft_tsk_3_Accurace]( t2.name, t1.ItemName, @precision )), max( [dbo].[Ft_tsk_3_Accurace]( t3.name, t1.ItemName, @precision )) ) +
		IIF( max( [dbo].[Ft_tsk_3_Accurace]( t2.performer, t1.performer, @precision )) >
			 max( [dbo].[Ft_tsk_3_Accurace]( t4.name, t1.performer, @precision )), 
				max( [dbo].[Ft_tsk_3_Accurace]( t2.performer, t1.performer, @precision )),max( [dbo].[Ft_tsk_3_Accurace]( t4.name, t1.performer, @precision ))) +
		max( [dbo].[Ft_tsk_3_Accurace]( t2.author, t1.authorText, @precision )) + 
		max( [dbo].[Ft_tsk_3_Accurace]( t2.author, t1.authorMusic, @precision )) 
					as sumAllTogether
	from 
	( select regId, regIItemId, objid
	   , trim(ItemName) as ItemName 
	   , case when trim(performer) = '' then null else trim(performer) end performer
	   , case when trim(authorText) = '' then null else trim(authorText) end authorText
	   , case when trim(authorMusic) = '' then null else trim(authorMusic) end authorMusic
	   from  RegisterItem  ) t1
	join ( select objid, name, author, performer from ObjectRight 
			union select t2.objid, t1.name, t2.author, t2.performer from SeekObject t1 join ObjectRight t2 on t2.objId = t1.objId ) t2 on left(t1.ItemName,3) = left(t2.name,3)
    left outer join SeekObject t3 on t3.objId = t2.objId and t3.codeI = 1
	left outer join SeekObject t4 on t4.objId = t2.objId and t3.codeI = 2
	where
	t1.regid = @regId
	and t1.objId is null
	and ( [dbo].[Ft_tsk_3_Accurace]( t2.name, t1.ItemName, @precision ) >= @accuracy ) -- name
	and (
	    ( (t1.authorText is null or (t1.authorText is not null and [dbo].[Ft_tsk_3_Accurace]( t2.author, t1.authorText, @precision ) >= @accuracy )) 
	    and (t1.authorMusic is null or (t1.authorMusic is not null and [dbo].[Ft_tsk_3_Accurace]( t2.author, t1.authorMusic, @precision ) >= @accuracy ))	
	    ) -- authors
	   and (t1.performer is null or (t1.performer is not null and [dbo].[Ft_tsk_3_Accurace]( t2.performer, t1.performer, @precision ) + [dbo].[Ft_tsk_3_Accurace]( t4.name, t1.performer, @precision ) >= @accuracy  )) -- performers
	) -- main check
	group by t1.regid, t1.regIItemId, t2.objId
	--having (max( [dbo].[Ft_tsk_3_Accurace]( t2.name, t1.ItemName, @precision )) + max([dbo].[Ft_tsk_3_Accurace](t3.name, t1.ItemName, @precision )) )>= @accuracy 
	--	   and (( max( [dbo].[Ft_tsk_3_Accurace]( t2.performer, t1.performer, @precision )) + max( [dbo].[Ft_tsk_3_Accurace]( t4.name, t1.performer, @precision )) > 0 )
	--	      or ( max( [dbo].[Ft_tsk_3_Accurace]( t2.author, t1.authorText, @precision )) + max( [dbo].[Ft_tsk_3_Accurace]( t2.author, t1.authorMusic, @precision )) > 0 ))		
	)
	, result_data as 
	(
	select 
	row_number() over( partition by t1.regId,t1.regIItemId  order by t1.regId,t1.regIItemId, t1.sumAllTogether desc
		 ) as rowid,
	t1.regId, t1.regIItemId, t1.objId , t1.accName, t1.accAuthor, t1.accAuthorText, t1.accPerformer, t1.accSeekPerformer  
	from data_tbl t1
	where accPerformer + accAuthorText + accAuthor + accSeekPerformer > 0
	)

	insert into @RT
	select
		t1.regId
		,t1.regIItemId
		,t1.objId
		,t2.name as objectName
		,t2.author as objectAuthors
		,t2.performer as objectPerformers
		,t3.duration as objectDuration
	from result_data t1
		left join ObjectRight t2 on t2.objId = t1.objId
		left join MediaTrack t3 on t3.objId = t1.objId
	where rowid = 1
	order by 1,2
RETURN
END

GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_3_AutoLink_LESHA] TO [ReportUser]
    AS [dbo];

