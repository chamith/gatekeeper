DELIMITER $$

-- Select --
DROP PROCEDURE IF EXISTS bsp_SecurableObjectType_Select_by_ApplicationId_Name$$
CREATE PROCEDURE bsp_SecurableObjectType_Select_by_ApplicationId_Name
(
	_applicationId bigint,
	_name varchar(50)
)
BEGIN
	SELECT * 
	FROM `SecurableObjectType`
	WHERE ApplicationId = _applicationId
	AND Name = _name;
END$$

DELIMITER ;

