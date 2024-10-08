use SocWidSubmit
go

create or alter procedure spSubmFileSetSubmitted
	  @submFileId int
	, @name varchar(32)
as
begin
update SubmFile 
set  
	  Name = @name
	, SubmFileStatus = 1 -- Submitted
where Id = @submFileId

update WidSubmGroupWork
set
	  Status = case
		when Status = 3 then 4 -- Submitted 
		else 9 -- ReSubmitted 
	  end
	, SubmFileId = @submFileId
where Status = 3 -- Accepted
	or ShouldResubmit = 1

end
go

-- exec spSubmFileSetSubmitted 2, 'SomeName'
