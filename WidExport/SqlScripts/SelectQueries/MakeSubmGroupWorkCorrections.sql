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

update WidSubmGroupWork
set Status = @WorkStatusAccepted
where Status = @WorkStatusSent