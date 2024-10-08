use SocWidSubmit
go

create or alter procedure spRespFileUpdateErrCodes
	  @respFileId int
as
begin

--declare @respFileId int = 7

;with SourceTable as (
	select distinct
		  MsgType
		, MsgLevel
		, ErrCondNr
		, MsgTxt
	from RecMsg
	where RespFileId = @respFileId
)
merge RespFileErrCode as MergeTarget
using SourceTable as MergeSource
on MergeSource.ErrCondNr = MergeTarget.ErrCondNr
-- For Inserts
when not matched by Target then
insert (
	  ErrCondNr
	, MsgType
	, MsgLevel
	, MsgTxt
	, MsgTxtUkr
) 
values (
	  MergeSource.ErrCondNr
	, MergeSource.MsgType
	, MergeSource.MsgLevel
	, MergeSource.MsgTxt
	, null
)
-- For Updates
/*
when matched then update set
      MergeTarget.ErrCondNr =  MergeSource.ErrCondNr                     
	, MergeTarget.MsgType	=  MergeSource.MsgType	
	, MergeTarget.MsgLevel	=  MergeSource.MsgLevel	
	, MergeTarget.MsgTxt	=  MergeSource.MsgTxt	
*/
;

end
go

-- exec spRespFileUpdateErrCodes 3
