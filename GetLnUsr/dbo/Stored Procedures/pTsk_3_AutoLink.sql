



CREATE procedure [dbo].[pTsk_3_AutoLink] @regId int as
begin

declare @accuracy float = 0.05;
with data_tbl as 
( 
select 
t1.regId,
t1.regIItemId, 
t2.objId 
, max( [dbo].[Ft_tsk_3_Accurace]( t1.ItemName, t2.name, @accuracy )) as accName
,max( [dbo].[Ft_tsk_3_Accurace]( t1.performer, t2.performer, @accuracy )) as accPerformer
,max( [dbo].[Ft_tsk_3_Accurace]( t1.authorText, t2.author, @accuracy )) as accAuthorText 
,max( [dbo].[Ft_tsk_3_Accurace]( t1.authorMusic, t2.author, @accuracy )) as accAuthor
, max([dbo].[Ft_tsk_3_Accurace](t1.ItemName, t3.name, @accuracy )) as accSeekName
, max([dbo].[Ft_tsk_3_Accurace](t1.ItemName, t5.name, @accuracy )) as accSeekPerformer
, max([dbo].[Ft_tsk_3_Accurace](t1.authorText, t5.name, @accuracy )) as accSeekAuthText
, max([dbo].[Ft_tsk_3_Accurace](t1.authorMusic, t5.name, @accuracy )) as accSeekAuthMusic
from RegisterItem t1
join ObjectRight t2 on substring(t2.name,1,1) = substring( t1.ItemName,1,1) 
left outer join SeekObject t3 on t3.objId = t2.objId and t3.codeI = 1
left outer join SeekObject t4 on t4.objId = t2.objId and t3.codeI = 2
left outer join SeekObject t5 on t5.objId = t2.objId and t3.codeI = 3
where
t1.regid = @regId
and t1.objId is null
group by t1.regid, t1.regIItemId, t2.objId
having max( [dbo].[Ft_tsk_3_Accurace]( t1.ItemName, t2.name, @accuracy )) > @accuracy
)
, result_data as 
(
select 
rank() over( partition by t1.regId,t1.regIItemId  order by t1.regId,t1.regIItemId, t1.accName desc, t1.accAuthor desc,
	 t1.accAuthorText desc, t1.accPerformer desc, t1.accSeekAuthMusic desc, t1.accSeekAuthText desc, t1.accSeekPerformer desc ) as rowid,
t1.regId, t1.regIItemId, t1.objId , t1.accName, t1.accAuthor, t1.accAuthorText, t1.accPerformer, t1.accSeekAuthMusic, t1.accSeekAuthText, t1.accSeekPerformer  
from data_tbl t1
)
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

end

GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pTsk_3_AutoLink] TO [ReportUser]
    AS [dbo];

