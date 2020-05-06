
/****** Object:  Table [dbo].[CCID_FILE]    Script Date: 7/11/2019 1:58:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CCID_FILE](
	[DdexFileId] [int] NOT NULL,
	[CCIdFileId] [int] NOT NULL,
	[CCIdFileName] [varchar](100) NULL,
	[Year] [int] NOT NULL,
	[Quarter] [int] NOT NULL,
	[SourceUri] [varchar](255) NOT NULL,
	[TargetFolder] [varchar](255) NULL,
 CONSTRAINT [PK_CCID_FILE] PRIMARY KEY CLUSTERED 
(
	[CCIdFileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CCID_FILE]  WITH CHECK ADD  CONSTRAINT [FK_CCID_FIL_REFERENCE_DDEXREPO] FOREIGN KEY([DdexFileId])
REFERENCES [dbo].[DdexReport] ([fileId])
GO

ALTER TABLE [dbo].[CCID_FILE] CHECK CONSTRAINT [FK_CCID_FIL_REFERENCE_DDEXREPO]
GO



/****** Object:  Table [dbo].[CCID_HEADER]    Script Date: 7/11/2019 1:58:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CCID_HEADER](
	[CCIdFileId] [int] NOT NULL,
	[record_type] [char](2) NOT NULL,
	[version] [varchar](12) NOT NULL,
	[date] [date] NOT NULL,
	[sender] [varchar](45) NOT NULL,
	[receiver] [varchar](45) NOT NULL,
	[ccid_id] [varchar](10) NULL,
	[start_date] [int] NOT NULL,
	[end_date] [int] NOT NULL,
	[royalty_currency] [char](3) NOT NULL,
	[original_revenue_basis_currency] [char](3) NOT NULL,
	[conversion_rate] [decimal](20, 6) NOT NULL,
	[work_code_type] [varchar](30) NULL,
	[ccid_id_correcti on_reference] [varchar](10) NULL,
	[type_of_claim] [char](2) NOT NULL,
	[commercial_model] [varchar](30) NOT NULL,
	[service_description] [varchar](30) NOT NULL,
	[use_type] [varchar](30) NOT NULL,
	[mech_perc_split] [decimal](6, 2) NOT NULL,
	[perf_perc_split] [decimal](6, 2) NOT NULL,
	[aux] [varchar](100) NULL,
 CONSTRAINT [PK_CCID_HEADER] PRIMARY KEY CLUSTERED 
(
	[CCIdFileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CCID_HEADER]  WITH CHECK ADD  CONSTRAINT [FK_CCID_HEA_REFERENCE_CCID_FIL] FOREIGN KEY([CCIdFileId])
REFERENCES [dbo].[CCID_FILE] ([CCIdFileId])
GO

ALTER TABLE [dbo].[CCID_HEADER] CHECK CONSTRAINT [FK_CCID_HEA_REFERENCE_CCID_FIL]
GO


/****** Object:  Table [dbo].[CCID_Detail]    Script Date: 7/11/2019 1:59:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CCID_Detail](
	[CCIdFileId] [int] NOT NULL,
	[record_type] [char](2) NOT NULL,
	[transaction_ type] [char](3) NOT NULL,
	[ref_id] [numeric](20, 0) NOT NULL,
	[correction_reference] [numeric](20, 0) NULL,
	[sales_transaction_id] [nvarchar](60) NULL,
	[work_id] [nvarchar](60) NULL,
	[release_id] [nvarchar](60) NULL,
	[resource_id] [nvarchar](60) NOT NULL,
	[isrc] [varchar](12) NULL,
	[iswc] [varchar](11) NULL,
	[workcode] [varchar](39) NULL,
	[work_title] [varchar](60) NOT NULL,
	[use_quantity] [decimal](10, 0) NOT NULL,
	[applied_tariff] [varchar](10) NULL,
	[royalty_type] [char](2) NULL,
	[revenue_basis] [numeric](30, 10) NULL,
	[original_rele ase_revenue_ basis] [numeric](30, 10) NULL,
	[original_res ource_revenu e_basis] [numeric](30, 10) NULL,
	[royalty] [numeric](30, 10) NULL,
	[resource_share] [numeric](6, 2) NULL,
	[restrictions] [varchar](10) NULL,
	[claim_licensor_combined] [numeric](6, 2) NOT NULL,
	[claim_copcon_combined] [numeric](6, 2) NULL,
	[claim_unmatched_combined] [numeric](6, 2) NULL,
	[claim_pd_combined] [numeric](6, 2) NULL,
	[claim_not_collected_combined] [numeric](6, 2) NULL,
	[amount_invoiced_total] [numeric](30, 4) NOT NULL,
	[claim_licensor_mech] [numeric](6, 2) NOT NULL,
	[claim_licensor_perf] [numeric](6, 2) NOT NULL,
	[amount_licensor_mech] [numeric](30, 4) NOT NULL,
	[amount_licensor_perf] [numeric](30, 4) NOT NULL,
	[amount_copcon_mech] [numeric](30, 4) NULL,
	[amount_copcon_perf] [numeric](30, 4) NULL,
	[amount_pd_mech] [numeric](30, 4) NULL,
	[amount_pd_perf] [numeric](30, 4) NULL,
	[amount_not_collected_mech] [numeric](30, 4) NULL,
	[amount_not_collected_perf] [numeric](30, 4) NULL,
	[amount_unmatched_mech] [numeric](30, 4) NULL,
	[amount_unma tched_perf] [numeric](30, 4) NULL,
	[claim_copcon_mech] [numeric](6, 2) NULL,
	[claim_copcon_perf] [numeric](6, 2) NULL,
	[claim_pd_mech] [numeric](6, 2) NULL,
	[claim_pd_perf] [numeric](6, 2) NULL,
	[claim_not_co llected_mech] [numeric](6, 2) NULL,
	[claim_not_co llected_perf] [numeric](6, 2) NULL,
	[claim_unmatc hed_mech] [numeric](6, 2) NULL,
	[claim_unmatc hed_perf] [numeric](6, 2) NULL,
 CONSTRAINT [PK_CCID_DETAIL] PRIMARY KEY CLUSTERED 
(
	[CCIdFileId] ASC,
	[ref_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CCID_Detail]  WITH CHECK ADD  CONSTRAINT [FK_CCID_DET_REFERENCE_CCID_FIL] FOREIGN KEY([CCIdFileId])
REFERENCES [dbo].[CCID_FILE] ([CCIdFileId])
GO

ALTER TABLE [dbo].[CCID_Detail] CHECK CONSTRAINT [FK_CCID_DET_REFERENCE_CCID_FIL]
GO

/****** Object:  Table [dbo].[CCID_Trailer]    Script Date: 7/11/2019 1:59:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CCID_Trailer](
	[CCIdFileId] [int] NOT NULL,
	[record_type] [char](2) NOT NULL,
	[id_records] [numeric](8, 0) NOT NULL,
	[dl_records] [numeric](8, 0) NOT NULL,
	[sum_amount_licensor] [numeric](30, 4) NOT NULL,
	[sum_amount_copcon] [numeric](30, 4) NOT NULL,
	[sum_amount_unmatched] [numeric](30, 4) NOT NULL,
 CONSTRAINT [PK_CCID_TRAILER] PRIMARY KEY CLUSTERED 
(
	[CCIdFileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CCID_Trailer]  WITH CHECK ADD  CONSTRAINT [FK_CCID_TRA_REFERENCE_CCID_FIL] FOREIGN KEY([CCIdFileId])
REFERENCES [dbo].[CCID_FILE] ([CCIdFileId])
GO

ALTER TABLE [dbo].[CCID_Trailer] CHECK CONSTRAINT [FK_CCID_TRA_REFERENCE_CCID_FIL]
GO

