USE [AutoSearch]
GO

/****** Object:  Table [dbo].[SourceWorks]    Script Date: 24.09.2025 16:38:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SourceWorksApple](
	[SourceWorkId] [int] IDENTITY(1,1) NOT NULL,
	[WorkId] varchar(30) NULL,
	[Name] [nvarchar](261) NULL,
	[Authors] [nvarchar](2054) NULL,
	[Performers] [nvarchar](2054) NULL,
PRIMARY KEY CLUSTERED 
(
	[SourceWorkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

create nonclustered index idx_SourceWorksApple_WorkId on SourceWorksApple(WorkId)
create nonclustered index idx_SourceWorksApple_Name on SourceWorksApple(Name)


