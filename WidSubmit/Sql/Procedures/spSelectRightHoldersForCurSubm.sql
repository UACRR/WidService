use SocWidSubmitEx
go

create or alter procedure spSelectRightHoldersForCurSubm
	@submId int
as

	if @submId = dbo.fnCurSubmId() -- ДЛЯ ПОТОЧНОГО СЕАНСУ ОБИРАЄМО РОЗШИРЕНУ ІНФОРМАЦІ
	begin
		-- Коди СМАРТ правовласників, які були включені в сеанси пулікації
		drop table if exists #InSubmRightHoldersPrev
		select distinct t2.CustId
		into #InSubmRightHoldersPrev
		from SubmRightHolder t1
			join RightHolder t2 on t1.RightHolderId = t2.Id
		where t1.SubmissionId <> dbo.fnCurSubmId()

		-- Коди СМАРТ правовласників, які включені в поточний сеанс пулікації
		drop table if exists #InSubmRightHoldersCur
		select distinct t2.CustId
		into #InSubmRightHoldersCur
		from vCurSubmRightHolder t1
			join RightHolder t2 on t1.RightHolderId = t2.Id

		select
			  t1.Id																				as Id		
			, t1.ValidFrom																		as ValidFrom	
			, t1.ValidTo																		as ValidTo	
			, t1.CreatedAt																		as CreatedAt	
			, t1.CustId																			as CustId	
			, t1.IpBaseNr																		as IpBaseNr	
			, t1.IpNameNr																		as IpNameNr	
			, t1.Name																			as Name
			, t1.FstName																		as FstName
			, t1.NameForWid																		as NameForWid
			, t1.FstNameForWid																	as FstNameForWid
			, t1.IsOwn																			as IsOwn
			, t1.IsActive																		as IsActive
			, t1.HasIpiAgreePer																	as HasIpiAgreePer
			, t1.HasIpiAgreeMec																	as HasIpiAgreeMec
			, case when t2.CustId is null then cast(0 as bit) else cast(1 as bit) end 			as IsInCurSubm
			, case when t3.CustId is null then cast(0 as bit) else cast(1 as bit) end			as WasPublished
		from vCurOwnRightHolder t1
			left join #InSubmRightHoldersCur t2 on t1.CustId = t2.CustId
			left join #InSubmRightHoldersPrev t3 on t1.CustId = t3.CustId
	end
	else
	begin -- В іншому разі виводимо лише правовласників відповідного сеансу
		select
			  t2.Id																				as Id		
			, t2.ValidFrom																		as ValidFrom	
			, t2.ValidTo																		as ValidTo	
			, t2.CreatedAt																		as CreatedAt	
			, t2.CustId																			as CustId	
			, t2.IpBaseNr																		as IpBaseNr	
			, t2.IpNameNr																		as IpNameNr	
			, t2.Name																			as Name
			, t2.FstName																		as FstName
			, t2.NameForWid																		as NameForWid
			, t2.FstNameForWid																	as FstNameForWid
			, t2.IsOwn																			as IsOwn
			, t2.IsActive																		as IsActive
			, t2.HasIpiAgreePer																	as HasIpiAgreePer
			, t2.HasIpiAgreeMec																	as HasIpiAgreeMec
			, cast(1 as bit)																	as IsInCurSubm
			, cast(1 as bit)																	as WasPublished
		from SubmRightHolder t1
			join RightHolder t2 on t1.RightHolderId = t2.Id
		where SubmissionId = @submId
	end

go

-- exec spSelectRightHoldersForCurSubm 2

-- select * from vCurOwnRightHolder