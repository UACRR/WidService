drop table if exists ShareCalc..RaoRightHolders
select distinct t1.CustId, t3.FullName, t3.Name, trim(concat(t3.FirstName, ' ', t3.SurName)) as FstName,   t4.InterCode
into ShareCalc..RaoRightHolders
from CustCmRight t1
	join Community t2 on t1.CmCustId = t2.CustId
	join vCustomerNameDetailed t3 on t1.CustId = t3.CustId
	join RightHolder t4 on  t1.CustId = t4.CustId
where t2.InterCode = 94

select CustId as [Код]
	, FullName as [Назва]
	, Name
	, FstName
	, InterCode as [Міжнародний код]
	, substring(fullname, 0, charindex(' ', fullname)) as lastname
from ShareCalc..RaoRightHolders 
where InterCode = ''
	and FstName = ''
order by FullName

----------------------------------------------------
drop table if exists ShareCalc..RaoRightHolderWorks
select distinct t3.ObjId, t4.Name
into ShareCalc..RaoRightHolderWorks
from ShareCalc..RaoRightHolders t1
	join RightHolder t2 on t1.CustId = t2.CustId
	join CopyRight t3 on t2.CustId = t3.CustId
	join ObjectRight t4 on t3.ObjId = t4.ObjId
where t3.Status = 1
	and getdate() between t3.beginDate and t3.endDate

select ObjId as [Код], Name as [Назва] from ShareCalc..RaoRightHolderWorks order by Name

-------------------------------------------------------------------
drop table if exists ShareCalc..RaoRightHolderShares
select t1.ObjId, t1.Name, t5.FullName, t3.Rate, t3.RateMech, t3.beginDate, t3.endDate
into ShareCalc..RaoRightHolderShares
from ShareCalc..RaoRightHolderWorks t1 
	join COpyRight t3 on t1.ObjId = t3.ObjId
	join ShareCalc..RaoRightHolders t4 on t3.CustId = t4.CustId
	join vCustomerNameDetailed t5 on t4.CustId = t5.CustId
where t3.Status = 1
	and getdate() between t3.beginDate and t3.endDate
order by t1.Name

select ObjId as [Код твору], Name as [Назва твору], FullName as [Правовласник], Rate as [Пуб%], RateMech as [Мех%], BeginDate as [Початок], EndDate as [Завершення]
from ShareCalc..RaoRightHolderShares order by Name, ObjId, FullName

--------------------------------------------------------------------------------
drop table if exists ShareCalc..RaoRightHolderIpiNames
select t1.CustId, t1.FullName, t2.*
into ShareCalc..RaoRightHolderIpiNames
from ShareCalc..RaoRightHolders t1
	join SocIpi..IpiName t2 on dbo.TransLitFromUkrToLat(t1.Name) = t2.Name
		and left(dbo.TransLitFromUkrToLat(t1.FstName), 1) = left(t2.Name, 1)
	--join SocIpi..IpiName t2 on left(dbo.TransLitFromUkrToLat(t1.FullName), 6) = left((concat(t2.Name, ' ', t2.FstName)), 6)
where t1.interCode  = ''

select * from ShareCalc..RaoRightHolderIpiNames order by CustId


--------------------------------------------------------------------------------
select distinct t3.CustId, t3.FullName
from ShareCalc..RaoRightHolders t1
	join RightHolder t2 on t1.CustId = t2.CustId
	join vCustomerNameDetailed t3 on t2.CustId = t3.CustId
	join SocIpi..IpiAgreement t4 on t2.InterCode = t4.IpBaseNr
where isnull(t2.InterCode, '') <> ''
	and t4.SocCde <> 94
	and t4.CreClsCde  = 'MW'
	and t4.RolCde in ('LY', 'MC', 'EM')
	and t4.RgtCde in ('PR', 'MR')


select cRightId, ObjId, CustId, rate, rate, rateMech, rateMech
	from MediaService..CopyRight
	where Status = 1
		and getdate() between isnull(beginDate, datefromparts(1900, 1, 1)) and isnull(endDate, datefromparts(3000, 1, 1))
		and (isnull(rate, 0) + isnull(rateMech, 0)) > 0
		and ObjId = 979770