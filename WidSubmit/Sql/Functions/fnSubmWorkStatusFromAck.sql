use SocWidSubmitEx
go

create or alter function fnSubmWorkStatusFromAck (
	@ackStatus char(2)
)
returns int
as
begin
	return case
		when @ackStatus = 'FA' then 3 -- ACCEPTED
		when @ackStatus = 'PA' then 4 -- ACCEPTED_WARNINGS
		when @ackStatus = 'RJ' then 5 -- REJECTED
		else -1
	end;
end
go