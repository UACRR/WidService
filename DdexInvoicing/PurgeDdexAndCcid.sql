ALTER TABLE [dbo].[CcidClDetail] DROP CONSTRAINT [FK_CCID_CL_DET_REFERENCE_CCID_FIL];
ALTER TABLE [dbo].[CcidClFile] DROP CONSTRAINT [FK_CCID_CL_FIL_REFERENCE_DDEXREPO];
ALTER TABLE [dbo].[CcidClHeader] DROP CONSTRAINT [FK_CCID_HEA_REFERENCE_CCID_CL_FIL];
ALTER TABLE [dbo].[CcidClTrailer] DROP CONSTRAINT [FK_CCID_TRA_REFERENCE_CCID_CL_FIL];
ALTER TABLE [dbo].[CcidInDetail] DROP CONSTRAINT [FK_CCID_DET_REFERENCE_CCID_FIL];
ALTER TABLE [dbo].[CcidInFile] DROP CONSTRAINT [FK_CCID_FIL_REFERENCE_DDEXREPO];
ALTER TABLE [dbo].[CcidInHeader] DROP CONSTRAINT [FK_CCID_HEA_REFERENCE_CCID_FIL];
ALTER TABLE [dbo].[CcidInTrailer] DROP CONSTRAINT [FK_CCID_TRA_REFERENCE_CCID_FIL];
ALTER TABLE [dbo].[DdexRecordHead] DROP CONSTRAINT [FK_HEAD_REFERENCE_DDEXREPO];
ALTER TABLE [dbo].[DdexReport] DROP CONSTRAINT [FK_DdexReport_DdexReportingPeriod];
ALTER TABLE [dbo].[ExceptionAdd] DROP CONSTRAINT [FK_EXCEPTIO_REFERENCE_EXCEPTIO];
ALTER TABLE [dbo].[IdentBacklog] DROP CONSTRAINT [FK_IDENTBAC_REFERENCE_IDENTMW];
ALTER TABLE [dbo].[IdentMWAuthor] DROP CONSTRAINT [FK_IDENTMWA_REFERENCE_IDENTMW];

truncate table [DdexRecordHead]
truncate table [CcidInTrailer]
truncate table [CcidInHeader]
truncate table [CcidInDetail]
truncate table [CcidClTrailer]
truncate table [CcidClHeader]
truncate table [CcidClDetail]
truncate table [IdentMWAuthor]
truncate table [IdentBacklog]
truncate table [DdexReport]
truncate table [CcidInFile]
truncate table [CcidClFile]
truncate table [RevShare]
truncate table [IdentMW]
truncate table [DdexReportProcessingData]
truncate table [DdexReportingPeriod]
truncate table [DdexIdentificationBacklog]
truncate table [DdexFileErrors]


ALTER TABLE [dbo].[CcidClDetail] ADD CONSTRAINT [FK_CCID_CL_DET_REFERENCE_CCID_FIL] FOREIGN KEY ([fileId]) REFERENCES [dbo].[CcidClFile]([fileId]);
ALTER TABLE [dbo].[CcidClHeader] ADD CONSTRAINT [FK_CCID_HEA_REFERENCE_CCID_CL_FIL] FOREIGN KEY ([fileId]) REFERENCES [dbo].[CcidClFile]([fileId]);
ALTER TABLE [dbo].[CcidClTrailer] ADD CONSTRAINT [FK_CCID_TRA_REFERENCE_CCID_CL_FIL] FOREIGN KEY ([fileId]) REFERENCES [dbo].[CcidClFile]([fileId]);
ALTER TABLE [dbo].[CcidInDetail] ADD CONSTRAINT [FK_CCID_DET_REFERENCE_CCID_FIL] FOREIGN KEY ([fileId]) REFERENCES [dbo].[CcidInFile]([fileId]);
ALTER TABLE [dbo].[CcidInHeader] ADD CONSTRAINT [FK_CCID_HEA_REFERENCE_CCID_FIL] FOREIGN KEY ([fileId]) REFERENCES [dbo].[CcidInFile]([fileId]);
ALTER TABLE [dbo].[CcidInTrailer] ADD CONSTRAINT [FK_CCID_TRA_REFERENCE_CCID_FIL] FOREIGN KEY ([fileId]) REFERENCES [dbo].[CcidInFile]([fileId]);
ALTER TABLE [dbo].[DdexRecordHead] ADD CONSTRAINT [FK_HEAD_REFERENCE_DDEXREPO] FOREIGN KEY ([DdexReportId]) REFERENCES [dbo].[DdexReport]([Id]);
ALTER TABLE [dbo].[CcidClFile] ADD CONSTRAINT [FK_CCID_CL_FIL_REFERENCE_DDEXREPO] FOREIGN KEY ([DdexReportingPeriodId]) REFERENCES [dbo].[DdexReportingPeriod]([Id]);
ALTER TABLE [dbo].[CcidInFile] ADD CONSTRAINT [FK_CCID_FIL_REFERENCE_DDEXREPO] FOREIGN KEY ([DdexReportingPeriodId]) REFERENCES [dbo].[DdexReportingPeriod]([Id]);
ALTER TABLE [dbo].[DdexReport] ADD CONSTRAINT [FK_DdexReport_DdexReportingPeriod] FOREIGN KEY ([ddexReportingPeriodId]) REFERENCES [dbo].[DdexReportingPeriod]([Id]);
ALTER TABLE [dbo].[ExceptionAdd] ADD CONSTRAINT [FK_EXCEPTIO_REFERENCE_EXCEPTIO] FOREIGN KEY ([excId]) REFERENCES [dbo].[ExceptionMember]([id]);
ALTER TABLE [dbo].[IdentBacklog] ADD CONSTRAINT [FK_IDENTBAC_REFERENCE_IDENTMW] FOREIGN KEY ([mwId]) REFERENCES [dbo].[IdentMW]([id]);
ALTER TABLE [dbo].[IdentMWAuthor] ADD CONSTRAINT [FK_IDENTMWA_REFERENCE_IDENTMW] FOREIGN KEY ([mwId]) REFERENCES [dbo].[IdentMW]([id]);