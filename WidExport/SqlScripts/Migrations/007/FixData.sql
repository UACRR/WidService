--select * from SubmFile where name = 'WID2025121205240950300140.021'
--select * from RespFile where name = 'WID20251212161453140300.021'

exec spSubmFilePostSent 20078

exec spRespFileDelete 14083

--- ЗАВАНТАЖУЄМО ВІДПОВІДІ

-- Тепер певні твори мають невірний статус, бо spSubmFilePostSent позначає твори Готові Для передачі як Передані.
-- А в файл вони могли не потрапити. Тому якщо відповідь для творів не отримана позначаємо їх як Готові для передачі
-- WidSubmGroupWorkStatus
	declare @Accepted			int = 3	 -- Завтверждено до передачі
	declare @Sent				int = 4	 -- Надіслано
	

	update WidSubmGroupWork 
    set 
		  Status = @Accepted
		, ShouldResubmit = 1
	where SubmFileId = 20078
        and Status = @Sent

