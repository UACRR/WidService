USE [AppleMusic]
GO

/****** Object:  Table [dbo].[AppleContentReport]    Script Date: 22.09.2025 21:33:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AppleContentReportNew](
	[RecordType] [nvarchar](1000) NULL,
	[TrackDspId] [nvarchar](100) NULL,
	[TrackIsrc] [nvarchar](1000) NULL,
	[TrackTitle] [nvarchar](1000) NULL,
	[TrackPrimaryArtist] [nvarchar](1000) NULL,
	[TrackDuration] [nvarchar](1000) NULL,
	[ComposerAuthor] [nvarchar](1000) NULL,
	[Arranger] [nvarchar](1000) NULL,
	[Publisher] [nvarchar](1000) NULL,
	[ContentProvider] [nvarchar](1000) NULL,
	[ISWC] [nvarchar](1000) NULL,
	[AlbumDspId] [nvarchar](1000) NULL,
	[AlbumUpc] [nvarchar](1000) NULL,
	[AlbumTitle] [nvarchar](1000) NULL,
	[PopularityRank] [nvarchar](1000) NULL,
	[ContentType] [nvarchar](1000) NULL,
	[RecordLabel] [nvarchar](1000) NULL,
	[ContentProviderTrackId] [nvarchar](1000) NULL,
	[ContentProviderAlbumId] [nvarchar](1000) NULL,
	[SpecialAttributes] [nvarchar](1000) NULL,
	[ReleaseYear] [nvarchar](1000) NULL,
	[TrackNumber] [nvarchar](1000) NULL,
	[VolumeNumber] [nvarchar](1000) NULL,
	[ObjId] [int] NULL,
	[WorkTitle] [nvarchar](1000) NULL
) ON [PRIMARY]
GO


