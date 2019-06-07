
CREATE function [dbo].[ft_Tsk_7_Fixations]  (@Stage int = NULL, @StageStatus int = NULL)
RETURNS TABLE
AS
RETURN
	SELECT
		fixId,
		usesType,
		eventName,
		c.name as clientName,
		eventDates,
		city + ', ' + address + ', ' + placement AS eventLocation,
		stageStatus AS stageStatusId,
		s.StageName AS stageName,
		s.StatusName AS statusName,
		lastName + ' ' + firstName + ' (' + email + ')' AS responsible,
		fixationDtBegin,
		rewardAmount,
		courtFeeAmount,
		0 AS incomeAmount
	FROM Fixation AS f
		LEFT JOIN FixStageStatus AS s on f.stageStatus = s.codeI
		LEFT JOIN AspNetUsers AS u ON f.userId = u.id
		LEFT JOIN vCustomer As c ON f.clientCustId = c.custId

	WHERE
		(@StageStatus is null or stageStatus = @StageStatus)
		AND (@Stage is null or s.StageCode = @Stage)