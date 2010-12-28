DELIMITER $$

-- Select --
DROP PROCEDURE IF EXISTS bsp_Right_Select_by_ApplicationId$$
CREATE PROCEDURE bsp_Right_Select_by_ApplicationId
(
	_applicationId bigint
)
BEGIN
	SELECT * 
	FROM `Right`
	WHERE ApplicationId = _applicationId;
END$$

DELIMITER ;

