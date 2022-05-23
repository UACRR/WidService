create function [dbo].[ft_InvoiceInFileIds] (@fileId int)
returns @retTable
table(id int)
as
begin
	-- Returns ids of all ccid in files that belong to the same invoice as the one with id = @fileId
	insert into @retTable
	select t2.fileId
	from CcidInFile t1
		join CcidInFile t2 on t1.ccidInvoiceId = t2.ccidInvoiceId
			and t1.InstanceIndex = t2.InstanceIndex
	where t1.fileId = @fileId
	return
end 