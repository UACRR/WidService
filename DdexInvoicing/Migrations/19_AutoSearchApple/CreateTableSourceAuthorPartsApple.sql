USE [AutoSearch]
GO

/****** Object:  Table [dbo].[SourceAuthorParts]    Script Date: 24.09.2025 17:20:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SourceAuthorPartsApple](
	[SourceAuthorPartId] [int] IDENTITY(1,1) NOT NULL,
	[WorkId] varchar(30) NULL,
	[Name] [nvarchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[SourceAuthorPartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

create nonclustered index idx_SourceAuthorPartsApple_Name on SourceAuthorPartsApple(Name)


