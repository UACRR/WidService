-- RecAckStatus
declare @RecAckStatusFA	varchar(2) = 'FA' -- Прийнята
declare @RecAckStatusPA	varchar(2) = 'PA' -- Частково прийнята
declare @RecAckStatusRJ	varchar(2) = 'RJ' -- Відхилена

-- RecMsgLevel
declare @RecMsgLevelF varchar(1) = 'F' --Поле
declare @RecMsgLevelR varchar(1) = 'R' --Запис
declare @RecMsgLevelT varchar(1) = 'T' --Транзакція
declare @RecMsgLevelG varchar(1) = 'G' --Група
declare @RecMsgLevelE varchar(1) = 'E' --Файл

-- RecMsgType
declare @RecMsgTypeF varchar(1) = 'F' -- Поле відхилене
declare @RecMsgTypeR varchar(1) = 'R' -- Запис відхилений
declare @RecMsgTypeT varchar(1) = 'T' -- Транзакція відхилена
declare @RecMsgTypeG varchar(1) = 'G' -- Група відхилена
declare @RecMsgTypeE varchar(1) = 'E' -- Файл відхилений

-- RespFileErrCode
declare @RespFileErrCodeSipNotOwn				int = 1
declare @RespFileErrCodeSsrNotOwn				int = 2
declare @RespFileErrCodeSsrOsrMissing			int = 3
declare @RespFileErrCodeIpNameMismatch			int = 4
declare @RespFileErrCodeWicAlreadyRegBySoc		int = 24

-- SubmFileStatus
declare @SubmFileStatusCurrent	 int = 0 -- Поточний
declare @SubmFileStatusSubmitted int = 1 --	Переданий
declare @SubmFileStatusResponded int = 2 --	Відповідь отримана

-- WidSubmGroupStatus
declare @WidSubmGroupStatusCreated			int = 0
declare @WidSubmGroupStatusFileCreated		int = 1
declare @WidSubmGroupStatusFileSubmitted	int = 2
declare @WidSubmGroupStatusResponded		int = 3
declare @WidSubmGroupStatusCompleted		int = 4

-- WidSubmGroupWorkStatus
declare @Unprocessed		int = 0   -- Не оброблено
declare @InWork				int = 1	 -- На розгляді
declare @Postponed			int = 2	 -- Відкладено
declare @Accepted			int = 3	 -- Завтверждено до передачі
declare @Sent				int = 4	 -- Надіслано
declare @Approved			int = 5	 -- Прийнято
declare @Rejected			int = 6	 -- Відхилено
declare @PartApproved		int = 7	 -- Прийнято з зауваженнями
declare @AlreadyInWid		int = 8	 -- Існує в WID
declare @ReSent				int = 9	 -- Надіслано повторно
declare @StatusCompleted	int = 10 -- Передачу завершено