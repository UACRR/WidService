USE [DDEX]
GO

drop procedure spSaveExceptionSet
drop type [dbo].[ExceptionMember]
CREATE TYPE [dbo].[ExceptionMember] AS TABLE(
	[id] [int] NOT NULL,
	[dateBegin] [date] NULL,
	[dateEnd] [date] NULL,
	[setCode] [int] NULL,
	[rHolderType] [int] NULL,
	[memberName] [varchar](100) NULL,
	[nameForSeek] [varchar](100) NULL,
	[interCode] [varchar](13) NULL,
	[excType] [int] NULL,
	[custId] [int] NULL,
	[comment] [varchar](100) NULL,
	[IPInr] [varchar](11) NULL,
	[dateCreated] [datetime] NULL,
	ForPub bit,
	ForMec bit
)
GO


