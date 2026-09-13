
-- >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> ShareCalc..RhNames
begin
	truncate table ShareCalc..Z_RhNames

	; with CustIds as (select distinct CustId from ShareCalc..RaoRightHolders)
	insert ShareCalc..Z_RhNames
	select
		  t1.CustId
		, trim(t2.FullName  )
		, trim(t2.Name		)
		, trim(t2.FirstName	)
		, trim(t2.SurName	)
		, ''
		, ''
		, charindex(' ', trim(FullName))
	from RightHolder t1
		join vCustomerNameDetailed t2 on t1.CustId = t2.CustId
		join CustIds t3 on t1.CustId = t3.CustId
	where isnull(InterCode, '') = ''
		and isnull(t2.FullName, '') <> ''

	update ShareCalc..Z_RhNames
	set LstName = LstNameOrig
	where NameSepIdx = 0

	update ShareCalc..Z_RhNames
	set LstName = substring(LstNameOrig, 0, NameSepIdx)
		, FstName = substring(LstNameOrig, NameSepIdx, len(LstNameOrig))
	where NameSepIdx > 0

	update ShareCalc..Z_RhNames
	set FstName = trim(concat(FstNameOrig, ' ', SurNameOrig))
	where FstName = ''
end


-- >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> ShareCalc..RhNamesTr
begin
	truncate table ShareCalc..Z_RhNamesTr
	
	insert ShareCalc..Z_RhNamesTr
	select
		  CustId
		, trim(dbo.TransLitFromUkrToLat(FullNameOrig))
		, trim(dbo.TransLitFromUkrToLat(LstName))
		, trim(dbo.TransLitFromUkrToLat(FstName))
		, ''
		, ''
	from ShareCalc..Z_RhNames
	where trim(LstName) <> ''
end

-- SEARCH EXACT
begin
	truncate table ShareCalc..Z_RhFound
	insert ShareCalc..Z_RhFound
	select distinct t1.CustId, t2.IpBaseNr
	from ShareCalc..Z_RhNamesTr t1
		join SocIpi..IpiName t2 on t1.LstName = t2.Name
			and t1.FstName = t2.FstName

	exec ShareCalc..spRhSearchApplyResult 'DIRECT ALL/ALL', 1
end

-- SEARCH EXACT INVERTED
begin
	truncate table ShareCalc..Z_RhFound
	insert ShareCalc..Z_RhFound
	select distinct t1.CustId, t2.IpBaseNr
	from ShareCalc..Z_RhNamesTr t1
		join SocIpi..IpiName t2 on t1.FstName = t2.Name
			and t1.LstName = t2.FstName
	where t1.IpBaseNr = ''

	exec ShareCalc..spRhSearchApplyResult 'INVERTED ALL/ALL', 1
end

-- SEARCH BY FSTNAME PART
declare @fstNameCharCnt int = 6
declare @foundBy varchar(32)
while @fstNameCharCnt > 1
begin
	truncate table ShareCalc..Z_RhFound
	insert ShareCalc..Z_RhFound
	select distinct t1.CustId, t2.IpBaseNr
	from ShareCalc..Z_RhNamesTr t1
		join SocIpi..IpiName t2 on t1.LstName = t2.Name
			and left(t1.FstName, @fstNameCharCnt) = left(t2.FstName, @fstNameCharCnt)
	where t1.IpBaseNr = ''

	set @foundBy = concat('DIRECT ALL/', @fstNameCharCnt)
	exec ShareCalc..spRhSearchApplyResult @foundBy, 0

	set @fstNameCharCnt = @fstNameCharCnt - 1
end

-- -- SEARCH BY FSTNAME PART INVERTED
declare @fstNameCharCnt1 int = 6
declare @foundBy1 varchar(32)
while @fstNameCharCnt1 > 1
begin
	truncate table ShareCalc..Z_RhFound
	insert ShareCalc..Z_RhFound
	select distinct t1.CustId, t2.IpBaseNr
	from ShareCalc..Z_RhNamesTr t1
		join SocIpi..IpiName t2 on t1.FstName = t2.Name
			and left(t1.LstName, @fstNameCharCnt1) = left(t2.FstName, @fstNameCharCnt1)
	where t1.IpBaseNr = ''

	set @foundBy1 = concat('INVERTED ALL/', @fstNameCharCnt1)
	exec ShareCalc..spRhSearchApplyResult @foundBy1, 0

	set @fstNameCharCnt1 = @fstNameCharCnt1 - 1
end

-- SEARCH 3
drop table if exists #Found
select distinct t1.CustId, t2.IpBaseNr
into #Found
from ShareCalc..RhNamesTr t1
	join SocIpi..IpiName t2 on left(t1.LstName, len(t1.LstName) - 1) = left(t2.Name, len(t1.LstName) - 1)
		and left(t1.FstName, 3) = left(t2.FstName, 3)
where t1.IpBaseNr = ''

drop table if exists #Ranked
select CustId, count(*) as Cnt into #Ranked from #Found group by CustId

update t3
set t3.IpBaseNr = t2.IpBaseNr
from #Ranked t1
	join #Found t2 on t1.CustId = t2.CustId
	join ShareCalc..RhNamesTr t3 on t1.CustId = t3.CustId
where t1.Cnt = 1



