USE [RadioStationReports]
GO

/****** Object:  Table [dbo].[Works]    Script Date: 8/7/2024 2:02:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Works](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1000) NULL,
	[Authors] [nvarchar](1000) NULL,
	[Performers] [nvarchar](1000) NULL,
	[NameT] [nvarchar](1000) NULL,
	[AuthorsT] [nvarchar](1000) NULL,
	[PerformersT] [nvarchar](1000) NULL,
	[FoundIn] [char](1) NULL,
	[FoundCde] [int] NULL,
	[Iswc] [varchar(13)] NULL,
	[Share] [decimal](5, 2) NULL,
	[IsProcessed] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


