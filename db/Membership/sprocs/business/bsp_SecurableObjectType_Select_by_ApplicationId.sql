DELIMITER $$

-- Select --
DROP PROCEDURE IF EXISTS bsp_SecurableObjectType_Select_by_ApplicationId$$
CREATE PROCEDURE bsp_SecurableObjectType_Select_by_ApplicationId
(
	_applicationId bigint
)
BEGIN
	SELECT * 
	FROM `SecurableObjectType`
	WHERE ApplicationId = _applicationId;
END$$

DELIMITER ;

