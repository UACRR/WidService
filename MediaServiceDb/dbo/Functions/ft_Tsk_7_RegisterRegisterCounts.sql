
CREATE function [dbo].[ft_Tsk_7_RegisterRegisterCounts]  (@regId int)
RETURNS TABLE
AS
RETURN
	SELECT
		r.regCntId,
		r.regId,
		r.regIitemId,
		r.objId,
		r.custId,
		r.rate,
		cst.name,
		creativeRoles = STUFF((
			SELECT
				', ' + rt.Name
			FROM CopyRight AS cr1
				JOIN CreativeRoleType AS rt ON cr1.roleCode = rt.codeI AND cr1.objId = r.objId AND cr1.custId = r.custId
			WHERE
				GETDATE() between cr1.beginDate and cr1.endDate
			FOR XML PATH('')
		), 1, 2, '')
	FROM
		RegisterCount AS r
		LEFT JOIN vCustomer AS cst ON r.custId = cst.custId
	WHERE
		r.regId = @regId