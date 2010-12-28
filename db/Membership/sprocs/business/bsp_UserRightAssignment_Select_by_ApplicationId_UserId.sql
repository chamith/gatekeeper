DELIMITER $$

-- Select --
DROP PROCEDURE IF EXISTS bsp_UserRightAssignment_Select_by_ApplicationId_UserId$$
CREATE PROCEDURE bsp_UserRightAssignment_Select_by_ApplicationId_UserId
(
	_applicationId bigint,
	_userId bigint
)
BEGIN
	SELECT ura.SecurableObjectId, r.Name AS RightName
	FROM UserRoleAssignment ura
	INNER JOIN RoleRightAssignment rra
		ON ura.RoleId = rra.RoleId
	INNER JOIN `Right` r
		ON rra.RightId = r.Id
	WHERE rra.ApplicationId = _applicationId
		AND ura.ApplicationId = _applicationId
		AND r.ApplicationId = _applicationId
		AND ura.UserId = _userId;
END$$

DELIMITER ;

