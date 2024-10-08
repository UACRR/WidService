/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[UpdFileId]
      ,[GrId]
      ,[RecType]
      ,[TransSeqNr]
      ,[RecSeqNr]
      ,[TransD]
      ,[TransT]
      ,[RemitSocCde]
      ,[RemitSocName]
      ,[IpBaseNr]
      ,[SttCde]
      ,[IpNameNr]
      ,[NameType]
      ,[IpBaseNrRef]
      ,[SttCdeRef]
      ,[IpNameNrRef]
      ,[NameTypeRef]
  FROM [SocIpi].[dbo].[UpdTrans]
  where IpBaseNr = 'I-000328207-1'

  --declare @ipBaseNr varchar(13) = 'I-000328207-1'
  declare @ipBaseNr varchar(13) = 'I-002220987-4'
select * 
from UpdTrans t1
	join RecMan t2 on t1.UpdFileId = t2.UpdFileId
		and t1.GrId = t2.GrId
		and t1.TransSeqNr = t2.TransSeqNr
where IpBaseNr = @ipBaseNr
	and t1.RecType = 'MAA'