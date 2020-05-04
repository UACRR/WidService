CREATE procedure [dbo].[OpenAccDebet]
as

begin
/*
create table #Doc(
	regIItemId			int			null,
	distId				int			null,		
	regId					int			null,
--	periodId			int			null,
	distribDate		date		null,
	amount				money,
	kindCode			int			null,
	custId				int			null ,
	objid					int			null,
	ItemName			varchar(120)  null,
	categoryCode	int			null,
	AccIdDebet		int			NULL,
	AccIdCredit		int			NULL,
	AccDebet			varchar(25)			NULL,
	AccCredit			varchar(25)			NULL,
--	partnerId			int				null,
--	partnerComiss	money,
	paynote			varchar	(200)		null
)
drop table #New_Accounts
select * from #New_accounts
*/
SET NOCOUNT ON;
create table #New_Accounts(
  balscode		int,
  custid			int,
  accNls		varchar(24),
  accname		varchar(100),
  accid     int
    )

	insert #New_Accounts(balsCode,custid,accNls) 
	select distinct convert(int,substring(AccDebet,1,2)) ,
	case when substring (AccDebet,1,1)='2' then custid
		 when substring (AccDebet,1,1)='3' then objid
		 else null
	end,AccDebet
	from #Doc where AccIdDebet is null

	update t1
	set accname = SUBSTRING(t2.name,1,100)
	from #New_Accounts t1,vCustomer t2
	where t1.custid = t2.custId
	and
	substring (accNls,1,1)='2'

		update t1
	set accname = SUBSTRING(t2.name,1,100)
	from #New_Accounts t1,ObjectRight t2
	where t1.custid = t2.objId
	and
	substring (accNls,1,1)='3'


insert Account(balsCode,custId,r030,accNls,dateOpen,accStatus,accName,accDK,dateModify)
select   balsCode,custid,'980',accNls,getdate(),0,accName,0,getdate()  from #New_Accounts
where substring (accNls,1,1)='2'
insert Account(balsCode,objId,r030,accNls,dateOpen,accStatus,accName,accDK,dateModify)
select   balsCode,custid,'980',accNls,getdate(),0,accName,0,getdate()  from #New_Accounts
where substring (accNls,1,1)='3'


update t1
set t1.accid = t2.accId
from #New_Accounts t1,Account t2 
where
t2.accnls=t1.accNls

update t2
set AccIdDebet = t1.accid
from #New_Accounts t1,#Doc t2
where
t1.accNls =  t2.AccDebet

--select * from ##doc
end
