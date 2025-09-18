USE [CWR]
GO

/****** Object:  Table [dbo].[CwrFiles]    Script Date: 16.09.2025 15:04:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CwrFiles](
	[CwrFileId] [int] IDENTITY(1,1) NOT NULL,
	[Direction] [varchar](3) NULL,
	[Path] [nvarchar](512) NULL,
	[Name] [nvarchar](32) NULL,
	[RespPath] [nvarchar](512) NULL,
	[RespName] [nvarchar](32) NULL,
	Status int null
 CONSTRAINT [PK__CwrFiles__BB2F5039E836D9F9] PRIMARY KEY CLUSTERED 
(
	[CwrFileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


