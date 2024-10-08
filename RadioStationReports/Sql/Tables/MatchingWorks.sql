USE [RadioStationReports]
GO

/****** Object:  Table [dbo].[MatchingWorks]    Script Date: 8/7/2024 2:00:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MatchingWorks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WorkId] [int] NULL,
	[Name] [nvarchar](1000) NULL,
	[Authors] [nvarchar](1000) NULL,
	[Performers] [nvarchar](1000) NULL,
	[FoundInDb] [char](1) NOT NULL,
	[MainOrAlt] [char](1) NOT NULL,
	[FoundId] [int] NOT NULL,
	[IsStrongMatch] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MatchingWorks]  WITH CHECK ADD  CONSTRAINT [FK_MatchingWorks_Work] FOREIGN KEY([WorkId])
REFERENCES [dbo].[Works] ([Id])
GO

ALTER TABLE [dbo].[MatchingWorks] CHECK CONSTRAINT [FK_MatchingWorks_Work]
GO


