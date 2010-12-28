DELIMITER $$

-- Select --
DROP PROCEDURE IF EXISTS bsp_Right_Select_by_ApplicationId_SecurableObjectTypeId$$
CREATE PROCEDURE bsp_Right_Select_by_ApplicationId_SecurableObjectTypeId
(
	_applicationId bigint,
	_securableObjectId bigint
)
BEGIN
	SELECT * 
	FROM `Right`
	WHERE ApplicationId = _applicationId
		AND SecurableObjectId = _securableObjectId;
END$$

DELIMITER ;

