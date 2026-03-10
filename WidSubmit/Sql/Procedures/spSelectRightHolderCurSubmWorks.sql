use SocWidSubmitEx
go

create or alter procedure spSelectRightHolderCurSubmWorks
	@custId int
	-- Спеціальні значення: 0 - всі створи, -1 -жодного твору
as
begin

	if @custId = 0 -- Вибираємо всі твори
	begin
		select
			  Id          
			, SubmissionId
			, ObjId       
			, Wic
			, Iswc
			, Name        
			, NameForWid	
			, IsChanged
			, Status
		from vCurSubmWorks
		order by Name

		return
	end
	else
	begin
		select
			  t4.Id          
			, t4.SubmissionId
			, t4.ObjId       
			, t4.Wic 
			, t4.Iswc
			, t4.Name        
			, t4.NameForWid	
			, t4.IsChanged
			, t4.Status
		from vCurSubmRightHolder t1
			join RightHolder t2 on t1.RightHolderId = t2.Id
			join SubmWorkShare t3 on t1.RightHolderId = t3.RightHolderId
			join vCurSubmWorks t4 on t3.SubmWorkId = t4.Id
		where t2.CustId = @custId
		order by t4.Name
	end

end
go

-- exec spSelectRightHolderCurSubmWorks -1