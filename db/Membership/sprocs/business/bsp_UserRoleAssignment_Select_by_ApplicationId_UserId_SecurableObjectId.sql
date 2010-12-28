DELIMITER $$

-- Select --
DROP PROCEDURE IF EXISTS bsp_UserRoleAss_Select_by_ApplicationId_UserId_SecurableObjectId$$
CREATE PROCEDURE bsp_UserRoleAss_Select_by_ApplicationId_UserId_SecurableObjectId
(
	_applicationId bigint,
	_userId bigint,
	_securableObjectId bigint
)
BEGIN
	SELECT * 
	FROM `UserRoleAssignment`
	WHERE ApplicationId = _applicationId
		AND UserId = _userId
		AND SecurableObjectId = _securableObjectId;
END$$

DELIMITER ;

