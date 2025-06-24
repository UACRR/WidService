use Ddex
go

update CcidInFileTestType
set severity = 0

update CcidInFileTestType
set severity = 1
where code in (17, 18, 19, 20)