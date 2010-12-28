DELIMITER $$

-- Select --
DROP PROCEDURE IF EXISTS bsp_UserRoleAssignment_Select_by_ApplicationId_UserId$$
CREATE PROCEDURE bsp_UserRoleAssignment_Select_by_ApplicationId_UserId
(
	_applicationId bigint,
	_userId bigint
)
BEGIN
	SELECT *
	FROM UserRoleAssignment
	WHERE ApplicationId = _applicationId
		AND UserId = _userId;
END$$

DELIMITER ;

