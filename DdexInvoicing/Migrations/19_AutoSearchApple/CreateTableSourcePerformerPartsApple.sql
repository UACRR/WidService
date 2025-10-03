USE [AutoSearch]
GO

/****** Object:  Table [dbo].[SourcePerformerParts]    Script Date: 24.09.2025 17:06:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SourcePerformerPartsApple](
	[SourcePerformerPartId] [int] IDENTITY(1,1) NOT NULL,
	[WorkId] varchar(30) NULL,
	[Name] [nvarchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[SourcePerformerPartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

create nonclustered index idx_SourcePerformerPartsApple_Name on SourcePerformerPartsApple(Name)


