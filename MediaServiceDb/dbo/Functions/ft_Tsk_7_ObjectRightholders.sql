
CREATE function [dbo].[ft_Tsk_7_ObjectRightholders]  (@objId int)
RETURNS TABLE
AS
RETURN
	SELECT
		cr.objId,
		cr.custId,
		cst.name,
		SUM(ISNULL(cr.rate, 0)) AS totalRate,
		creativeRoles = STUFF((
			SELECT
				', ' + r.Name
			FROM CopyRight AS cr1
				JOIN CreativeRoleType AS r ON cr1.roleCode = r.codeI AND cr1.objId = cr.objId AND cr1.custId = cr.custId
			WHERE
				GETDATE() between cr1.beginDate and cr1.endDate
			FOR XML PATH('')
		), 1, 2, '')
	FROM CopyRight AS cr
		LEFT JOIN vCustomer AS cst ON cr.custId = cst.custId
	WHERE
		GETDATE() between cr.beginDate and cr.endDate
		AND cr.objId = @objId
	GROUP BY
		cr.objId, cr.custId, cst.name