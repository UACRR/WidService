USE [YoutubeReports]
GO

/****** Object:  Table [dbo].[DdexIdentifiedAuthors]    Script Date: 7/3/2019 11:10:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DdexIdentifiedAuthors](
	[Id] [uniqueidentifier] NOT NULL,
	[DdexMusicWorkAuthorId] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[RightsPercent] [float] NOT NULL,
 CONSTRAINT [PK_DdexIdentifiedAuthors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DdexIdentifiedAuthors]  WITH CHECK ADD FOREIGN KEY([DdexMusicWorkAuthorId])
REFERENCES [dbo].[DdexMusicWorkAuthors] ([Id])
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DdexMusicWorkAuthors](
	[Id] [uniqueidentifier] NOT NULL,
	[DdexReportId] [uniqueidentifier] NOT NULL,
	[BlockId] [int] NULL,
	[ISRC] [nchar](100) NULL,
	[ResourceTitle] [nvarchar](300) NULL,
	[DisplayArtistName] [nvarchar](2500) NULL,
	[ISWC] [nchar](300) NULL,
	[MusicWorkTitle] [nchar](300) NULL,
	[ComposerAuthor] [nchar](2500) NULL,
 CONSTRAINT [PK_DdexMusicWorkAuthors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DdexMusicWorkAuthors]  WITH CHECK ADD FOREIGN KEY([DdexReportId])
REFERENCES [dbo].[DdexReport] ([Id])
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DdexReport](
	[Id] [uniqueidentifier] NOT NULL,
	[Year] [int] NOT NULL,
	[Quarter] [int] NOT NULL,
	[SourceUri] [varchar](255) NOT NULL,
	[TargetFolder] [varchar](255) NULL,
 CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

