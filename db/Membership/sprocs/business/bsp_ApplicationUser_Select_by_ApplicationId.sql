DELIMITER $$

-- Select --
DROP PROCEDURE IF EXISTS bsp_ApplicationUser_Select_by_ApplicationId$$
CREATE PROCEDURE bsp_ApplicationUser_Select_by_ApplicationId
(
	_applicationId bigint
)
BEGIN
	SELECT * 
	FROM `ApplicationUser`
	WHERE ApplicationId = _applicationId;
END$$

DELIMITER ;

