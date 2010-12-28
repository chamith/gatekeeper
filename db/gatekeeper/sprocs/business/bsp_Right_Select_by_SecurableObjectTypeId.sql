DELIMITER $$

-- Select --
DROP PROCEDURE IF EXISTS bsp_Right_Select_by_SecurableObjectTypeId$$
CREATE PROCEDURE bsp_Right_Select_by_SecurableObjectTypeId
(
	_securableObjectTypeId bigint
)
BEGIN
	SELECT * 
	FROM `Right`
	WHERE SecurableObjectTypeId = _securableObjectTypeId;
END$$

DELIMITER ;

