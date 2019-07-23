CREATE function [dbo].[ft_Tsk_5_19_11_BR] ()
returns  @result table (
	id							int		identity,
	cmCustId				int,
	cmName				varchar(100),
 primary key (id )
 )
 as
 begin
 insert @result (cmCustId,cmName)
SELECT 0 cmCustId,'Всі' cmName
insert @result (cmCustId,cmName)
select cmCustId,cmName
 FROM  vCommunity ORDER BY num
 return
end

--select * from ft_Tsk_5_19_11_BR()
GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_19_11_BR] TO [ReportUser]
    AS [dbo];

