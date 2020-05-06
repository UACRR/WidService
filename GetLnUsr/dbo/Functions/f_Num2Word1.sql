
--drop function dbo.f_Num2Wort
create function [dbo].[f_Num2Word1] (@Value money, @currency char(3)=NULL, @lang char(2)=NULL)
RETURNS Table
Return 
(
select dbo.f_Num2Word (isnull(@Value,0) , '980', 'Uk') howmoney
)


--select * from f_Num2Word1(0,null,null)
GO
GRANT SELECT
    ON OBJECT::[dbo].[f_Num2Word1] TO [ReportUser]
    AS [dbo];

