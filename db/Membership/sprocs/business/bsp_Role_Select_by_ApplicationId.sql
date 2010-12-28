DELIMITER $$

-- Select --
DROP PROCEDURE IF EXISTS bsp_Role_Select_by_ApplicationId$$
CREATE PROCEDURE bsp_Role_Select_by_ApplicationId
(
	_applicationId bigint
)
BEGIN
	SELECT * 
	FROM `Role`
	WHERE ApplicationId = _applicationId;
END$$

DELIMITER ;

