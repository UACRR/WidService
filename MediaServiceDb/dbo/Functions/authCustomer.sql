CREATE function [dbo].[authCustomer] (@userId varchar(48) )
RETURNS TABLE 
AS RETURN
(
with aspUser as (
select t3.custId, serverroles.name as serverRole, t3.roleType as clientRole
from
 AspNetUsers t1
left outer join AspNetUserRoles t2 on t2.userId = t1.id
left outer join AspNetRoles serverroles on serverroles.id = t2.roleId
left outer join userRole t3 on t3.userId = t1.id
where t1.id = @userId
)
select 
distinct
t1.custID
from Customer t1 
join aspUser rightUser on ( rightUser.serverRole = 'Admin' or rightUser.custID = t1.custID )

);