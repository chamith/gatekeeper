DELIMITER $$

-- Select --
DROP PROCEDURE IF EXISTS bsp_RoleRightAssignment_Select_by_RoleId$$
CREATE PROCEDURE bsp_RoleRightAssignment_Select_by_RoleId
(
	_roleId bigint
)
BEGIN
	SELECT * 
	FROM `RoleRightAssignment`
	WHERE RoleId = _roleId;
END$$

DELIMITER ;

