CREATE procedure [dbo].[p_BRlicView] (@licId integer )
as
BEGIN
declare  @result  table(
id	integer	identity,
roleName		varchar(60),
customerName	varchar(60),
innerCode		varchar(20),
countryName		varchar(30),
rate					numeric(6,3),
prepayment		money,
prePaymentType		varchar(20),
actionType				varchar(20),
assentThearter			varchar(20),
custid						int,
objid							int,
cRightId					int,
roleCode					int,
countryCode				int,
workRh						varchar(20),
primary key (id)
)
insert @result(customerName,objid, custid,cRightId,rate,roleCode,countryCode)
select 
t4.name, t1.objid,t4.custId,t2.cRightId,t2.roleRate,t2.roleCode,t4.countryCode
 from [dbo].[vTsk_vBRLicense] t1
join CopyRight t2 on t2.objId = t1.objid and t1.licId =3
join LicAuthorBR t3 on t3.cRightId = t2.cRightId
join vCustomer t4 on t4.custId = t2.custId 
where t1.licId=@licId

update @result set roleName= t2.name
	 from @result t1,CreativeRoleType t2
	 where 
	 t2.codeI = t1.roleCode

update @result set innerCode= t2.innerCode
	 from @result t1,RightHolder t2
	 where 
	 t2.custId = t1.custid

update @result set countryName= t2.countryName
	 from @result t1,Country t2
	 where 
	 t2.countryCode = t1.countryCode

update @result set workRh= t2.name
	 from @result t1,WorkRH t3, WorkType t2
	 where 
	 t1.cRightId = t3.cRightId	and
	 t2.codeI = t3.workTypeRH
update @result 
	set prepayment= t3.prepaySumAuthor,
	prePaymentType =t4.name
	 from @result t1,LicAuthorBR t3,PrePayType t4
	 where 
	 t1.cRightId = t3.cRightId	and
	 t3.prepayType=t4.codeI


select * from @result


End
-- exec p_BRlicView 3