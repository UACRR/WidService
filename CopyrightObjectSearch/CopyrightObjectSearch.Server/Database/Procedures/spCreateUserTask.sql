use CopyrightObjectSearch
go

create or alter procedure spCreateUserTask
	@partnerWorkSourceId int
as
begin
	set @partnerWorkSourceId = 566

	declare @userTaskTypeSearchPartnerWork int = 2

	declare @partnerWorksRange int = (
		select isnull(max(PartnerWorksRange), 0) + 1
		from UserTasks
		where PartnerWorkSourceId = 566
	)

	declare @title as nvarchar(255) = (
		select
			concat(
				  t2.Description
				, '_'
				, t3.Description
				, '_'
				, t1.Year
				, '_'
				, case when t1.Quarter <> 0 then 'квартал ' + cast(t1.Quarter as varchar(1)) else 'м≥с€ць ' + cast(t1.Month as varchar(2)) end
				, '_блок_'
				, @partnerWorksRange
			)
		from PartnerWorkSources t1
			join Partners t2 on t1.PartnerId = t2.Id
			join PartnerWorkSourceTypes t3 on t1.SourceTypeId = t3.Id
		where t1.Id = 566
	)


	insert UserTasks (
		  Title
		, UserTaskTypeId
		, PartnerWorkSourceId
		, AssignedUserId
		, PartnerWorksRange
		, CreatedAt
		, UpdatedAt
	)
	select
		  @title							as Title
		, @userTaskTypeSearchPartnerWork	as UserTaskTypeId
		, 566				as PartnerWorkSourceId
		, null								as AssignedUserId
		, @partnerWorksRange				as PartnerWorksRange
		, getdate()							as CreatedAt
		, getdate()							as UpdatedAt

	declare @userTaskId int = scope_identity();

	select t1.*, t2.*
	from PartnerWorks t1
		join PartnerWorkToSources t2 on t1.Id = t2.PartnerWorkId
	where t2.PartnerWorkSourceId = 566
end