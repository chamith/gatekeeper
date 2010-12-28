DELIMITER $$

-- Select --
DROP PROCEDURE IF EXISTS bsp_RoleRightAssignment_Select_by_ApplicationId$$
CREATE PROCEDURE bsp_RoleRightAssignment_Select_by_ApplicationId
(
	_applicationId bigint
)
BEGIN
	SELECT * 
	FROM `RoleRightAssignment`
	WHERE ApplicationId = _applicationId;
END$$

DELIMITER ;

