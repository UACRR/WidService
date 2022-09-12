USE [DDEX]
GO

/****** Object:  StoredProcedure [dbo].[spDeleteDdexReport]    Script Date: 12.09.2022 13:08:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[spDeleteDdexReport]
	@ddexReportId int
as
/*
Удаляет отчет и связанные с ним записи, чтобы можно было повторить регистрацию,
загрузку и последующие шаги с нуля.
Не затрагивает identMw и таблицы, относящиеся к архивации
В настоящее время предназначено для тестирования, в интерфейсе пользователя не используется
*/
begin
-- отправленные Ccid
delete t1
from CcidInHeader t1
	join CcidInFile t2 on t2.fileId = t1.fileId
	join CcidInvoice t3 on t3.id = t2.ccidInvoiceId
	join DdexReport t4 on t4.id = t3.ddexReportId
where t4.id = @ddexReportId;

delete t1
from CcidInTrailer t1
	join CcidInFile t2 on t2.fileId = t1.fileId
	join CcidInvoice t3 on t3.id = t2.ccidInvoiceId
	join DdexReport t4 on t4.id = t3.ddexReportId
where t4.id = @ddexReportId;

delete t1
from CcidInDetail t1
	join CcidInFile t2 on t2.fileId = t1.fileId
	join CcidInvoice t3 on t3.id = t2.ccidInvoiceId
	join DdexReport t4 on t4.id = t3.ddexReportId
where t4.id = @ddexReportId;

delete t2
from CcidInFile t2
	join CcidInvoice t3 on t3.id = t2.ccidInvoiceId
	join DdexReport t4 on t4.id = t3.ddexReportId
where t4.id = @ddexReportId;

-- принятые Ccid
delete t1
from CcidClHeader t1
	join CcidClFile t2 on t2.fileId = t1.fileId
	join CcidInvoice t3 on t3.id = t2.ccidInvoiceId
	join DdexReport t4 on t4.id = t3.ddexReportId
where t4.id = @ddexReportId;

delete t1
from CcidClTrailer t1
	join CcidClFile t2 on t2.fileId = t1.fileId
	join CcidInvoice t3 on t3.id = t2.ccidInvoiceId
	join DdexReport t4 on t4.id = t3.ddexReportId
where t4.id = @ddexReportId;

delete t1
from CcidClDetail t1
	join CcidClFile t2 on t2.fileId = t1.fileId
	join CcidInvoice t3 on t3.id = t2.ccidInvoiceId
	join DdexReport t4 on t4.id = t3.ddexReportId
where t4.id = @ddexReportId;

delete t2
from CcidClFile t2
	join CcidInvoice t3 on t3.id = t2.ccidInvoiceId
	join DdexReport t4 on t4.id = t3.ddexReportId
where t4.id = @ddexReportId;

-- Принятые отчеты
delete t1
from CrfDetail t1
	join CcidInFile t2 on t2.fileId = t1.fileId
	join CcidInvoice t3 on t3.id = t2.ccidInvoiceId
	join DdexReport t4 on t4.id = t3.ddexReportId
where t4.id = @ddexReportId;

delete t1
from DdexAdjustment t1
	join CcidInFile t2 on t2.fileId = t1.fileId
	join CcidInvoice t3 on t3.id = t2.ccidInvoiceId
	join DdexReport t4 on t4.id = t3.ddexReportId
where t4.id = @ddexReportId;

-- Инвойсы
delete t3
from  CcidInvoice t3
	join DdexReport t4 on t4.id = t3.ddexReportId
where t4.id = @ddexReportId;

-- Остальное
delete
from DdexFileErrors
where ddexReportId = @ddexReportId;

delete
from DdexIdentificationBacklog
where ddexReportId = @ddexReportId;

delete
from DdexNetRevenueDistr
where ddexReportId = @ddexReportId;

delete
from DdexRecordHead
where ddexReportId = @ddexReportId;

delete
from DdexRecordSY_04_01
where ddexReportId = @ddexReportId;

delete
from DdexRecordSY_05_02
where ddexReportId = @ddexReportId;

delete
from DdexReportArchRestoreProtocol
where ddexReportId = @ddexReportId;

delete
from DdexReportProcessingData
where ddexReportId = @ddexReportId;

delete
from IdentMWAuthor
where ddexReportId = @ddexReportId;

alter table IdentMWAuthor drop constraint if exists FK_IDENTMWA_REFERENCE_IDENTBAC

delete
from IdentBacklog
where ddexReportId = @ddexReportId;

alter table IdentMWAuthor add  constraint FK_IDENTMWA_REFERENCE_IDENTBAC foreign key(BlockId, DdexReportId, SalesTransactionId)
references IdentBacklog (BlockId, DdexReportId, SalesTransactionId)


delete t3
from  IdentProgressByBlock t3
	join IdentProgress t4 on t4.id = t3.IdentProgressId
where t4.id = @ddexReportId;

delete
from IdentProgress
where ddexReportId = @ddexReportId;

delete
from IdentReportMwRecords
where ddexReportId = @ddexReportId;

-- удалить очет
delete
from DdexReport
where id = @ddexReportId;

end
GO

