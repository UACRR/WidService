CREATE FUNCTION [dbo].[ft_Tsk_3_AutoLink_WIDW_V3]  (@regId int )
--Автопривязка по внешней базе с витринами
--Версия 3 улучшенная c шагом
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

       declare @accuracy float = 0.6, @precision float = 0.001;

       declare @TmpName table 
       (regId integer, 
        regIItemId integer, 
        WIC integer, 
        coeffName float,
       primary key (WIC, regIItemId) )

      declare @TmpCoeff table 
       (regId integer, 
        regIItemId integer, 
        WIC integer, 
        coeffName float,
        coeffPerformer float, 
        coeffAuthorText float, 
        coeffAuthor float,
       primary key (WIC, regIItemId) )

delete @tmpName

declare @i1 integer = 0, @i2 integer = 600, @iN integer = 0, @str varchar(100)
set @i1 = (select min(regIItemId) from RegisterItem where regId = 3361 and isnull(objid,0)+isnull(WIC,0) = 0)
set @iN = (select max(regIItemId) from RegisterItem where regId = 3361 and isnull(objid,0)+isnull(WIC,0) = 0)
 WHILE @i1 < @iN
 BEGIN 
 --      declare @accuracy float = 0.4, @precision float = 0.001;
       insert into @tmpName (regId, regIItemId, WIC, coeffName)
       select max(regId), regIItemId, t2.WIC, max([dbo].[Ft_tsk_3_Accurace_strong]( t2.name, t1.ItemName, @precision ))
         from 
         ( select regId, regIItemId, objid, WIC 
          , trim(ItemName) as ItemName 
          , left(REPLACE(trim(ItemName),' ',''),3)  as ItemNameIdx
          from  RegisterItem  
           where  regId = @regId --3361  
		         and regIItemId between @i1 and @i1+@i2  
				 and objId is null 
	             --and WIC is null
           ) t1, 
          WID_IPI..wSeekObject t2 
          where t2.nameIdx >='' and t2.nameIdx = t1.ItemNameIdx  
          --and [dbo].[Ft_tsk_3_Accurace]( t2.name, t1.ItemName, @precision ) > @accuracy
          and left(t1.ItemName, 10) like '%'+t2.name+'%'
      group by t1.regIItemId, t2.WIC

	--set @str = convert(varchar(10),@i1)
    --RAISERROR (@str, 0, 1) WITH NOWAIT

	set @i1 = @i1 + @i2+1
	END 

    delete @TmpName where coeffName < @accuracy
	

  delete @TmpCoeff
   --declare @accuracy float = 0.4, @precision float = 0.001;
   insert into @TmpCoeff  (regId, regIItemId, WIC, coeffName, coeffPerformer, coeffAuthorText, coeffAuthor)
    select max(t1.regId), t1.regIItemId, t2.WIC, max(t2.coeffName)
         , max( [dbo].[Ft_tsk_3_Accurace]( t4.lstNa+isnull(' '+t4.fstNa,''), t1.performer, @precision )) as coeffPerformer
         , max( [dbo].[Ft_tsk_3_Accurace]( t3.lstName+isnull(' '+t3.fstName,''), t1.authorText, @precision )) as coeffAuthorText
         , max( [dbo].[Ft_tsk_3_Accurace]( t3.lstName+isnull(' '+t3.fstName,''), t1.authorMusic, @precision )) as coeffAuthor
       from 
       ( select regId, regIItemId, objid, WIC 
          , trim(ItemName) as ItemName 
          , (case when trim(performer) = '' then null else rtrim(trim(performer)) end) as performer
          , (case when trim(authorText) = '' then null else rtrim(trim(authorText)) end) as authorText
          , (case when trim(authorMusic) = '' then null else rtrim(trim(authorMusic)) end) as authorMusic
          from  RegisterItem  ) t1
     join @TmpName t2 on t1.regId= t2.regId and t1.regIItemId = t2.regIItemId
     left outer join WID_IPI..wSeekPerformer t4 on t4.WIC = t2.WIC
     left outer join WID_IPI..wObjectAuthor t3 on t3.WIC = t2.WIC and t3.roleCode <> 8 
     group by t1.regIItemId, t2.WIC

-- declare @accuracy float = 0.4, @precision float = 0.001;
;with Tbl_Sum as 
 (
      select 
       row_number() over( partition by t1.regId,t1.regIItemId  order by t1.regId,t1.regIItemId, 
	     (t1.coeffName + t1.coeffAuthor + t1.coeffAuthorText + t1.coeffPerformer ) desc
              ) as rowid,
         t1.regId, t1.regIItemId, t1.WIC , t1.coeffName, t1.coeffAuthor, t1.coeffAuthorText, t1.coeffPerformer, 
	     t1.coeffName + t1.coeffAuthor + t1.coeffAuthorText + t1.coeffPerformer  as sumAllTogether
       from @TmpCoeff  t1
       where coeffPerformer > @accuracy or coeffAuthorText > @accuracy or coeffAuthor  > @accuracy
    )
     insert into @RT
       select
              t1.regId
              ,t1.regIItemId
              ,t1.WIC
              ,left(t2.name, 254) as objectName
              ,left(t2.Authors, 254) as objectAuthors
              ,left(t2.performers, 254) as objectPerformers
              ,t1.sumAllTogether
        from Tbl_Sum t1
             left join WID_IPI..wObject t2 on t2.WIC = t1.WIC
       where rowid = 1
       order by 1,2

RETURN
END
--select * from ft_Tsk_3_AutoLink_WIDW_v3 (3361) t1 join registerItem t2 on t1.regId = t2.regId and t1.regIitemId = t2.regIItemId 
--select * from WID_IPI..vtsk_3_OR_01_1


