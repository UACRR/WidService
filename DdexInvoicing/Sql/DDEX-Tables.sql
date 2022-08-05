USE [YoutubeReports]
GO

/****** Object:  Table [dbo].[AS01_01]    Script Date: 6/25/2019 9:47:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AS01_01](
	[BlockId] [nvarchar](7) NULL,
	[ResourceReference] [nvarchar](16) NULL,
	[DspResourceId] [nvarchar](16) NULL,
	[ISRC] [nvarchar](12) NULL,
	[Title] [nvarchar](198) NULL,
	[SubTitle] [nvarchar](1) NULL,
	[DisplayArtistName] [nvarchar](1117) NULL,
	[DisplayArtistPartyId] [nvarchar](1) NULL,
	[Duration] [nvarchar](8) NULL,
	[ResourceType] [nvarchar](14) NULL,
	[IsMasterRecording] [nvarchar](1) NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[FOOT](
	[NumberOfLinesInFile] [nvarchar](6) NULL,
	[NumberOfLinesInReport] [nvarchar](8) NULL,
	[NumberOfSummaryRecords] [nvarchar](2) NULL,
	[NumberOfBlocksInFile] [nvarchar](5) NULL,
	[NumberOfBlocksInReport] [nvarchar](7) NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[HEAD](
	[MessageVersion] [nvarchar](18) NULL,
	[Profile] [nvarchar](10) NULL,
	[ProfileVersion] [nvarchar](3) NULL,
	[MessageId] [nvarchar](7) NULL,
	[MessageCreatedDateTime] [nvarchar](20) NULL,
	[FileNumber] [nvarchar](1) NULL,
	[NumberofFiles] [nvarchar](1) NULL,
	[UsageStartDate] [nvarchar](10) NULL,
	[UsageEndDate] [nvarchar](10) NULL,
	[SenderPartyId] [nvarchar](18) NULL,
	[SenderName] [nvarchar](7) NULL,
	[ServiceDescription] [nvarchar](30) NULL,
	[RecipientPartyId] [nvarchar](1) NULL,
	[RecipientName] [nvarchar](8) NULL,
	[RepresentedRepertoire] [nvarchar](17) NULL
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[LI01_02](
	[BlockId] [nvarchar](7) NULL,
	[SummaryRecordId] [nvarchar](19) NULL,
	[RightsController] [nvarchar](16) NULL,
	[RightsControllerPartyId] [nvarchar](1) NULL,
	[RightsControllerWorkID] [nvarchar](26) NULL,
	[RightSharePercent] [nvarchar](8) NULL,
	[RightType] [nvarchar](15) NULL,
	[AllocatedNetRevenue] [nvarchar](9) NULL,
	[AllocatedAmount] [nvarchar](9) NULL,
	[AllocatedUsages] [nvarchar](9) NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[MW01_01](
	[BlockId] [nvarchar](7) NULL,
	[DspWorkId] [nvarchar](15) NULL,
	[ISWC] [nvarchar](11) NULL,
	[Title] [nvarchar](150) NULL,
	[SubTitle] [nvarchar](1) NULL,
	[ComposerAuthor] [nvarchar](1117) NULL,
	[ComposerAuthorPartyId] [nvarchar](24) NULL,
	[Arranger] [nvarchar](1) NULL,
	[ArrangerPartyId] [nvarchar](1) NULL,
	[MusicPublisher] [nvarchar](1) NULL,
	[MusicPublisherPartyId] [nvarchar](1) NULL,
	[WorkContributor] [nvarchar](1) NULL,
	[WorkContributorPartyId] [nvarchar](1) NULL,
	[DataProvider] [nvarchar](1) NULL,
	[ProprietaryWorkId] [nvarchar](1) NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[RU01_01](
	[BlockId] [nvarchar](7) NULL,
	[SummaryRecordId] [nvarchar](2) NULL,
	[DspReleaseId] [nvarchar](1199) NULL,
	[Usages] [nvarchar](397) NULL,
	[ContentCategory] [nvarchar](7) NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SU03_02](
	[BlockId] [nvarchar](7) NULL,
	[SalesTransactionId] [nvarchar](35) NULL,
	[SummaryRecordId] [nvarchar](2) NULL,
	[DspReleaseId] [nvarchar](16) NULL,
	[Usages] [nvarchar](9) NULL,
	[NetRevenue] [nvarchar](8) NULL,
	[ValidityPeriodStart] [nvarchar](10) NULL,
	[ValidityPeriodEnd] [nvarchar](10) NULL,
	[ContentCategory] [nvarchar](7) NULL,
	[IsRoyaltyBearing] [nvarchar](1) NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SY02_02](
	[SummaryRecordId] [nvarchar](19) NULL,
	[DistributionChannel] [nvarchar](1) NULL,
	[DistributionChannelDPID] [nvarchar](1) NULL,
	[CommercialModel] [nvarchar](27) NULL,
	[UseType] [nvarchar](6) NULL,
	[Territory] [nvarchar](2) NULL,
	[ServiceDescription] [nvarchar](30) NULL,
	[Usages] [nvarchar](9) NULL,
	[Users] [nvarchar](1) NULL,
	[Currency] [nvarchar](3) NULL,
	[NetRevenue] [nvarchar](9) NULL,
	[RightsController] [nvarchar](16) NULL,
	[RightsControllerPartyId] [nvarchar](1) NULL,
	[AllocatedUsages] [nvarchar](12) NULL,
	[AllocatedRevenue] [nvarchar](9) NULL,
	[AllocatedNetRevenue] [nvarchar](8) NULL,
	[RightsType] [nvarchar](15) NULL,
	[ContentCategory] [nvarchar](7) NULL,
	[ExchangeRateBaseCurrency] [nvarchar](3) NULL,
	[ExchangeRate] [nvarchar](8) NULL,
	[RightsTypePercentage] [nvarchar](1) NULL
) ON [PRIMARY]
GO



