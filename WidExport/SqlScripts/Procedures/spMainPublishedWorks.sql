use SocWidSubmit
go

create or alter procedure spMainPublishedWorks
	  @filter as nvarchar(100)
	, @source int
as
begin
if @source is not null
	select top 1000 
		  t1.ObjId	as ObjId			
		, t1.Wic	as Wic
		, t1.Iswc	as Iswc
		, t2.name	as LocalName
		, t2.author	as Authors
		, t3.WrkTtl	as WidName
		, t4.Code	as SourceName
	from ObjIdToWic t1
		left join MediaService..ObjectRight t2 on t1.ObjId = t2.objId
		left join SocWid..WidTitle t3 on t1.Wic = t3.Wic
		join ObjIdToWicSource t4 on t1.Source = t4.Id
	where t4.Id = @source
		and t2.Name like @filter
	order by t2.Name
else
	select top 1000
		  t1.ObjId	as ObjId	
		, t1.Wic	as Wic
		, t1.Iswc	as Iswc
		, t2.name	as LocalName
		, t2.author	as Authors
		, t3.WrkTtl	as WidName
		, t4.Code	as SourceName
	from ObjIdToWic t1
		left join MediaService..ObjectRight t2 on t1.ObjId = t2.objId
		left join SocWid..WidTitle t3 on t1.Wic = t3.Wic
		join ObjIdToWicSource t4 on t1.Source = t4.Id
	where t2.Name like @filter
	order by t2.Name
end
go

-- spMainPublishedWorks 'a%', null