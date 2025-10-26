use CWR
go

drop table if exists TmpRightHolderRoleCorrections
create table TmpRightHolderRoleCorrections (
	  CustId				int primary key
	, RightHolderType		int
	, CntA					int
	, CntC					int
	, CntAR					int
	, CntE					int
	, CntCA					int
	, CntWrong				int
	, RightHolderTypeNew	int
	, CopyRightRoleTypeNew  int
	, IsCorrect				bit default(0)
	, IsApplied				bit default(0)
)
go

truncate table TmpRightHolderRoleCorrections
insert TmpRightHolderRoleCorrections
select
	  CustId			
	, rHolderType	
	, CntA				
	, CntC				
	, CntAR				
	, CntE				
	, CntCA				
	, CntWrong			
	, rHolderType
	, dbo.fnCheckRoleDefined(rHolderType, 0)
	, 0
	, 0
from vWrongRoleAuthorsStat

update TmpRightHolderRoleCorrections
set RightHolderType = @rightHolderType
where CustId = @CustId

update TmpRightHolderRoleCorrections
set IsCorrect = dbo.fnCheckRoleDefined(RightHolderType, CopyRightRoleTypeNew)
where CustId = @CustId

update TmpRightHolderRoleCorrections
set IsApplied = case when dbo.fnCheckRoleDefined(RightHolderType, CopyRightRoleTypeNew) = 0 then 0 else IsApplied end 
where CustId = @CustId