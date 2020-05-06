create procedure Get_correspondent
as
begin
 select accName,accNls,accName+' '+accNls from account
where
balscode=21
order  by accNls
end
