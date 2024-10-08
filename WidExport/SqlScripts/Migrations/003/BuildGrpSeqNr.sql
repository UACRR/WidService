use SocWidSubmit
go

declare @submFileId int = (select Id from SubmFile where name = 'WID2024062012240934300140.021')
print @submFileId -- 3027

-- update statuses for works in sent file to make it possible creating the file one more time
update t1
set Status = 3, ShouldResubmit = 1
--select *
from WidSubmGroupWork t1
	join RecWia t2 on t1.RecWiaId = t2.Id
where t2.SubmFileId = @submFileId

-- Now create subm file for the group in the application
-- Created file will be identical

-- Get new subm file ID and replace name of file to alredy sent file and Status to Sent
declare @newSubmFileId int = (select max(Id) from SubmFile)
update t1
set Name = 'WID2024062012240934300140.021', SubmFileStatus = 1
from SubmFile t1
where t1.Id = @newSubmFileId

-- Delete previous file

delete from RecWia where SubmFileId = @submFileId
delete from RecSip where SubmFileId = @submFileId
delete from RecSsr where SubmFileId = @submFileId
delete from RecOip where SubmFileId = @submFileId
delete from RecOsr where SubmFileId = @submFileId
delete from RecAlt where SubmFileId = @submFileId
delete from RecPer where SubmFileId = @submFileId
delete from RecGrh where SubmFileId = @submFileId
delete from RecGrt where SubmFileId = @submFileId
delete from RecHdr where SubmFileId = @submFileId
delete from RecTrl where SubmFileId = @submFileId
update WidSubmGroupWork set SubmFileId = @newSubmFileId where SubmFileId = @submFileId
delete from SubmFile where Id = @submFileId


