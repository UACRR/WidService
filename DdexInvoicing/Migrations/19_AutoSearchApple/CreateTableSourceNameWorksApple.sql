USE [AutoSearch]
GO

/****** Object:  Table [dbo].[SourceNameWorks]    Script Date: 24.09.2025 16:51:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SourceNameWorksApple](
	[SourceNameId] [int] NOT NULL,
	[WorkId] varchar(30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SourceNameId] ASC,
	[WorkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

create nonclustered index idx_SourceNameWorksApple_SourceNameId on SourceNameWorksApple(SourceNameId)
create nonclustered index idx_SourceNameWorksApple_WorkId on SourceNameWorksApple(WorkId)


