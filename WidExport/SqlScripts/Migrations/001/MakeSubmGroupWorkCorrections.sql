use SocWidSubmit
go

declare @WorkStatusUnprocessed   int = 0
declare @WorkStatusInWork		 int = 1
declare @WorkStatusPostponed	 int = 2
declare @WorkStatusAccepted		 int = 3
declare @WorkStatusSent			 int = 4
declare @WorkStatusApproved		 int = 5
declare @WorkStatusRejected		 int = 6
declare @WorkStatusPartApproved	 int = 7
declare @WorkStatusAlreadyInWid	 int = 8
declare @WorkStatusReSent		 int = 9
declare @WorkStatusCompleted	 int = 10

update WidSubmGroupWork
set Status = @WorkStatusAccepted
where Status = @WorkStatusSent or Status = @WorkStatusReSent

update WidSubmGroupWork
set ShouldResubmit = null

update SubmFile set SubmFileStatus = 0

declare @GroupStatusCreated			int = 0
declare @GroupStatusFileCreated		int = 1
declare @GroupStatusFileSubmitted	int = 2
declare @GroupStatusResponded		int = 3
declare @GroupStatusCompleted		int = 4

update WidSubmGroup set  Status = @GroupStatusFileCreated where Status = @GroupStatusFileSubmitted

update RecWia set SubmWrkNr = concat('MS', substring(SubmWrkNr, 7, 100))