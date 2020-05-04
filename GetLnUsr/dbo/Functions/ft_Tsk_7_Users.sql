--test

CREATE function [dbo].[ft_Tsk_7_Users]  (@normalizedRoleName nvarchar(256) = NULL, @userId nvarchar(48) = NULL)
RETURNS TABLE
AS
RETURN
	SELECT
		userId,
		u.lastName,
		u.firstName,
		u.surName,
		u.email,
		lastName + ' ' + firstName + ' (' + email + ')' as fullName
	FROM
		AspNetUserRoles AS ur
		JOIN AspNetRoles AS r ON ur.roleId = r.id
		JOIN AspNetUsers AS u ON ur.userId = U.id
	WHERE
		(@normalizedRoleName is null or R.normalizedName = @normalizedRoleName)
		AND (@userId is null or u.id = @userId)

